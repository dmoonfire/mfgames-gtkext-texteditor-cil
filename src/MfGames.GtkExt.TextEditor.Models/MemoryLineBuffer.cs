// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Collections.Generic;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace MfGames.GtkExt.TextEditor.Models
{
	/// <summary>
	/// Implements a line buffer that keeps all the lines in memory.
	/// </summary>
	public class MemoryLineBuffer: MultiplexedOperationLineBuffer
	{
		#region Properties

		/// <summary>
		/// Gets the line count.
		/// </summary>
		/// <value>The line count.</value>
		public override int LineCount
		{
			get { return lines.Count; }
		}

		/// <summary>
		/// If set to <see langword="true"/>, the buffer is read-only and the editing commands
		/// should throw an <see cref="InvalidOperationException"/>.
		/// </summary>
		public override bool ReadOnly
		{
			get { return readOnly; }
		}

		#endregion

		#region Methods

		public override LineBufferOperationResults DeleteLines(
			int lineIndex,
			int count)
		{
			// Delete the lines from the buffer.
			lines.RemoveRange(lineIndex, count);

			// Fire an delete line change.
			RaiseLinesDeleted(new LineRangeEventArgs(lineIndex, lineIndex + count - 1));

			// Return the appropriate results.
			return new LineBufferOperationResults(new TextPosition(lineIndex, 0));
		}

		/// <summary>
		/// Gets the length of the line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns>The length of the line.</returns>
		public override int GetLineLength(
			int lineIndex,
			LineContexts lineContexts)
		{
			return lines[lineIndex].Length;
		}

		/// <summary>
		/// Gets the formatted line number for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>A formatted line number.</returns>
		public override string GetLineNumber(int lineIndex)
		{
			// Line numbers are given as 1-based instead of 0-based.
			return (lineIndex + 1).ToString("N0");
		}

		/// <summary>
		/// Gets the line without any manipulations.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <returns></returns>
		public string GetLineText(int lineIndex)
		{
			return lines[lineIndex];
		}

		public override string GetLineText(
			int lineIndex,
			LineContexts lineContexts)
		{
			string text = lines[lineIndex];
			return text;
		}

		public override LineBufferOperationResults InsertLines(
			int lineIndex,
			int count)
		{
			// Insert the new lines into the buffer.
			for (int index = 0;
				index < count;
				index++)
			{
				lines.Insert(lineIndex, string.Empty);
			}

			// Fire an insert line change.
			RaiseLinesInserted(new LineRangeEventArgs(lineIndex, lineIndex + count - 1));

			// Return the appropriate results.
			return
				new LineBufferOperationResults(new TextPosition(lineIndex + count, 0));
		}

		public override LineBufferOperationResults InsertText(
			int lineIndex,
			int characterIndex,
			string text)
		{
			// Get the text from the buffer, insert the text, and put it back.
			string line = lines[lineIndex];

			characterIndex = Math.Min(characterIndex, line.Length);

			string newLine = line.Insert(characterIndex, text);

			lines[lineIndex] = newLine;

			// Fire a line changed operation.
			RaiseLineChanged(new LineChangedArgs(lineIndex));

			// Return the appropriate results.
			return
				new LineBufferOperationResults(
					new TextPosition(lineIndex, characterIndex + text.Length));
		}

		/// <summary>
		/// Sets the read only flag on the buffer.
		/// </summary>
		/// <param name="newReadOnly">if set to <c>true</c> [read only].</param>
		public void SetReadOnly(bool newReadOnly)
		{
			readOnly = newReadOnly;
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
			throw new NotImplementedException();
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
			// Get the text from the buffer, insert the text, and put it back.
			int lineIndex = operation.TextRange.LinePosition.GetLineIndex(lines.Count);
			string lineText = lines[lineIndex];
			int startCharacterIndex =
				operation.TextRange.BeginCharacterPosition.GetCharacterIndex(
					lineText, operation.TextRange.EndCharacterPosition, WordSearchDirection.Left);
			int endCharacterIndex =
				operation.TextRange.EndCharacterPosition.GetCharacterIndex(
					lineText,
					operation.TextRange.BeginCharacterPosition,
					WordSearchDirection.Right);

			string newLine = lineText.Remove(
				startCharacterIndex, endCharacterIndex - startCharacterIndex);

			lines[lineIndex] = newLine;

			// Fire a line changed operation.
			RaiseLineChanged(new LineChangedArgs(lineIndex));

			// Return the appropriate results.
			return
				new LineBufferOperationResults(operation.TextRange.BeginTextPosition);
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
			// Set the text of the line.
			lines[operation.LineIndex] = operation.Text;

			// Fire a line changed operation.
			RaiseLineChanged(new LineChangedArgs(operation.LineIndex));

			// Return the appropriate results.
			return
				new LineBufferOperationResults(
					new TextPosition(operation.LineIndex, lines[operation.LineIndex].Length));
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MemoryLineBuffer"/> class.
		/// </summary>
		public MemoryLineBuffer()
		{
			lines = new List<string>();
			lines.Add(string.Empty);
		}

		/// <summary>
		/// Copies the given buffer into a memory buffer.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		public MemoryLineBuffer(LineBuffer buffer)
		{
			int lineCount = buffer.LineCount;

			lines = new List<string>(lineCount);

			for (int line = 0;
				line < lineCount;
				line++)
			{
				lines.Add(buffer.GetLineText(line, LineContexts.None));
			}
		}

		#endregion

		#region Fields

		private readonly List<string> lines;

		private bool readOnly;

		#endregion
	}
}
