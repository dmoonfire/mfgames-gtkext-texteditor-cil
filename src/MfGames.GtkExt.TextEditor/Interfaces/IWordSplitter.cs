// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Interfaces
{
	/// <summary>
	/// Interface that identifies the boundaries between words.
	/// </summary>
	public interface IWordSplitter
	{
		#region Methods

		/// <summary>
		/// Gets the next word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns>The character index of the next word or Int32.MaxValue if one
		/// cannot be found.</returns>
		int GetNextWordBoundary(
			string text,
			int characterIndex);

		/// <summary>
		/// Gets the previous word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		int GetPreviousWordBoundary(
			string text,
			int characterIndex);

		#endregion
	}
}
