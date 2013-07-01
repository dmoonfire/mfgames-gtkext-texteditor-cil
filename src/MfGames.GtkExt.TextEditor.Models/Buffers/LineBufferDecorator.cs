// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Abstract class which wraps around a <see cref="LineBuffer"/> and allows for
	/// overriding of various methods and properties. This implementation simply
	/// calls the underlying <see cref="LineBuffer"/>.
	/// </summary>
	public abstract class LineBufferDecorator: LineBuffer
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines in the buffer.
		/// </summary>
		/// <value>The line count.</value>
		public override int LineCount
		{
			get { return LineBuffer.LineCount; }
		}

		/// <summary>
		/// If set to <see langword="true"/>, the buffer is read-only and the editing
		/// commands should throw an <see cref="InvalidOperationException"/>.
		/// </summary>
		public override bool ReadOnly
		{
			get { return LineBuffer.ReadOnly; }
		}

		/// <summary>
		/// Gets the underlying buffer for this proxy.
		/// </summary>
		/// <value>The buffer.</value>
		protected LineBuffer LineBuffer
		{
			[DebuggerStepThrough] get { return lineBuffer; }
		}

		#endregion

		#region Methods

		public override LineBufferOperationResults DeleteLines(
			int lineIndex,
			int count)
		{
			LineBufferOperationResults results = LineBuffer.DeleteLines(lineIndex, count);
			return results;
		}

		/// <summary>
		/// Performs the given operation on the line buffer. This will raise any
		/// events that were appropriate for the operation.
		/// </summary>
		/// <param name="operation">The operation to perform.</param>
		/// <returns>
		/// The results to the changes to the buffer.
		/// </returns>
		public override LineBufferOperationResults Do(ILineBufferOperation operation)
		{
			return LineBuffer.Do(operation);
		}

		/// <summary>
		/// Gets the length of the line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>The length of the line.</returns>
		public override int GetLineLength(
			int lineIndex,
			LineContexts lineContexts)
		{
			return LineBuffer.GetLineLength(lineIndex, lineContexts);
		}

		/// <summary>
		/// Gets the Pango markup for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer or Int32.MaxValue for
		/// the last line.</param>
		/// <returns></returns>
		public override string GetLineMarkup(
			int lineIndex,
			LineContexts lineContexts)
		{
			return LineBuffer.GetLineMarkup(lineIndex, lineContexts);
		}

		/// <summary>
		/// Gets the formatted line number for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>A formatted line number.</returns>
		public override string GetLineNumber(int lineIndex)
		{
			return LineBuffer.GetLineNumber(lineIndex);
		}

		/// <summary>
		/// Gets the name of the line style associated with this line. If the
		/// default style is desired, then this can return <see langword="null"/>. Otherwise, it
		/// has to be a name of an existing style. If this returns a style name
		/// that doesn't exist, then an exception will be thrown.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer or Int32.MaxValue for
		/// the last line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		[DebuggerStepThrough]
		public override string GetLineStyleName(
			int lineIndex,
			LineContexts lineContexts)
		{
			return LineBuffer.GetLineStyleName(lineIndex, lineContexts);
		}

		/// <summary>
		/// Gets the text of a given line in the buffer.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer. If the index is beyond the end of the buffer, the last line is used.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public override string GetLineText(
			int lineIndex,
			LineContexts lineContexts)
		{
			return LineBuffer.GetLineText(lineIndex, lineContexts);
		}

		public override LineBufferOperationResults InsertLines(
			int lineIndex,
			int count)
		{
			return LineBuffer.InsertLines(lineIndex, count);
		}

		public override LineBufferOperationResults InsertText(
			int lineIndex,
			int characterIndex,
			string text)
		{
			return LineBuffer.InsertText(lineIndex, characterIndex, text);
		}

		private void OnLineChanged(
			object sender,
			LineChangedArgs e)
		{
			RaiseLineChanged(e);
		}

		private void OnLinesDeleted(
			object sender,
			LineRangeEventArgs e)
		{
			RaiseLinesDeleted(e);
		}

		private void OnLinesInserted(
			object sender,
			LineRangeEventArgs e)
		{
			RaiseLinesInserted(e);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineBufferDecorator"/> class.
		/// </summary>
		/// <param name="lineBuffer">The buffer.</param>
		protected LineBufferDecorator(LineBuffer lineBuffer)
		{
			if (lineBuffer == null)
			{
				throw new ArgumentNullException("lineBuffer");
			}

			this.lineBuffer = lineBuffer;
			this.lineBuffer.LineChanged += OnLineChanged;
			this.lineBuffer.LinesInserted += OnLinesInserted;
			this.lineBuffer.LinesDeleted += OnLinesDeleted;
		}

		#endregion

		#region Fields

		private readonly LineBuffer lineBuffer;

		#endregion
	}
}
