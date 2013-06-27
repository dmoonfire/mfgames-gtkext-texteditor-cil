// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Interfaces;

namespace MfGames.GtkExt.TextEditor.Editing
{
	/// <summary>
	/// Implements a word splitter that looks for typical English boundaries.
	/// This breaks at the end of words (including their trailing space) or
	/// on punctuation.
	/// </summary>
	public class EnglishWordSplitter: IWordSplitter
	{
		#region Methods

		/// <summary>
		/// Gets the next word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		public int GetNextWordBoundary(
			string text,
			int characterIndex)
		{
			// If we are at the end of the string, there is no boundary.
			if (characterIndex >= text.Length)
			{
				return Int32.MaxValue;
			}

			// Check the starting character. If it is puncutation, then our
			// next word is the next character.
			char startingChar = text[characterIndex];
			bool returnAfterWhitespace = false;

			if (IsPunctuation(startingChar)
				|| IsWhitespace(startingChar))
			{
				returnAfterWhitespace = true;
			}

			// Go through the character string until we find a boundary.
			for (int index = characterIndex + 1;
				index < text.Length;
				index++)
			{
				// If we go to punctuation, then we are done looking.
				if (IsPunctuation(text[index]))
				{
					return index;
				}

				if (IsWhitespace(text[index]))
				{
					returnAfterWhitespace = true;
				}
				else
				{
					// If we are here, we have a non-whitespace or punctuation
					// character.
					if (returnAfterWhitespace)
					{
						return index;
					}
				}
			}

			// If we finished the loop, we couldn't find it so return the end
			// of the string.
			return text.Length;
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
			// If we are at the beginning, there is no boundary.
			if (characterIndex == 0
				|| characterIndex - 1 >= text.Length)
			{
				return -1;
			}

			// Get the starting character's state, which uses slightly different
			// rules.
			char startingChar = text[characterIndex - 1];
			bool hasCharacter = !IsWhitespace(startingChar);
			bool initialWhitespace = !hasCharacter;

			if (IsPunctuation(startingChar))
			{
				return characterIndex - 1;
			}

			// Loop through the the remaining characters.
			for (int index = characterIndex - 1;
				index >= 0;
				index--)
			{
				if (IsPunctuation(text[index]))
				{
					return initialWhitespace && !hasCharacter
						? index
						: index + 1;
				}

				if (IsWhitespace(text[index]))
				{
					if (hasCharacter)
					{
						return index + 1;
					}
				}
				else
				{
					hasCharacter = true;
				}
			}

			// If we finished the loop, we couldn't find it so return the
			// beginning of the string.
			return 0;
		}

		/// <summary>
		/// Determines whether the specified character is punctuation.
		/// </summary>
		/// <param name="c">The c.</param>
		/// <returns>
		/// 	<c>true</c> if the specified character is punctuation; otherwise, <c>false</c>.
		/// </returns>
		private static bool IsPunctuation(char c)
		{
			switch (c)
			{
				case '.':
				case '!':
				case '?':
				case '\'':
				case '"':
				case ',':
				case '(':
				case ')':
				case '-':
				case '>':
				case '<':
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// Determines if the given character is whitespace.
		/// </summary>
		/// <param name="c">The c.</param>
		/// <returns>
		/// 	<c>true</c> if the specified character is whitespace; otherwise, <c>false</c>.
		/// </returns>
		private static bool IsWhitespace(char c)
		{
			switch (c)
			{
				case ' ':
					return true;
				default:
					return false;
			}
		}

		#endregion
	}
}
