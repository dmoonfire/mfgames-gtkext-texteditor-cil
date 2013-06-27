// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Interfaces;

namespace MfGames.GtkExt.TextEditor.Buffers
{
	/// <summary>
	/// Implements a word splitter that uses a standard "word" length of 5
	/// characters for the offset.
	/// </summary>
	public class OffsetWordSplitter: IWordSplitter
	{
		#region Methods

		/// <summary>
		/// Gets the next word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns>
		/// The character index of the next word or Int32.MaxValue if one
		/// cannot be found.
		/// </returns>
		public int GetNextWordBoundary(
			string text,
			int characterIndex)
		{
			// If we are at the beginning, return -1.
			if (characterIndex >= text.Length)
			{
				return Int32.MaxValue;
			}

			// Move back five characters or to the beginning.
			return Math.Min(text.Length, characterIndex + 5);
		}

		/// <summary>
		/// Gets the previous word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		public int GetPreviousWordBoundary(
			string text,
			int characterIndex)
		{
			// If we are at the beginning, return -1.
			if (characterIndex == 0)
			{
				return -1;
			}

			// Move back five characters or to the beginning.
			return Math.Max(0, characterIndex - 5);
		}

		#endregion
	}
}
