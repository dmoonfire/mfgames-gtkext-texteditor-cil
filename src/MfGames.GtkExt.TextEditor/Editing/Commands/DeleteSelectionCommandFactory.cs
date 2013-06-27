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
	public class DeleteSelectionCommandFactory: TextEditingCommandFactory
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

		/// <summary>
		/// Creates the command needed for the delete selection.
		/// </summary>
		/// <param name="controller"></param>
		/// <param name="displayContext"></param>
		/// <returns></returns>
		public static IUndoableCommand<OperationContext> CreateCommand(
			EditorViewController controller,
			IDisplayContext displayContext)
		{
			// Grab the selection and determine if we are a single line or
			// multiple line selection.
			IUndoableCommand<OperationContext> command;
			BufferSegment selection = displayContext.Caret.Selection;

			if (selection.IsSameLine)
			{
				IDeleteTextCommand<OperationContext> deleteCommand =
					controller.CommandController.CreateDeleteTextCommand(
						new SingleLineTextRange(
							selection.StartPosition.LineIndex,
							selection.StartPosition.CharacterIndex,
							selection.EndPosition.CharacterIndex));
				deleteCommand.UpdateTextPosition = DoTypes.All;
				command = deleteCommand;
			}
			else
			{
				// We have a multiple line delete which requires some additional
				// processing since the core operation is a single line only.
				var compositeCommand = new CompositeCommand<OperationContext>(true, false);

				// Delete the text from the first line.
				IDeleteTextCommand<OperationContext> firstLineCommand =
					controller.CommandController.CreateDeleteTextCommand(
						new SingleLineTextRange(
							selection.StartPosition.LineIndex,
							selection.StartPosition.CharacterIndex,
							CharacterPosition.End));
				firstLineCommand.UpdateTextPosition = DoTypes.All;

				compositeCommand.Commands.Add(firstLineCommand);

				// Insert the text from the last into into the first.
				IInsertTextFromTextRangeCommand<OperationContext> secondLineCommand =
					controller.CommandController.CreateInsertTextFromTextRangeCommand(
						new TextPosition(
							selection.StartPosition.LineIndex, selection.StartPosition.CharacterIndex),
						new SingleLineTextRange(
							selection.EndPosition.LineIndex,
							selection.EndPosition.CharacterIndex,
							CharacterPosition.End));

				compositeCommand.Commands.Add(secondLineCommand);

				// Delete all the lines between the two.
				for (int line = selection.StartPosition.LineIndex + 1;
					line <= selection.EndPosition.LineIndex;
					line++)
				{
					IDeleteLineCommand<OperationContext> deleteLineCommand =
						controller.CommandController.CreateDeleteLineCommand(line);
					compositeCommand.Commands.Add(deleteLineCommand);
				}

				// Execute the composite command.
				command = compositeCommand;
			}

			// Return the resulting command.
			return command;
		}

		public override string GetTitle(
			CommandFactoryReference commandFactoryReference)
		{
			return "Join Previous Paragraph";
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
			// Create the delete selection command.
			ICommand<OperationContext> command = CreateCommand(
				controller, displayContext);

			// Execute the command.
			controller.CommandController.Do(command, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.Position =
					operationContext.Results.Value.BufferPosition;
			}
		}

		#endregion

		#region Constructors

		static DeleteSelectionCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Delete Selection", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
