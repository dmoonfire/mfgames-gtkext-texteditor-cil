// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public class InsertCharacterCommandFactory: TextEditingCommandFactory
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
			return "Insert Character";
		}

		protected override void Do(
			object context,
			CommandFactoryManager<OperationContext> commandFactory,
			object commandData,
			OperationContext operationContext,
			EditorViewController controller,
			IDisplayContext displayContext,
			TextPosition position)
		{
			// If we don't have a selection, this is a simple insert command.
			TextPosition bufferPosition = displayContext.Caret.Position;
			TextRange selection = displayContext.Caret.Selection;

			if (!selection.IsEmpty)
			{
				// Create and execute the delete command. We do this separately
				// so they show up as a different undo item.
				IUndoableCommand<OperationContext> deleteCommand =
					DeleteSelectionCommandFactory.CreateCommand(controller, displayContext);

				controller.CommandController.Do(deleteCommand, operationContext);

				// We have to reset the position so the insert happens as if
				// the text doesn't exist.
				bufferPosition = selection.FirstTextPosition;
				operationContext = new OperationContext(
					operationContext.LineBuffer, bufferPosition);
			}

			// Create the insert command using the (potentially) modified selection.
			string text = commandData.ToString();
			IInsertTextCommand<OperationContext> insertCommand =
				controller.CommandController.CreateInsertTextCommand(bufferPosition, text);
			insertCommand.UpdateTextPosition = DoTypes.All;

			controller.CommandController.Do(insertCommand, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.SetAndScrollToPosition(
					operationContext.Results.Value.TextPosition);
			}
		}

		#endregion

		#region Constructors

		static InsertCharacterCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Insert Character", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
