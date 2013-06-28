// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using C5;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace GtkExtDemo.TextEditor
{
	/// <summary>
	/// Defines a single range of markup in a text buffer.
	/// </summary>
	public class KeywordMarkupEntry: IComparable<KeywordMarkupEntry>,
		ILineIndicator
	{
		#region Properties

		/// <summary>
		/// Gets or sets the end of the markup.
		/// </summary>
		/// <value>The end index of the character.</value>
		public int EndCharacterIndex { get; set; }

		/// <summary>
		/// Gets the style used to draw the line indicator.
		/// </summary>
		/// <value>The line indicator style.</value>
		public string LineIndicatorStyle
		{
			get { return Markup.ToString(); }
		}

		/// <summary>
		/// Gets or sets the type of markup.
		/// </summary>
		/// <value>The markup.</value>
		public KeywordMarkupType Markup { get; set; }

		/// <summary>
		/// Gets or sets the start of the markup.
		/// </summary>
		/// <value>The start index of the character.</value>
		public int StartCharacterIndex { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects
		/// being compared. The return value has the following meanings: Value Meaning
		/// Less than zero This object is less than the <paramref name="other"/>
		/// parameter.Zero This object is equal to <paramref name="other"/>. Greater
		/// than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(KeywordMarkupEntry other)
		{
			return StartCharacterIndex.CompareTo(other.StartCharacterIndex);
		}

		/// <summary>
		/// Parses the text and produces a list of markup entries for that text.
		/// This guarantees that there is no overlapping markup and no duplicated
		/// tags. This is also sorted so the first comes in the beginning.
		/// </summary>
		/// <param name="inputText">The input text.</param>
		/// <returns></returns>
		public static ArrayList<KeywordMarkupEntry> ParseText(string inputText)
		{
			// Create a linked list of markups.
			var entries = new ArrayList<KeywordMarkupEntry>();

			// Parse the various keywords used as defaults. We do case-insenstive
			// searching to make everything uppercase.
			string upper = inputText.ToUpperInvariant();

			ParseText(upper, entries, "ERROR", KeywordMarkupType.Error);
			ParseText(upper, entries, "WARNING", KeywordMarkupType.Warning);

			// Return the resulting list.
			entries.Sort();
			return entries;
		}

		/// <summary>
		/// Parses the text for a given search string and adds those entries
		/// into the list if they don't exist already.
		/// </summary>
		/// <param name="inputText">The input text.</param>
		/// <param name="entries">The entries.</param>
		/// <param name="search">The search.</param>
		/// <param name="markup">The markup.</param>
		private static void ParseText(
			string inputText,
			IExtensible<KeywordMarkupEntry> entries,
			string search,
			KeywordMarkupType markup)
		{
			// Start at the beginning and find all instances of the keyword.
			int startIndex = 0;

			while (startIndex <= inputText.Length)
			{
				// Look for the next occurance of the keyword.
				int searchIndex = inputText.IndexOf(search, startIndex);

				if (searchIndex < 0)
				{
					// We didn't find any more, so we're done.
					return;
				}

				// Create an entry for that element.
				var entry = new KeywordMarkupEntry();
				entry.StartCharacterIndex = searchIndex;
				entry.EndCharacterIndex = searchIndex + search.Length;
				entry.Markup = markup;

				// Look through the entries and see if we have an identical one
				// already.
				bool found = false;

				foreach (KeywordMarkupEntry existingEntry in entries)
				{
					if (existingEntry.StartCharacterIndex == entry.StartCharacterIndex)
					{
						found = true;
						break;
					}
				}

				// If we haven't found it, then add it.
				if (!found)
				{
					entries.Add(entry);
				}

				// Shift the start index past this term.
				startIndex = searchIndex + 1;
			}
		}

		#endregion
	}
}
