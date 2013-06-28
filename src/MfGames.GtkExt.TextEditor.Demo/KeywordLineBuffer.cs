// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Collections.Generic;
using C5;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace GtkExtDemo.TextEditor
{
	/// <summary>
	/// Wraps around a line buffer and marks up anything with a number of keywords
	/// with Pango markup.
	/// </summary>
	public class KeywordLineBuffer: LineBufferDecorator
	{
		#region Methods

		/// <summary>
		/// Gets the line indicators for a given character range.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="startCharacterIndex">Start character in the line text.</param>
		/// <param name="endCharacterIndex">End character in the line text.</param>
		/// <returns>
		/// An enumerable with the indicators or <see langword="null"/> for
		/// none.
		/// </returns>
		public override IEnumerable<ILineIndicator> GetLineIndicators(
			int lineIndex,
			int startCharacterIndex,
			int endCharacterIndex)
		{
			// Get the escaped line markup.
			string text = GetLineText(lineIndex, LineContexts.None);

			endCharacterIndex = Math.Min(endCharacterIndex, text.Length);

			string partialText = text.Substring(
				startCharacterIndex, endCharacterIndex - startCharacterIndex);

			// Parse through the markup and get a list of entries. If we don't
			// get any out of this, return null.
			ArrayList<KeywordMarkupEntry> entries =
				KeywordMarkupEntry.ParseText(partialText);

			if (entries.Count == 0)
			{
				return null;
			}

			// Return the list of keyword entries which are also indicators.
			var indicators = new ArrayList<ILineIndicator>(entries.Count);

			indicators.AddAll(entries);

			return indicators;
		}

		/// <summary>
		/// Gets the Pango markup for a given line.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <returns></returns>
		public override string GetLineMarkup(
			int lineIndex,
			LineContexts lineContexts)
		{
			// Get the escaped line markup.
			string markup = base.GetLineMarkup(lineIndex, lineContexts);

			// Parse through the markup and get a list of entries. We go through
			// the list in reverse so we can use the character entries without
			// adjusting for the text we're adding.
			ArrayList<KeywordMarkupEntry> entries = KeywordMarkupEntry.ParseText(markup);

			entries.Reverse();

			foreach (KeywordMarkupEntry entry in entries)
			{
				// Insert the final span at the end.
				markup = markup.Insert(entry.EndCharacterIndex, "</span>");

				// Figure out the attributes.
				string attributes = string.Empty;

				switch (entry.Markup)
				{
					case KeywordMarkupType.Error:
						attributes = "underline='error' underline_color='red' color='red'";
						break;

					case KeywordMarkupType.Warning:
						attributes = "underline='error' underline_color='orange' color='orange'";
						break;
				}

				// Add in the attributes for the start index.
				markup = markup.Insert(
					entry.StartCharacterIndex, "<span " + attributes + ">");
			}

			// Return the resulting markup.
			return markup;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="KeywordLineBuffer"/> class.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		public KeywordLineBuffer(LineBuffer buffer)
			: base(buffer)
		{
		}

		#endregion
	}
}
