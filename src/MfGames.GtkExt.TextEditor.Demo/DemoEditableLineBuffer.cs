// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace GtkExtDemo.TextEditor
{
	/// <summary>
	/// Implements a demo editable buffer that is intended to be styled and
	/// formatted.
	/// </summary>
	public class DemoEditableLineBuffer: MemoryLineBuffer
	{
		#region Methods

		/// <summary>
		/// Gets the name of the line style based on the settings.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer or
		/// Int32.MaxValue for the last line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public override string GetLineStyleName(
			int lineIndex,
			LineContexts lineContexts)
		{
			// See if we have the line in the styles.
			var lineType = DemoLineStyleType.Default;

			if (styles.ContainsKey(lineIndex))
			{
				// If this is a heading line, and it has no value, and it is
				// not the current line, we color it differently to make it
				// obvious we are adding dynamic data.
				lineType = styles[lineIndex];

				if (lineType == DemoLineStyleType.Heading
					&& base.GetLineLength(lineIndex, LineContexts.None) == 0)
				{
					return "Inactive Heading";
				}
			}

			// If we are a default and the text is blank, we have a break.
			if (lineType == DemoLineStyleType.Default
				&& GetLineText(lineIndex).Trim().Length == 0)
			{
				lineType = DemoLineStyleType.Break;
			}

			// Otherwise, return the normal style name.
			return lineType.ToString();
		}

		public override string GetLineText(
			int lineIndex,
			LineContexts lineContexts)
		{
			// If we have a request for unformatted, return it directly.
			if ((lineContexts & LineContexts.Unformatted) == LineContexts.Unformatted)
			{
				return base.GetLineText(lineIndex, lineContexts);
			}

			// Get the style of the line, defaulting to default if we don't have
			// it in the hash.
			var lineType = DemoLineStyleType.Default;
			int lineLength = base.GetLineLength(lineIndex, LineContexts.Unformatted);

			if (styles.ContainsKey(lineIndex))
			{
				// If this is a heading line, and it has no value, and it is
				// not the current line, we put in different text for a
				// placeholder.
				lineType = styles[lineIndex];

				if (lineType == DemoLineStyleType.Heading
					&& lineLength == 0)
				{
					return "<Heading>";
				}
			}

			// Check to see if we are default with no text.
			if (lineType == DemoLineStyleType.Default
				&& lineLength == 0)
			{
				return "\u25E6 \u25E6 \u25E6";
			}

			// We don't have a special case, so just return the base.
			return base.GetLineText(lineIndex, lineContexts);
		}

		public override LineBufferOperationResults DeleteLines(int lineIndex,int count)
		{
			// First start by removing all the styles of the lines we're deleting.
			for(int index = lineIndex;
				index < lineIndex + count;
				index++)
			{
				styles.Remove(index);
			}

			// Now move all styles from the existing lines.
			for (int index = lineIndex + count;
				index < LineCount;
				index++)
			{
				int newIndex = index - count;

				if (styles.ContainsKey(index))
				{
					styles[newIndex] = styles[index];
					styles.Remove(index);
				}
			}

			// Call the base implementation to move everything else.
				return base.DeleteLines(lineIndex,count);
		}

		public override LineBufferOperationResults InsertLines(int lineIndex,int count)
		{
			// We need to adjust the line indexes above this line.
			for (int index = LineCount;
				index >= lineIndex;
				index--)
			{
				if (styles.ContainsKey(index))
				{
					styles[index + count] = styles[index];
					styles.Remove(index);
				}
			}

			// Call the base implementation to move everything else.
			return base.InsertLines(lineIndex,count);
		}

		/// <summary>
		/// Trims and removes duplicate spaces from the line.
		/// </summary>
		/// <param name="operation">The operation.</param>
		/// <returns></returns>
		protected override LineBufferOperationResults Do(ExitLineOperation operation)
		{
			// Get the line in question.
			string lineText = GetLineText(operation.LineIndex);

			// Perform clean up operations on the line to see if it changed.
			string newText = removeExcessiveSpaces.Replace(lineText.Trim(), " ");

			// If the text isn't the same, update the line.
			if (lineText != newText)
			{
				SetText(operation.LineIndex, newText);
			}

			// Return an empty operation results.
			return new LineBufferOperationResults();
		}

		/// <summary>
		/// Performs the set text operation on the buffer.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		protected override LineBufferOperationResults Do(SetTextOperation operation)
		{
			LineBufferOperationResults results = base.Do(operation);

			return CheckForStyleChanged(operation.LineIndex, results);
		}

		/// <summary>
		/// Performs the given operation on the line buffer. This will raise any
		/// events that were appropriate for the operation.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		protected override LineBufferOperationResults Do(
			InsertTextOperation operation)
		{
			LineBufferOperationResults results = base.Do(operation);

			return CheckForStyleChanged((int) operation.BufferPosition.Line, results);
		}

		/// <summary>
		/// Deletes text from the buffer.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		protected override LineBufferOperationResults Do(
			DeleteTextOperation operation)
		{
			LineBufferOperationResults results = base.Do(operation);

			return CheckForStyleChanged(operation.LineIndex, results);
		}

		/// <summary>
		/// Performs the insert lines operation on the buffer.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		protected override LineBufferOperationResults Do(
			InsertLinesOperation operation)
		{
			// First shift the style lines up for the new ones. We go from the
			// bottom to avoid overlapping the line numbers.
			for (int lineIndex = LineCount - 1;
				lineIndex >= 0;
				lineIndex--)
			{
				// If we have a key, shift it.
				if (lineIndex >= operation.LineIndex
					&& styles.ContainsKey(lineIndex))
				{
					styles[lineIndex + operation.Count] = styles[lineIndex];
					styles.Remove(lineIndex);
				}
			}

			// Now, perform the operation on the buffer.
			return base.Do(operation);
		}

		/// <summary>
		/// Performs the delete lines operation on the buffer.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		protected override LineBufferOperationResults Do(
			DeleteLinesOperation operation)
		{
			// Shift the styles down for the deleted lines.
			for (int lineIndex = 0;
				lineIndex < LineCount;
				lineIndex++)
			{
				// If we have a key, shift it.
				if (lineIndex >= operation.Line
					&& styles.ContainsKey(lineIndex))
				{
					styles[lineIndex - operation.Count] = styles[lineIndex];
					styles.Remove(lineIndex);
				}
			}

			// Now, perform the operation on the buffer.
			return base.Do(operation);
		}

		/// <summary>
		/// Checks to see if a line operation caused a style to change.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="results">The results.</param>
		/// <returns></returns>
		private LineBufferOperationResults CheckForStyleChanged(
			int lineIndex,
			LineBufferOperationResults results)
		{
			// Look to see if the line starts with a style change keyword.
			string line = GetLineText(lineIndex);

			if (line.Length < 2
				|| line.Substring(1, 1) != ":")
			{
				// We don't have a style change, so just return the results.
				return results;
			}

			// Check to see if we have a style change prefix.
			bool changed = false;

			switch (Char.ToUpper(line[0]))
			{
				case 'T':
					styles.Remove(lineIndex);
					changed = true;
					break;

				case 'B':
					styles[lineIndex] = DemoLineStyleType.Borders;
					changed = true;
					break;

				case 'C':
					styles[lineIndex] = DemoLineStyleType.Chapter;
					changed = true;
					break;

				case 'H':
					styles[lineIndex] = DemoLineStyleType.Heading;
					changed = true;
					break;
			}

			// If we didn't change anything, then just return the unaltered
			// results.
			if (!changed)
			{
				return results;
			}

			// Figure out what the line would look like without the prefix.
			string newLine = line.Substring(2).TrimStart(' ');
			int difference = line.Length - newLine.Length;

			// Set the line text.
			SetText(lineIndex, newLine);

			// Adjust the buffer position and return it.
			results.BufferPosition = new BufferPosition(
				results.BufferPosition.LineIndex,
				Math.Max(0, results.BufferPosition.CharacterIndex - difference));

			return results;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes the <see cref="DemoEditableLineBuffer"/> class.
		/// </summary>
		static DemoEditableLineBuffer()
		{
			removeExcessiveSpaces = new Regex(@"\s+", RegexOptions.Singleline);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DemoEditableLineBuffer"/> class.
		/// </summary>
		public DemoEditableLineBuffer()
		{
			// Set up the line styles.
			styles = new Dictionary<int, DemoLineStyleType>();

			// Create the initial lines. There is already one in the buffer before
			// this insert operates.
			var lines = new[]
			{
				"C: Moonfire Games Gtk# Text Editor",
				"T: Welcome to the text " + "editor demo.", "H: Changing Styles",
				"T: If you prefix a line with 'T:', 'H:', 'C:', or 'B:', it will "
					+ "change the style of the line without using the mouse.",
				"H: Markup",
				"T: The words 'error' and 'warning' are indicated with lines "
					+ "underneath them. In addition, both warnings and errors show "
					+ "up on the indicator bar on the right side of the window.",
			};

			// Set the text on the lines with the prefix so they can be styled
			// as part of the set operation.
			InsertLines(0, lines.Length);

			for (int lineIndex = 0;
				lineIndex < lines.Length;
				lineIndex++)
			{
				SetText(lineIndex, lines[lineIndex]);
			}
		}

		#endregion

		#region Fields

		/// <summary>
		/// Contains a regular expression for finding multiple spaces.
		/// </summary>
		private static readonly Regex removeExcessiveSpaces;

		private readonly Dictionary<int, DemoLineStyleType> styles;

		#endregion
	}
}
