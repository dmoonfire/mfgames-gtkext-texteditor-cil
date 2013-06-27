// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Text;
using MfGames.GtkExt.TextEditor.Models;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// Utility class for taking Pango markup and applying a selection to it.
	/// </summary>
	public class SelectionRenderer
	{
		#region Methods

		/// <summary>
		/// Takes the given string (which assumes a valid Pango markup) and
		/// adds the markup to apply a selection to the string.
		/// </summary>
		/// <param name="pangoMarkup">The Pango markup to apply the selection.</param>
		/// <param name="characters">The range of character to select.</param>
		/// <returns>A Pango markup string with the selection applied.</returns>
		public string GetSelectionMarkup(
			string pangoMarkup,
			CharacterRange characters)
		{
			return GetSelectionMarkup(
				pangoMarkup, characters, "span", " background='#CCCCFF'");
		}

		/// <summary>
		/// Takes the given string (which assumes a valid Pango markup) and
		/// adds the markup to apply a selection to the string.
		/// </summary>
		/// <param name="markup">The markup.</param>
		/// <param name="characters">The range of character to select.</param>
		/// <param name="selectionTag">The selection tag to use.</param>
		/// <param name="selectionAttributes">The selection attributes to use.</param>
		/// <returns>
		/// A Pango markup string with the selection applied.
		/// </returns>
		public string GetSelectionMarkup(
			string markup,
			CharacterRange characters,
			string selectionTag,
			string selectionAttributes)
		{
			// Check for nulls and invalid strings.
			if (String.IsNullOrEmpty(markup))
			{
				// We can't really do anything with this.
				return markup;
			}

			// If the selection covers the entire string, we have an optimized
			// case and we can just return a selection that covers the entire
			// string.
			if (characters.StartIndex == 0
				&& characters.EndIndex == markup.Length)
			{
				return string.Format(
					"<{0}{1}>{2}</{3}>",
					selectionTag,
					selectionAttributes,
					markup,
					selectionTag);
			}

			// The primary concern for applying the selection is that we already
			// have Pango markup in the string and we have to maintain that
			// markup while adjusting it. Pango doesn't allow for non-XML rules
			// such as nested spans, so we go through the string and keep track
			// of the spans as they apply. When we get to the selection, we
			// disable those spans and replace them with ones of our own.
			//
			// In addition, the character range does not apply to entities such
			// as &amp; so the entity is treated as a single string.

			// To start with, we need to get the index in the string for the
			// selection.
			int startIndex,
				endIndex,
				leadingXmlDepth,
				leadingXmlIndex,
				trailingXmlDepth;

			GetMarkupIndexes(
				markup,
				characters,
				out startIndex,
				out endIndex,
				out leadingXmlDepth,
				out leadingXmlIndex,
				out trailingXmlDepth);

			// If we have a startIndex of -1, that means that the selection is
			// the end of the line and we have nothing.
			if (startIndex < 0)
			{
				return markup;
			}

			// Use a string builder and build up the selection markup, this way
			// we avoid as much object creation as possible.
			var buffer = new StringBuilder();

			// Add in all the text before the selection.
			string leadingMarkup = markup.Substring(0, startIndex);

			buffer.Append(leadingMarkup);

			// Get all the tags that were opened at the point the selection
			// starts and close them.
			TagInfo[] leadingTags = null;

			if (leadingXmlDepth > 0)
			{
				// Allocate space equal to the depth since we won't get any
				// larger than that.
				leadingTags = new TagInfo[leadingXmlDepth];

				// Get all the tags in the leading markup.
				GetOpenTags(leadingMarkup, leadingXmlIndex, startIndex, 0, ref leadingTags);

				// Close all the leading tags in reverse order.
				for (int index = leadingXmlDepth - 1;
					index >= 0;
					index--)
				{
					buffer.AppendFormat("</{0}>", leadingTags[index].Name);
				}
			}

			// Add the selection tag itself.
			buffer.AppendFormat("<{0}{1}>", selectionTag, selectionAttributes);

			// Open up the tags that were open before the selection.
			if (leadingTags != null)
			{
				// Close all the leading tags in reverse order.
				for (int index = 0;
					index < leadingXmlDepth;
					index++)
				{
					buffer.Append(leadingTags[index].ToString());
				}
			}

			// Add in the text inside the selection.
			string innerSelectionMarkup = markup.Substring(
				startIndex, endIndex - startIndex);

			buffer.Append(innerSelectionMarkup);

			// Get the tags that were inside the selection so we can close them.
			TagInfo[] trailingTags = null;

			if (trailingXmlDepth > 0)
			{
				// Allocate space equal to the depth since we won't get any
				// larger than that.
				trailingTags = new TagInfo[trailingXmlDepth];

				// Copy in any of the tags from the leading to fill the space.
				if (leadingTags != null)
				{
					int total = Math.Min(trailingXmlDepth, leadingXmlDepth);

					for (int index = 0;
						index < total;
						index++)
					{
						trailingTags[index] = leadingTags[index];
					}
				}

				// Get all the tags in the leading markup.
				GetOpenTags(
					innerSelectionMarkup,
					0,
					endIndex - startIndex,
					leadingXmlDepth,
					ref trailingTags);

				// Close all the leading tags in reverse order.
				for (int index = trailingXmlDepth - 1;
					index >= 0;
					index--)
				{
					buffer.AppendFormat("</{0}>", trailingTags[index].Name);
				}
			}

			// Close the selection tag.
			buffer.AppendFormat("</{0}>", selectionTag);

			// Open up the tags that were open before the selection ended.
			if (trailingTags != null)
			{
				// Close all the leading tags in reverse order.
				for (int index = 0;
					index < trailingXmlDepth;
					index++)
				{
					buffer.Append(trailingTags[index].ToString());
				}
			}

			// Add everything after the markup.
			buffer.Append(markup.Substring(endIndex));

			// Combine the list together and return it.
			string selectionMarkup = buffer.ToString();

			return selectionMarkup;
		}

		/// <summary>
		/// Gets the indexes in the markup string for the given character range. This
		/// handles mapping attributes and entities as zero and one-length characters
		/// respectively. It also returns information to optimize the search for XML
		/// tags inside the Pango string.
		/// </summary>
		/// <param name="pangoMarkup">The pango markup.</param>
		/// <param name="characters">The characters.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <param name="leadingXmlDepth">The number of nested XML elements at the
		/// point of the
		/// <paramref name="startIndex"/>.
		/// <param name="leadingXmlIndex">
		/// The character index of the opening XML tag before the selection. If this
		/// -1 one, then there is no opening tag and
		/// <paramref name="leadingXmlDepth"/> will be zero.
		/// </param></param>
		/// <param name="leadingXmlIndex">Index of the leading XML.</param>
		/// <param name="trailingXmlDepth">The number of nested XML elements at the
		/// point the selection ends.</param>
		private static void GetMarkupIndexes(
			string pangoMarkup,
			CharacterRange characters,
			out int startIndex,
			out int endIndex,
			out int leadingXmlDepth,
			out int leadingXmlIndex,
			out int trailingXmlDepth)
		{
			// Because of how the loop works, we have to set the startIndex to
			// a sane default and only check to see if we found the endIndex.
			startIndex = -1;
			leadingXmlDepth = 0;
			trailingXmlDepth = 0;
			leadingXmlIndex = -1;

			// Check for the selection starting at the beginning.
			if (characters.StartIndex == 0)
			{
				startIndex = 0;
			}

			// Loop through the entire markup string. We keep track of two
			// indexes. The markupIndex is the index inside the markup string.
			// The character index is the logical characters, treating XML tags
			// as zero-width characters, and is used to match against characters.
			for (int markupIndex = 0,
				characterIndex = 0;
				markupIndex < pangoMarkup.Length;
				markupIndex++)
			{
				// Keep track of the starting markup index since we'll use that
				// to find the beginning of an XML tag or entity.
				int markupIndexAnchor = markupIndex;

				// Grab the character at this position.
				char c = pangoMarkup[markupIndex];

				// Use the character to determine if we have an entity or tag.
				switch (c)
				{
					case '&':
						// Treat the entire entity as a single character.
						while (c != ';')
						{
							markupIndex++;
							c = pangoMarkup[markupIndex];
						}

						// We don't include the final markupIndex because of
						// the for loop increment.

						break;

					case '<':
						// Grab the next character to see if we have an opening
						// or closing tag.
						markupIndex++;
						c = pangoMarkup[markupIndex];

						if (c == '/')
						{
							// If we are still looking for the start index,
							// process the leading elements.
							if (startIndex == -1)
							{
								// If we are closing the outer-most tag, then clear
								// the index since we don't need to process it.
								if (leadingXmlDepth == 1)
								{
									leadingXmlIndex = -1;
								}

								// Decrement the depth.
								leadingXmlDepth--;
							}

							// Decrement the depth of trailing.
							trailingXmlDepth--;
						}
						else
						{
							// If we are still looking for the start index,
							// process the leading elements.
							if (startIndex == -1)
							{
								// We need to first check to see if we are at
								// the selection point. If we are, then we want
								// to start before we open a new tag.
								if (characterIndex == characters.StartIndex)
								{
									// Save the start index for the selection.
									startIndex = markupIndexAnchor;
								}
								else
								{
									// Increment the depth of the tag.
									leadingXmlDepth++;

									// If we are the outer-most tag, then keep track
									// of the start index.
									if (leadingXmlDepth == 1)
									{
										leadingXmlIndex = markupIndexAnchor;
									}
								}
							}
							else if (characterIndex == characters.EndIndex)
							{
								// This is right before the selection ends.
								// Since this is an opening tag, we want to
								// stop here.
								endIndex = markupIndexAnchor;
								return;
							}

							// Increment the trailing XML depth.
							trailingXmlDepth++;
						}

						// Skip over the entire XML tag.
						while (c != '>')
						{
							markupIndex++;
							c = pangoMarkup[markupIndex];
						}

						// We continue since we want to treat XML tags as
						// zero-width characters.
						continue;
				}

				// Check to see if we have the start index.
				if (startIndex == -1
					&& characterIndex == characters.StartIndex)
				{
					startIndex = markupIndexAnchor;
				}

				// Check to see if we are done processing.
				if (characterIndex == characters.EndIndex)
				{
					endIndex = markupIndexAnchor;
					return;
				}

				// Increment the character index.
				characterIndex++;
			}

			// If we got this far, we hit the end of the line, so just mark the
			// end as the last character in the string.
			endIndex = pangoMarkup.Length;
		}

		/// <summary>
		/// Scans through the markup from the start to end index and gathers all the
		/// open tags at the point of the <paramref name="endIndex"/>.
		/// </summary>
		/// <param name="markup">The markup to scan through.</param>
		/// <param name="startIndex">The character start index.</param>
		/// <param name="endIndex">The character end index.</param>
		/// <param name="depth">The depth of the XML tags to start with.</param>
		/// <param name="tags">A reference to the open tags, this is already
		/// allocated.</param>
		private static void GetOpenTags(
			string markup,
			int startIndex,
			int endIndex,
			int depth,
			ref TagInfo[] tags)
		{
			// Loop through the markup from the start to stop index.
			for (int index = startIndex;
				index < endIndex;
				index++)
			{
				// Get the character at this point.
				char c = markup[index];

				// If we aren't an XML, we can skip it since the indexes are
				// given with entities and tag lengths already processed.
				if (c != '<')
				{
					continue;
				}

				// This is an XML tag, so first check to see if we have a closing
				// tag or not.
				index++;
				c = markup[index];

				if (c == '/')
				{
					// This is a closing tag, so we can just decrement the depth.
					depth--;
					continue;
				}

				// If the tag would be deeper than the depth, we already know it
				// will be closed before we parse it.
				if (depth >= tags.Length)
				{
					depth++;
					continue;
				}

				// We aren't a closing tag, so gather up the entire tag and split
				// it into the two components.
				var tag = new TagInfo();
				var buffer = new StringBuilder();
				bool inName = true;

				while (c != '>')
				{
					// If we are a space and we are processing the name, then
					// save the name and start processing the attributes.
					if (c == ' ' && inName)
					{
						inName = false;
						tag.Name = buffer.ToString();
						buffer.Length = 0;
					}

					// Add the character to the buffer.
					buffer.Append(c);

					// Advance the position in the string.
					index++;
					c = markup[index];
				}

				// Append the buffer to the appropriate place.
				if (inName)
				{
					tag.Name = buffer.ToString();
				}
				else
				{
					tag.Attributes = buffer.ToString();
				}

				// Set the tag in the array.
				tags[depth] = tag;
				depth++;
			}
		}

		#endregion

		#region Nested Type: TagInfo

		/// <summary>
		/// Contains information about a single tag in memory.
		/// </summary>
		private struct TagInfo
		{
			#region Methods

			public override string ToString()
			{
				return String.Format("<{0}{1}>", Name, Attributes);
			}

			#endregion

			#region Fields

			public string Attributes;
			public string Name;

			#endregion
		}

		#endregion
	}
}
