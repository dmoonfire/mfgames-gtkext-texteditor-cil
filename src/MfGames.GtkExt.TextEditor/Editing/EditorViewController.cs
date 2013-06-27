// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using System.Reflection;
using C5;
using Cairo;
using Gdk;
using Gtk;
using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.Extensions.System;
using MfGames.Extensions.System.Reflection;
using MfGames.GtkExt.TextEditor.Editing.Actions;
using MfGames.GtkExt.TextEditor.Editing.Commands;
using MfGames.GtkExt.TextEditor.Events;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using Key = Gdk.Key;

namespace MfGames.GtkExt.TextEditor.Editing
{
	/// <summary>
	/// Contains the functionality of processing input for the text editor
	/// and performing actions. The general flow is the controller calls an
	/// action which performs the action. For undoable or buffer commands, the
	/// action will creates a command object which one or more buffer operations.
	/// </summary>
	public class EditorViewController
	{
		#region Properties

		/// <summary>
		/// Contains the command controller used to execute commands on
		/// the line buffer associated with this controller.
		/// </summary>
		public ITextEditingCommandController<OperationContext> CommandController
		{
			get { return commandController; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				commandController = value;
			}
		}

		/// <summary>
		/// Contains the command factory for processing commands.
		/// </summary>
		public CommandFactoryManager<OperationContext> CommandFactory { get; private set; }

		/// <summary>
		/// Gets the commands for the text editor.
		/// </summary>
		public CommandManager Commands { get; private set; }

		/// <summary>
		/// Gets the display context for this action.
		/// </summary>
		/// <value>The display.</value>
		public IDisplayContext DisplayContext
		{
			get { return displayContext; }
		}

		/// <summary>
		/// Gets a value indicating whether an action is being performed.
		/// </summary>
		/// <value>
		///   <c>true</c> if [in action]; otherwise, <c>false</c>.
		/// </value>
		public bool InAction
		{
			[DebuggerStepThrough] get { return inAction; }

			private set
			{
				inAction = value;

				if (inAction)
				{
					FireBeginAction();
				}
				else
				{
					FireEndAction();
				}
			}
		}

		/// <summary>
		/// Gets the action states associated with the action.
		/// </summary>
		public ActionStateCollection States
		{
			get { return states; }
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs when an action is begun.
		/// </summary>
		public event EventHandler BeginAction;

		/// <summary>
		/// Occurs when an action has completed.
		/// </summary>
		public event EventHandler EndAction;

		/// <summary>
		/// Occurs when the context menu needs to be populated.
		/// </summary>
		public event EventHandler<PopulateContextMenuArgs> PopulateContextMenu;

		#endregion

		#region Methods

		/// <summary>
		/// Binds the actions from the various classes inside the assembly.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		public void BindActions(Assembly assembly)
		{
			// Make sure we have sane data.
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}

			// Go through the command factories in this assembly.
			foreach (Type type in assembly.GetTypes())
			{
				// If we can't create it, we don't do anything.
				if (type.IsAbstract)
				{
					continue;
				}

				// If we are the proper type, create a new one and register it.
				if (typeof (ICommandFactory<OperationContext>).IsAssignableFrom(type))
				{
					// Create a new instance.
					var commandFactory =
						(ICommandFactory<OperationContext>) Activator.CreateInstance(type);
					CommandFactory.Register(commandFactory);
				}
			}

			// Go through the types in the assembly.
			foreach (Type type in assembly.GetTypes())
			{
				// Check to see if the type contains our attribute.
				bool isFixture = type.HasCustomAttribute<ActionFixtureAttribute>();

				if (!isFixture)
				{
					continue;
				}

				// Go through all the methods inside the type and make sure they
				// have the action attribute.
				foreach (MethodInfo method in type.GetMethods())
				{
					// Check to see if this method has the action attribute.
					bool isAction = method.HasCustomAttribute<ActionAttribute>();

					if (!isAction)
					{
						continue;
					}

					// Create an action entry for this element.
					var action =
						(Action<EditorViewController>)
							Delegate.CreateDelegate(typeof (Action<EditorViewController>), method);
					var entry = new ActionEntry(method.Name, action);

					actions[method.Name] = entry;

					// Pull out the state objects and add them into the entry.
					object[] actionStates =
						method.GetCustomAttributes(typeof (ActionStateAttribute), false);

					foreach (ActionStateAttribute actionState in actionStates)
					{
						entry.StateTypes.Add(actionState.StateType);
					}

					// Pull out the key bindings and assign them.
					object[] bindings = method.GetCustomAttributes(
						typeof (KeyBindingAttribute), false);

					foreach (KeyBindingAttribute keyBinding in bindings)
					{
						// Get the keys and modifiers.
						int keyCode = GdkUtility.GetNormalizedKeyCode(
							keyBinding.Key, keyBinding.Modifier);

						// Add the key to the dictionary.
						keyBindings[keyCode] = entry;
					}
				}
			}
		}

		/// <summary>
		/// Creates the context menu for the caret position.
		/// </summary>
		/// <returns></returns>
		public Menu CreateContextMenu()
		{
			// Create a new menu and add the three basic controls.
			var menu = new Menu();

			var cutMenuItem = new ImageMenuItem(Stock.Cut, null);
			cutMenuItem.Name = "Cut";
			cutMenuItem.Activated += OnContextMenuItemActivated;
			menu.Append(cutMenuItem);

			var copyMenuItem = new ImageMenuItem(Stock.Copy, null);
			copyMenuItem.Name = "Copy";
			copyMenuItem.Activated += OnContextMenuItemActivated;
			menu.Add(copyMenuItem);

			var pasteMenuItem = new ImageMenuItem(Stock.Paste, null);
			pasteMenuItem.Name = "Paste";
			pasteMenuItem.Activated += OnContextMenuItemActivated;
			menu.Add(pasteMenuItem);

			// Allow a callback to manipulate the menu.
			if (PopulateContextMenu != null)
			{
				// Create the arguments for the event.
				var args = new PopulateContextMenuArgs();
				args.Menu = menu;
				args.Controller = this;

				// Trigger the event.
				PopulateContextMenu(this, args);
			}

			// Return the resulting menu.
			return menu;
		}

		/// <summary>
		/// Performs the given operation on the line buffer.
		/// </summary>
		/// <param name="operation">The operation.</param>
		public LineBufferOperationResults Do(ILineBufferOperation operation)
		{
			if (operation == null)
			{
				throw new ArgumentNullException("operation");
			}

			return displayContext.LineBuffer.Do(operation);
		}

		/// <summary>
		/// Performs the given command on the line buffer.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Do(Command command)
		{
			// Perform the various operations for the initial command.
			LineBufferOperationResults? results = null;

			foreach (ILineBufferOperation operation in command.Operations)
			{
				results = Do(operation);
			}

			// If we had a results, reset the buffer position.
			if (results.HasValue)
			{
				command.EndPosition = results.Value.BufferPosition;
			}

			// Add the command to the manager.
			Commands.Add(command);

			// Scroll to the command's end position.
			displayContext.Caret.Position = command.EndPosition;
			displayContext.RequestScrollToCaret();
		}

		/// <summary>
		/// Performs the given command on the line buffer.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="bufferPosition">The buffer position.</param>
		public void Do(
			Command command,
			BufferPosition bufferPosition)
		{
			// Perform the commands.
			Do(command);

			// This explictly sets the buffer position after the commands.
			command.EndPosition = bufferPosition;
			displayContext.Caret.Position = command.EndPosition;
			displayContext.RequestScrollToCaret();
		}

		/// <summary>
		/// Performs the specified action name.
		/// </summary>
		/// <param name="actionName">Name of the action.</param>
		public void Do(string actionName)
		{
			// Perform the action with the context.
			actions[actionName].Action(this);
		}

		/// <summary>
		/// Fires the EndAction event.
		/// </summary>
		public void FireEndAction()
		{
			if (EndAction != null)
			{
				EndAction(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Handles a key press and performs the appropriate action.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="unicodeKey">The Unicode key.</param>
		/// <param name="modifier">The modifier.</param>
		public bool HandleKeyPress(
			Key key,
			ModifierType modifier,
			uint unicodeKey)
		{
			// Normalize the key code and remove excessive modifiers.
			ModifierType filteredModifiers = modifier
				& (ModifierType.ShiftMask | ModifierType.Mod1Mask | ModifierType.ControlMask
					| ModifierType.MetaMask | ModifierType.SuperMask);
			int keyCode = GdkUtility.GetNormalizedKeyCode(key, filteredModifiers);

			// Check to see if we have an action for this.
			ModifierType isNormalOrShifted = filteredModifiers & ~ModifierType.ShiftMask;
			bool isCharacter = unicodeKey != 0 && isNormalOrShifted == ModifierType.None;
			bool isAction = keyBindings.Contains(keyCode);

			if (isAction || isCharacter)
			{
				// Keep track of the original selection.
				BufferSegment previousSelection = displayContext.Caret.Selection;

				// Mark that we are starting a new action and fire events so
				// other listeners and handle it.
				InAction = true;

				// Perform the appropriate action.
				try
				{
					if (isAction)
					{
						keyBindings[keyCode].Perform(this);
					}
					else
					{
						TextActions.InsertText(this, (char) unicodeKey);
					}
				}
				finally
				{
					InAction = false;
				}

				// Check to see if the selection changed.
				if (previousSelection != displayContext.Caret.Selection)
				{
					displayContext.Renderer.UpdateSelection(displayContext, previousSelection);
				}

				// We did something, so return processed.
				return true;
			}

			// No idea what to do, so don't do anything.
			return false;
		}

		/// <summary>
		/// Handles the mouse movement.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <param name="modifier">The modifier.</param>
		/// <returns></returns>
		public bool HandleMouseMotion(
			PointD point,
			ModifierType modifier)
		{
			// Mark ourselves as inside an action.
			InAction = true;

			try
			{
				// If we are in a text select, update the selection.
				if (inTextSelect && point.X >= displayContext.TextX)
				{
					// Figure out text-relative coordinates.
					var textPoint = new PointD(point.X - displayContext.TextX, point.Y);

					// Get the previous selection.
					BufferSegment previousSelection = displayContext.Caret.Selection;

					// Set the tail of the anchor to the current mouse position.
					displayContext.Caret.Selection.TailPosition =
						MoveActions.GetBufferPosition(textPoint, displayContext);

					// Update the display.
					displayContext.Renderer.UpdateSelection(displayContext, previousSelection);
					displayContext.RequestRedraw();

					// We processed this motion.
					return true;
				}

				// We didn't process it, so return false.
				return false;
			}
			finally
			{
				// Remove the action flag.
				InAction = false;
			}
		}

		/// <summary>
		/// Handles the mouse press and the associated code.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <param name="button">The button.</param>
		/// <param name="modifier">The state.</param>
		/// <param name="eventType">The event type that triggered the press.</param>
		/// <returns>If handled, <see langword="true"/>. Otherwise, 
		/// <see langword="false"/>.</returns>
		public bool HandleMousePress(
			PointD point,
			uint button,
			ModifierType modifier,
			EventType eventType)
		{
			// If we don't have a buffer, we don't do anything.
			if (displayContext.Renderer == null)
			{
				return false;
			}

			// If we are pressing the left button (button 1) then we move the caret
			// over. If we are pressing the right button, we only change the position
			// if we don't already have a selection.
			if (button == 1
				|| (button == 3 && displayContext.Caret.Selection.IsEmpty))
			{
				// Figure out if we are clicking inside the text area.
				if (point.X >= displayContext.TextX)
				{
					// Figure out text-relative coordinates.
					var textPoint = new PointD(point.X - displayContext.TextX, point.Y);

					// Grab the anchor position of the selection since that will
					// remain the same after the command.
					Caret caret = displayContext.Caret;
					BufferSegment previousSelection = caret.Selection;

					// Keep track of the selection so we can drag-select.
					if (button == 1)
					{
						inTextSelect = true;
						previousTextSelection = previousSelection;
					}

					// Mark that we are starting a new action and fire events so
					// other listeners and handle it.
					InAction = true;

					// Perform the appropriate action.
					try
					{
						switch (eventType)
						{
							case EventType.TwoButtonPress:
								MoveActions.SelectWord(this);
								break;

							case EventType.ThreeButtonPress:
								MoveActions.SelectLine(this);
								break;

							default:
								MoveActions.Point(displayContext, textPoint);
								break;
						}
					}
					finally
					{
						InAction = false;
					}

					// If we are holding down the shift-key, then we want to
					// restore the previous selection anchor.
					if ((modifier & ModifierType.ShiftMask) == ModifierType.ShiftMask)
					{
						// Restore the anchor position which will extend the selection back.
						displayContext.Caret.Selection.AnchorPosition =
							previousSelection.AnchorPosition;

						// Check to see if the selection changed.
						if (previousSelection != displayContext.Caret.Selection)
						{
							displayContext.Renderer.UpdateSelection(
								displayContext, previousSelection);
						}
					}
					else if (!previousSelection.IsEmpty)
					{
						displayContext.Renderer.UpdateSelection(displayContext, previousSelection);
					}

					// Redraw the widget.
					displayContext.RequestRedraw(displayContext.Caret.GetDrawRegion());
				}
			}

			// If we are pressing the right mouse, then show the context menu.
			if (button == 3)
			{
				// Create the context menu for this position.
				Menu contextMenu = CreateContextMenu();

				// Attach the menu and show it to the user.
				if (contextMenu != null)
				{
					contextMenu.AttachToWidget((EditorView) displayContext, null);
					contextMenu.Popup();
					contextMenu.ShowAll();
				}
			}

			// We haven't handled it, so return false so the rest of Gtk can
			// decide what to do with the input.
			return false;
		}

		/// <summary>
		/// Handles the mouse release and the associated code.
		/// </summary>
		/// <param name="point">The point.</param>
		/// <param name="button">The button.</param>
		/// <param name="modifier">The state.</param>
		/// <returns></returns>
		public bool HandleMouseRelease(
			PointD point,
			uint button,
			ModifierType modifier)
		{
			// If we are releasing the left button (button 1), then we need to extend the
			// selection.
			if (button == 1
				|| button == 3)
			{
				// Figure out if we are clicking inside the text area.
				if (point.X < displayContext.TextX)
				{
					// We didn't release in the text area.
					BufferSegment currentSelection = displayContext.Caret.Selection;

					displayContext.Caret.Selection = previousTextSelection;
					displayContext.Renderer.UpdateSelection(displayContext, currentSelection);
				}
			}

			// Release the various motion flags.
			inTextSelect = false;

			// We haven't handled it, so return false so the rest of Gtk can
			// decide what to do with the input.
			return false;
		}

		/// <summary>
		/// Resets the controller and its various internal states.
		/// </summary>
		public void Reset()
		{
			states.RemoveAll();
		}

		/// <summary>
		/// Binds the default actions into the controller.
		/// </summary>
		private void BindActions()
		{
			// Register our known command factories from other assemblies.
			CommandFactory.Register(new UndoCommandFactory());
			CommandFactory.Register(new RedoCommandFactory());

			// Bind all the actions from our assembly.
			BindActions(GetType().Assembly);
		}

		/// <summary>
		/// Fires the BeginAction event.
		/// </summary>
		private void FireBeginAction()
		{
			if (BeginAction != null)
			{
				BeginAction(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Called when a context menu item is activated.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnContextMenuItemActivated(
			object sender,
			EventArgs e)
		{
			// The widget will contain the action name.
			var widget = (Widget) sender;
			Do(widget.Name);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewController"/> class.
		/// </summary>
		/// <param name="editorView">The text editor associated with this controller.</param>
		public EditorViewController(EditorView editorView)
		{
			// Saves the display context for performing actions.
			if (editorView == null)
			{
				throw new ArgumentNullException("editorView");
			}

			displayContext = editorView;

			// Bind the initial keybindings.
			keyBindings = new HashDictionary<int, ActionEntry>();
			actions = new HashDictionary<string, ActionEntry>();

			// Bind the action states.
			states = new ActionStateCollection();
			Commands = new CommandManager();
			CommandController = new LineBufferCommandController();
			CommandFactory =
				new CommandFactoryManager<OperationContext>(CommandController);

			// Bind the default actions for the editor.
			BindActions();
		}

		#endregion

		#region Fields

		private readonly HashDictionary<string, ActionEntry> actions;
		private ITextEditingCommandController<OperationContext> commandController;
		private readonly IDisplayContext displayContext;
		private bool inAction;
		private bool inTextSelect;
		private readonly HashDictionary<int, ActionEntry> keyBindings;
		private BufferSegment previousTextSelection;
		private readonly ActionStateCollection states;

		#endregion
	}
}
