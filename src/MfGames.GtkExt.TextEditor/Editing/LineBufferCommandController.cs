// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace MfGames.GtkExt.TextEditor.Editing
{
	public class LineBufferCommandController:
		UndoRedoCommandController<OperationContext>,
		ITextEditingCommandController<OperationContext>
	{
		#region Methods

		public IDeleteLineCommand<OperationContext> CreateDeleteLineCommand(
			LinePosition line)
		{
			var operation = new DeleteLinesOperation((int) line, 1);
			return operation;
		}

		public IDeleteTextCommand<OperationContext> CreateDeleteTextCommand(
			SingleLineTextRange range)
		{
			var operation = new DeleteTextOperation(range);
			return operation;
		}

		public IInsertLineCommand<OperationContext> CreateInsertLineCommand(
			LinePosition line)
		{
			var operation = new InsertLinesOperation((int) line, 1);
			return operation;
		}

		public IInsertTextCommand<OperationContext> CreateInsertTextCommand(
			TextPosition textPosition,
			string text)
		{
			var operation = new InsertTextOperation(
				textPosition.LinePosition, textPosition.CharacterPosition, text);
			return operation;
		}

		public IInsertTextFromTextRangeCommand<OperationContext>
			CreateInsertTextFromTextRangeCommand(
			TextPosition destinationPosition,
			SingleLineTextRange sourceRange)
		{
			var operation = new InsertTextFromTextRangeOperation(
				destinationPosition, sourceRange);
			return operation;
		}

		#endregion
	}
}
