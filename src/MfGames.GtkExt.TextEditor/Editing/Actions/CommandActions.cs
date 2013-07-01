// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Gdk;
using MfGames.Commands;
using MfGames.GtkExt.TextEditor.Editing.Commands;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Contains actions used for undoing and redoing commands.
	/// </summary>
	[ActionFixture]
	public class CommandActions
	{
		#region Methods

		/// <summary>
		/// Redoes the specified action context.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Y, ModifierType.ControlMask)]
		public static void Redo(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference = new CommandFactoryReference(RedoCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Undoes the last command.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Z, ModifierType.ControlMask)]
		public static void Undo(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference = new CommandFactoryReference(UndoCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		#endregion
	}
}
