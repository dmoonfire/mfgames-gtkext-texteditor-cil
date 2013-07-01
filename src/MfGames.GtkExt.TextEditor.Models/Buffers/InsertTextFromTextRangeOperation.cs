// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Text;
using MfGames.Commands;
using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	public class InsertTextFromTextRangeOperation: TextEditingOperation,
		IInsertTextFromTextRangeCommand<OperationContext>
	{
		#region Properties

		public TextPosition DestinationPosition { get; private set; }
		public SingleLineTextRange SourceRange { get; private set; }

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// Grab the text from the source line.
			string sourceLine = state.LineBuffer.GetLineText(
				SourceRange.Line, LineContexts.Unformatted);
			int sourceBegin = SourceRange.CharacterBegin.NormalizeIndex(
				sourceLine, SourceRange.CharacterEnd, WordSearchDirection.Left);
			int sourceEnd = SourceRange.CharacterEnd.NormalizeIndex(
				sourceLine, SourceRange.CharacterBegin, WordSearchDirection.Right);
			string sourceText = sourceLine.Substring(
				sourceBegin, sourceEnd - sourceBegin);

			// Insert the text from the source line into the destination.
			string destinationLine =
				state.LineBuffer.GetLineText(
					DestinationPosition.Line, LineContexts.Unformatted);
			var buffer = new StringBuilder(destinationLine);
			int characterIndex =
				DestinationPosition.Character.NormalizeIndex(destinationLine);

			buffer.Insert(characterIndex, sourceText);

			// Save the source text length so we can delete it.
			sourceLength = sourceText.Length;
			originalCharacterIndex = characterIndex;

			// Set the line in the buffer.
			destinationLine = buffer.ToString();
			state.LineBuffer.SetText(DestinationPosition.Line, destinationLine);
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Grab the line from the line buffer.
			string lineText = state.LineBuffer.GetLineText(
				DestinationPosition.Line, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			buffer.Remove(originalCharacterIndex, sourceLength);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(DestinationPosition.Line, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new BufferPosition(DestinationPosition.Line, originalCharacterIndex));
			}
		}

		#endregion

		#region Constructors

		public InsertTextFromTextRangeOperation(
			TextPosition destinationPosition,
			SingleLineTextRange sourceRange)
		{
			DestinationPosition = destinationPosition;
			SourceRange = sourceRange;
		}

		#endregion

		#region Fields

		private int originalCharacterIndex;
		private int sourceLength;

		#endregion
	}
}
