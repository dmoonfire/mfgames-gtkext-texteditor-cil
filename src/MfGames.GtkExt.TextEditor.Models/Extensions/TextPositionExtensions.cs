// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Extensions
{
	public static class TextPositionExtensions
	{
		#region Methods

		public static int GetCharacterIndex(
			this TextPosition textPosition,
			LineBuffer lineBuffer)
		{
			string lineText = lineBuffer.GetLineText(textPosition.LinePosition);
			int characterPosition =
				textPosition.CharacterPosition.GetCharacterIndex(lineText);
			return characterPosition;
		}

		public static int GetLineIndex(
			this TextPosition textPosition,
			LineBuffer lineBuffer)
		{
			LinePosition linePosition = textPosition.LinePosition;
			int results = linePosition.GetLineIndex(lineBuffer.LineCount);
			return results;
		}

		#endregion
	}
}
