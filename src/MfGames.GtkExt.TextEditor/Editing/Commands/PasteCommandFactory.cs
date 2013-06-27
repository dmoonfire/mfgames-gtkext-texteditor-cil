// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Gtk;
using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.Commands.TextEditing.Composites;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	/// <summary>
	/// A command factory that generate commands to handle pasting.
	/// </summary>
	public class PasteCommandFactory: TextEditingCommandFactory
	{
		#region Properties

		public override HierarchicalPath FactoryKey
		{
			get { return Key; }
		}

		/// <summary>
		/// Contains the key for the command provided by this factory.
		/// </summary>
		public static HierarchicalPath Key { get; private set; }

		#endregion

		#region Methods

		public override string GetTitle(
			CommandFactoryReference commandFactoryReference)
		{
			return "Paste";
		}

		protected override void Do(
			object context,
			CommandFactoryManager<OperationContext> commandFactory,
			object commandData,
			OperationContext operationContext,
			EditorViewController controller,
			IDisplayContext displayContext,
			BufferPosition position)
		{
			// Get the text from the clipboard.
			Clipboard clipboard = displayContext.Clipboard;

			clipboard.RequestText(null);

			string clipboardText = clipboard.WaitForText();

			if (string.IsNullOrEmpty(clipboardText))
			{
				return;
			}

			// Figure out the position of this paste.
			TextPosition textPosition;

			if (displayContext.Caret.Selection.IsEmpty)
			{
				textPosition = new TextPosition(
					displayContext.Caret.Position.LineIndex,
					displayContext.Caret.Position.CharacterIndex);
			}
			else
			{
				textPosition =
					new TextPosition(
						displayContext.Caret.Selection.StartPosition.LineIndex,
						displayContext.Caret.Selection.StartPosition.CharacterIndex);
			}

			// Create the paste command for the text.
			CompositeCommand<OperationContext> command =
				new PasteCommand<OperationContext>(
					controller.CommandController, textPosition, clipboardText);

			// If we have a selection, we need to delete the selection first.
			if (!displayContext.Caret.Selection.IsEmpty)
			{
				// Create the composite command for the delete.
				var composite = new CompositeCommand<OperationContext>(true, false);
				IUndoableCommand<OperationContext> selection =
					DeleteSelectionCommandFactory.CreateCommand(controller, displayContext);

				composite.Commands.Add(selection);
				composite.Commands.Add(command);

				// Move the composite over to the command.
				command = composite;
			}

			// Execute the command.
			controller.CommandController.Do(command, operationContext);

			// If we have a text position, we need to set it.
			if(operationContext.Results.HasValue)
			{
				displayContext.Caret.Position =
					operationContext.Results.Value.BufferPosition;
			}
		}

		#endregion

		#region Constructors

		public PasteCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Paste", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
