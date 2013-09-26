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
			// Figure out the indexes in the source line we'll be using to
			// pull out a substring.
			string sourceLine = state.LineBuffer.GetLineText(
				SourceRange.LinePosition, LineContexts.Unformatted);
			int sourceBegin =
				SourceRange.BeginCharacterPosition.GetCharacterIndex(
					sourceLine, SourceRange.EndCharacterPosition, WordSearchDirection.Left);
			int sourceEnd = SourceRange.EndCharacterPosition.GetCharacterIndex(
				sourceLine, SourceRange.BeginCharacterPosition, WordSearchDirection.Right);

			// Grab the text from the source line. If the source begin is at the
			// end of the string, then our source will always be a blank line.
			// Otherwise, it will be a portion of that source line.
			sourceLength = sourceEnd - sourceBegin;

			string sourceText = sourceLine.Substring(sourceBegin, sourceLength);

			// Insert the text from the source line into the destination.
			string destinationLine =
				state.LineBuffer.GetLineText(
					DestinationPosition.LinePosition, LineContexts.Unformatted);
			var buffer = new StringBuilder(destinationLine);
			int characterIndex =
				DestinationPosition.CharacterPosition.GetCharacterIndex(destinationLine);

			buffer.Insert(characterIndex, sourceText);

			// Save the source text length so we can delete it.
			originalCharacterIndex = characterIndex;

			// Set the line in the buffer.
			destinationLine = buffer.ToString();
			state.LineBuffer.SetText(DestinationPosition.LinePosition, destinationLine);
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Grab the line from the line buffer.
			string lineText =
				state.LineBuffer.GetLineText(
					DestinationPosition.LinePosition, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			buffer.Remove(originalCharacterIndex, sourceLength);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(DestinationPosition.LinePosition, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new TextPosition(DestinationPosition.LinePosition, originalCharacterIndex));
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
