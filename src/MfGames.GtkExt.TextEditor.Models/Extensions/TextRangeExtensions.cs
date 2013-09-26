// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Extensions
{
	public static class TextRangeExtensions
	{
		#region Methods

		public static bool ContainsLine(
			this TextRange textRange,
			LineBuffer lineBuffer,
			int lineIndex,
			out CharacterPosition beginCharacterPosition,
			out CharacterPosition endCharacterPosition)
		{
			// Figure out the line range index and see if the given line is with
			// the range.
			int firstLineIndex =
				textRange.FirstTextPosition.LinePosition.GetLineIndex(lineBuffer);
			int lastLineIndex =
				textRange.EndTextPosition.LinePosition.GetLineIndex(lineBuffer);

			if (lineIndex < firstLineIndex
				|| lineIndex > lastLineIndex)
			{
				beginCharacterPosition = CharacterPosition.Begin;
				endCharacterPosition = CharacterPosition.Begin;
				return false;
			}

			// If the line is the same, we just use the same line.
			if (firstLineIndex == lastLineIndex)
			{
				beginCharacterPosition = textRange.FirstTextPosition.CharacterPosition;
				endCharacterPosition = textRange.LastTextPosition.CharacterPosition;
				return true;
			}

			// We have at least one additional line. If we are on the first,
			// then it is everything to the right of the starting.
			if (firstLineIndex == lineIndex)
			{
				beginCharacterPosition = textRange.FirstTextPosition.CharacterPosition;
				endCharacterPosition = CharacterPosition.End;
				return true;
			}

			// If we are on the last line, then it is everything before the index.
			if (lastLineIndex == lineIndex)
			{
				beginCharacterPosition = CharacterPosition.Begin;
				endCharacterPosition = textRange.LastTextPosition.CharacterPosition;
				return true;
			}

			// In all other cases, it is the entire line.
			beginCharacterPosition = CharacterPosition.Begin;
			endCharacterPosition = CharacterPosition.End;
			return true;
		}

		#endregion
	}
}
