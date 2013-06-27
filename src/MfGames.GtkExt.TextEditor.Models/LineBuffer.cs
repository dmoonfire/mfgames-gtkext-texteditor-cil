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
	/// Represents a virtual collection of lines for viewing and
	/// editing.
	/// </summary>
	public abstract class LineBuffer
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines in the buffer.
		/// </summary>
		/// <value>The line count.</value>
		public abstract int LineCount { get; }

		/// <summary>
		/// If set to <see langword="true"/>, the buffer is read-only and the editing
		/// commands should throw an <see cref="InvalidOperationException"/>.
		/// </summary>
		public abstract bool ReadOnly { get; }

		#endregion

		#region Events

		/// <summary>
		/// Used to indicate that a line changed.
		/// </summary>
		public event EventHandler<LineChangedArgs> LineChanged;

		/// <summary>
		/// Occurs when lines are inserted into the buffer.
		/// </summary>
		public event EventHandler<LineRangeEventArgs> LinesDeleted;

		/// <summary>
		/// Occurs when lines are inserted into the buffer.
		/// </summary>
		public event EventHandler<LineRangeEventArgs> LinesInserted;

		#endregion

		#region Methods

		/// <summary>
		/// Deletes the lines inside the line buffer.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="count">The number of lines to delete.</param>
		public abstract LineBufferOperationResults DeleteLines(
			int lineIndex,
			int count);

		/// <summary>
		/// Deletes the text from the buffer using a <see cref="DeleteTextOperation"/>.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="startCharacterIndex">Start index of the character.</param>
		/// <param name="endCharacterIndex">End index of the character.</param>
		/// <returns></returns>
		public LineBufferOperationResults DeleteText(
			int lineIndex,
			int startCharacterIndex,
			int endCharacterIndex)
		{
			return DeleteText(
				lineIndex, new CharacterRange(startCharacterIndex, endCharacterIndex));
		}

		/// <summary>
		/// Deletes the text from the buffer using a <see cref="DeleteTextOperation"/>.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public LineBufferOperationResults DeleteText(
			BufferPosition bufferPosition,
			int length)
		{
			return Do(new DeleteTextOperation(bufferPosition, length));
		}

		/// <summary>
		/// Deletes the text from the buffer using a <see cref="DeleteTextOperation"/>.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="characterRange">The character range.</param>
		/// <returns></returns>
		public LineBufferOperationResults DeleteText(
			int lineIndex,
			CharacterRange characterRange)
		{
			return Do(new DeleteTextOperation(lineIndex, characterRange));
		}

		/// <summary>
		/// Performs the given operation on the line buffer. This will raise any
		/// events that were appropriate for the operation.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>The results to the changes to the buffer.</returns>
		public abstract LineBufferOperationResults Do(ILineBufferOperation operation);

		/// <summary>
		/// Exits the line using a <see cref="ExitLineOperation"/>.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <returns></returns>
		public LineBufferOperationResults ExitLine(int lineIndex)
		{
			return Do(new ExitLineOperation(lineIndex));
		}

		/// <summary>
		/// Gets the line indicators for a given character range.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="startCharacterIndex">Start character in the line text.</param>
		/// <param name="endCharacterIndex">End character in the line text.</param>
		/// <returns></returns>
		public virtual IEnumerable<ILineIndicator> GetLineIndicators(
			int lineIndex,
			int startCharacterIndex,
			int endCharacterIndex)
		{
			return new List<ILineIndicator>();
		}

		/// <summary>
		/// Gets the line indicators for the entire line.
		/// </summary>
		public IEnumerable<ILineIndicator> GetLineIndicators(int lineIndex)
		{
			return GetLineIndicators(lineIndex, 0, Int32.MaxValue);
		}

		/// <summary>
		/// Gets the length of the line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns>The length of the line.</returns>
		public abstract int GetLineLength(
			int lineIndex,
			LineContexts lineContexts);

		/// <summary>
		/// Gets the Pango markup for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer or Int32.MaxValue for
		/// the last line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public virtual string GetLineMarkup(
			int lineIndex,
			LineContexts lineContexts)
		{
			string text = GetLineText(lineIndex, LineContexts.None);

			return PangoUtility.Escape(text);
		}

		/// <summary>
		/// Gets the formatted line number for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>A formatted line number.</returns>
		public abstract string GetLineNumber(int lineIndex);

		/// <summary>
		/// Gets the name of the line style associated with this line. If the
		/// default style is desired, then this can return
		/// <see langword="null"/>. Otherwise, it has to be a name of an
		/// existing style. If this returns a style name that doesn't exist,
		/// then an exception will be thrown.
		/// 
		/// Styles that are for different context, but the same name, cannot
		/// change the size of the line. This means they need to have the same
		/// font and size. Otherwise, some of the wrap routines will fail to
		/// work properly.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer or
		/// Int32.MaxValue for the last line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public virtual string GetLineStyleName(
			int lineIndex,
			LineContexts lineContexts)
		{
			return null;
		}

		/// <summary>
		/// Gets the text for a specific line.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public abstract string GetLineText(
			int lineIndex,
			LineContexts lineContexts);

		public string GetLineText(
			LinePosition line,
			LineContexts lineContexts)
		{
			string results = GetLineText((int) line, lineContexts);
			return results;
		}

		/// <summary>
		/// Inserts a line inside the line buffer.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="count">The count.</param>
		public abstract LineBufferOperationResults InsertLines(
			int lineIndex,
			int count);

		/// <summary>
		/// Inserts the text into a line.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <param name="text">The text.</param>
		public abstract LineBufferOperationResults InsertText(
			int lineIndex,
			int characterIndex,
			string text);

		/// <summary>
		/// Inserts the text using a <see cref="InsertTextOperation"/>.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="text">The text.</param>
		public LineBufferOperationResults InsertText(
			BufferPosition bufferPosition,
			string text)
		{
			return
				Do(
					new InsertTextOperation(
						bufferPosition.LineIndex, bufferPosition.CharacterIndex, text));
		}

		/// <summary>
		/// Normalizes the index of the line and makes sure nothing is beyond
		/// the limits.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <returns></returns>
		public int NormalizeLineIndex(int lineIndex)
		{
			return Math.Min(LineCount - 1, lineIndex);
		}

		/// <summary>
		/// Sets the text using a <see cref="SetTextOperation"/>.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="text">The text.</param>
		public LineBufferOperationResults SetText(
			int lineIndex,
			string text)
		{
			return Do(new SetTextOperation(lineIndex, text));
		}

		public void SetText(
			LinePosition line,
			string text)
		{
			SetText((int) line, text);
		}

		/// <summary>
		/// Raises the <see cref="LineChanged"/> event
		/// </summary>
		/// <param name="e">The e.</param>
		protected virtual void RaiseLineChanged(LineChangedArgs e)
		{
			EventHandler<LineChangedArgs> listeners = LineChanged;

			if (listeners != null)
			{
				listeners(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="LinesDeleted"/> event.
		/// </summary>
		/// <param name="e">The e.</param>
		protected virtual void RaiseLinesDeleted(LineRangeEventArgs e)
		{
			EventHandler<LineRangeEventArgs> listeners = LinesDeleted;

			if (listeners != null)
			{
				listeners(this, e);
			}
		}

		/// <summary>
		/// Raises the <see cref="LinesInserted"/> event.
		/// </summary>
		/// <param name="e">The e.</param>
		protected virtual void RaiseLinesInserted(LineRangeEventArgs e)
		{
			EventHandler<LineRangeEventArgs> listeners = LinesInserted;

			if (listeners != null)
			{
				listeners(this, e);
			}
		}

		#endregion
	}
}
