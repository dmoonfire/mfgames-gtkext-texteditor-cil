// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Extensions
{
	public static class LinePositionExtensions
	{
		#region Methods

		public static int GetLineIndex(
			this LinePosition linePosition,
			LineBuffer lineBuffer,
			LinePositionOptions options = LinePositionOptions.None)
		{
			int lineIndex = linePosition.GetLineIndex(lineBuffer.LineCount, options);
			return lineIndex;
		}

		#endregion
	}
}
