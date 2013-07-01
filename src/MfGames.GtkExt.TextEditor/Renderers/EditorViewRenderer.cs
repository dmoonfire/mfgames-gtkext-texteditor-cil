// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using Pango;
using Rectangle = Cairo.Rectangle;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// Functions as an adapter between the <see cref="LineBuffer"/> and the text
	/// editor to provide services for laying out text, wrapping words, and
	/// otherwise rendering the renderer.
	/// </summary>
	public abstract class EditorViewRenderer
	{
		#region Properties

		/// <summary>
		/// Gets or sets the display context associated with this renderer.
		/// </summary>
		/// <value>The display context.</value>
		public IDisplayContext DisplayContext { get; private set; }

		/// <summary>
		/// Gets the line buffer associated with this renderer.
		/// </summary>
		/// <value>The line buffer.</value>
		public abstract LineBuffer LineBuffer { get; }

		/// <summary>
		/// Gets or sets the selection renderer.
		/// </summary>
		/// <value>The selection renderer.</value>
		public abstract SelectionRenderer SelectionRenderer { get; set; }

		/// <summary>
		/// Sets the pixel width of a layout in case the layout uses word
		/// wrapping.
		/// </summary>
		/// <value>The width.</value>
		public virtual int Width { get; set; }

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
		/// Clears the line buffer from the renderer.
		/// </summary>
		public void ClearLineBuffer()
		{
			SetLineBuffer(null);
		}

		/// <summary>
		/// Gets the line layout for a given line.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public virtual Layout GetLineLayout(
			int lineIndex,
			LineContexts lineContexts)
		{
			// Get the layout.
			var layout = new Layout(DisplayContext.PangoContext);

			// Assign the given style to the layout.
			LineBlockStyle style = GetLineStyle(lineIndex, lineContexts);

			DisplayContext.SetLayout(layout, style, DisplayContext.TextWidth);

			// Set the markup and return.
			string markup = GetSelectionMarkup(lineIndex, lineContexts);
			string coloredMarkup = DrawingUtility.WrapColorMarkup(
				markup, style.GetForegroundColor());

			layout.SetMarkup(coloredMarkup);

			return layout;
		}

		/// <summary>
		/// Gets the pixel height of the lines in the buffer.
		/// </summary>
		/// <param name="startLineIndex">The start line.</param>
		/// <param name="endLineIndex">The end line.</param>
		/// <returns></returns>
		public virtual int GetLineLayoutHeight(
			int startLineIndex,
			int endLineIndex)
		{
			// If we have no lines, we have no height.
			int lineCount = LineBuffer.LineCount;

			if (lineCount == 0)
			{
				return 0;
			}

			// The endLineIndex can be beyond the end of the buffer's lines, so
			// cap it by the buffer.
			endLineIndex = Math.Min(endLineIndex, lineCount - 1);

			// Get a total of all the heights.
			int height = 0;

			for (int line = startLineIndex;
				line <= endLineIndex;
				line++)
			{
				// Get the height for this line.
				int lineHeight = GetLineLayoutHeight(line);

				// Add the height to the total.
				height += lineHeight;
			}

			// Return the resulting height.
			return height;
		}

		/// <summary>
		/// Gets the height of a single line of "normal" text.
		/// </summary>
		/// <returns></returns>
		public virtual int GetLineLayoutHeight()
		{
			// Get a layout for the default text style.
			var layout = new Layout(DisplayContext.PangoContext);

			DisplayContext.SetLayout(
				layout, DisplayContext.Theme.TextLineStyle, DisplayContext.TextWidth);

			// Set the layout to a simple string.
			layout.SetText("W");

			// Get the height of the default line.
			int height,
				width;

			layout.GetPixelSize(out width, out height);

			return height;
		}

		/// <summary>
		/// Gets the line at a specific point and returns it.
		/// </summary>
		/// <param name="bufferY">The buffer Y.</param>
		/// <returns></returns>
		public int GetLineLayoutRange(double bufferY)
		{
			var rectangle = new Rectangle(0, bufferY, 0.1, 0.1);
			int startLineIndex,
				endLineIndex;

			GetLineLayoutRange(rectangle, out startLineIndex, out endLineIndex);

			return startLineIndex;
		}

		/// <summary>
		/// Gets the lines that are visible in the given view area.
		/// </summary>
		/// <param name="viewArea">The view area.</param>
		/// <param name="startLine">The start line.</param>
		/// <param name="endLine">The end line.</param>
		public virtual void GetLineLayoutRange(
			Rectangle viewArea,
			out int startLine,
			out int endLine)
		{
			// Reset the start line to negative to indicate we don't have a
			// visible line yet.
			startLine = -1;

			// Go through all the lines until we find one that is in the range.
			int currentY = 0;
			int lineCount = LineBuffer.LineCount;

			for (int line = 0;
				line < lineCount;
				line++)
			{
				// Get the height for this line.
				int height = GetLineLayoutHeight(line);

				// If we don't have a starting line, then check to see if this
				// line is visible.
				if (startLine < 0)
				{
					if (currentY + height >= viewArea.Y)
					{
						startLine = line;
					}
				}

				// Set the end line equal to the current line so it moves forward
				// until we break out.
				endLine = line;

				// Add the height to the current Y offset. If it exceeds the
				// viewport, then we are done.
				currentY += height;

				if (currentY > viewArea.Y + viewArea.Height)
				{
					// We are done, so return the values.
					return;
				}
			}

			// If we got this far, nothing is visible.
			startLine = endLine = 0;
			return;
		}

		/// <summary>
		/// Gets the line style associated with a line.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public virtual LineBlockStyle GetLineStyle(
			int lineIndex,
			LineContexts lineContexts)
		{
			// Get the style name and normalize it.
			string styleName = LineBuffer.GetLineStyleName(lineIndex, lineContexts);

			if (String.IsNullOrEmpty(styleName))
			{
				styleName = Theme.TextStyle;
			}

			// Retrieve the style.
			return DisplayContext.Theme.LineStyles[styleName];
		}

		/// <summary>
		/// Gets the Pango markup for a given line.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public string GetSelectionMarkup(
			int lineIndex,
			LineContexts lineContexts)
		{
			// Get the line markup from the underlying buffer.
			string markup = LineBuffer.GetLineMarkup(lineIndex, lineContexts);

			// Check to see if we are in the selection.
			int startCharacterIndex,
				endCharacterIndex;
			bool containsLine = DisplayContext.Caret.Selection.ContainsLine(
				lineIndex, out startCharacterIndex, out endCharacterIndex);

			if (containsLine)
			{
				// Apply the markup to the line.
				return SelectionRenderer.GetSelectionMarkup(
					markup, new CharacterRange(startCharacterIndex, endCharacterIndex));
			}

			// Return the resulting markup.
			return markup;
		}

		/// <summary>
		/// Gets the wrapped line layout for a given buffer Y coordinate.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="bufferY">The buffer Y.</param>
		/// <returns></returns>
		public LayoutLine GetWrappedLineLayout(
			IDisplayContext displayContext,
			double bufferY)
		{
			int wrappedLineIndex;
			return GetWrappedLineLayout(
				displayContext, bufferY, out wrappedLineIndex, LineContexts.None);
		}

		/// <summary>
		/// Gets the wrapped line layout for a given buffer Y coordinate and the
		/// associated index.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="bufferY">The buffer Y.</param>
		/// <param name="wrappedLineIndex">Index of the wrapped line.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public LayoutLine GetWrappedLineLayout(
			IDisplayContext displayContext,
			double bufferY,
			out int wrappedLineIndex,
			LineContexts lineContexts)
		{
			// Get the line that contains the given Y coordinate.
			int lineIndex,
				endLineIndex;
			GetLineLayoutRange(
				new Rectangle(0, bufferY, 0, bufferY), out lineIndex, out endLineIndex);

			// Get the layout-relative Y coordinate.
			double layoutY = bufferY - GetLineLayoutHeight(0, lineIndex);

			// Figure out which line inside the layout.
			Layout layout = GetLineLayout(lineIndex, LineContexts.None);
			int trailing;

			layout.XyToIndex(0, (int) layoutY, out wrappedLineIndex, out trailing);

			// Return the layout line.
			return layout.Lines[wrappedLineIndex];
		}

		/// <summary>
		/// Gets the index of the wrapped line layout.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="bufferY">The buffer Y.</param>
		/// <returns></returns>
		public int GetWrappedLineLayoutIndex(
			IDisplayContext displayContext,
			double bufferY)
		{
			int wrappedLineIndex;
			GetWrappedLineLayout(
				displayContext, bufferY, out wrappedLineIndex, LineContexts.None);
			return wrappedLineIndex;
		}

		/// <summary>
		/// Indicates that the underlying text editor has changed in some manner
		/// and any cache or size calculations are invalidated.
		/// </summary>
		public virtual void Reset()
		{
			// The simple layout buffer has no calculations.
		}

		/// <summary>
		/// Sets the line buffer since the renderer.
		/// </summary>
		/// <param name="value">The value.</param>
		public abstract void SetLineBuffer(LineBuffer value);

		/// <summary>
		/// Updates the selection inside the renderer.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="previousSelection">The previous selection.</param>
		public virtual void UpdateSelection(
			IDisplayContext displayContext,
			BufferSegment previousSelection)
		{
		}

		/// <summary>
		/// Called when a line changes in the underlying buffer.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The e.</param>
		protected virtual void OnLineChanged(
			object sender,
			LineChangedArgs e)
		{
			RaiseLineChanged(e);
		}

		/// <summary>
		/// Called when lines are deleted from the underlying buffer.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="LineRangeEventArgs"/> instance containing the event data.</param>
		protected virtual void OnLinesDeleted(
			object sender,
			LineRangeEventArgs e)
		{
			RaiseLinesDeleted(e);
		}

		/// <summary>
		/// Called when lines are inserted into the underlying buffer.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="LineRangeEventArgs"/> instance containing the event data.</param>
		protected virtual void OnLinesInserted(
			object sender,
			LineRangeEventArgs e)
		{
			RaiseLinesInserted(e);
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

		/// <summary>
		/// Gets the height of a single line layout.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <returns></returns>
		private int GetLineLayoutHeight(int lineIndex)
		{
			// Get the extents for the line while rendered.
			Layout lineLayout = GetLineLayout(lineIndex, LineContexts.None);
			int lineWidth,
				lineHeight;

			lineLayout.GetPixelSize(out lineWidth, out lineHeight);

			// Get the style to include the style's height.
			LineBlockStyle style = GetLineStyle(lineIndex, LineContexts.None);

			lineHeight += (int) Math.Ceiling(style.Height);

			// Return the resulting height.
			return lineHeight;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		protected EditorViewRenderer(IDisplayContext displayContext)
		{
			// Set the properties in the renderer.
			if (displayContext == null)
			{
				throw new ArgumentNullException("displayContext");
			}

			DisplayContext = displayContext;
		}

		#endregion
	}
}
