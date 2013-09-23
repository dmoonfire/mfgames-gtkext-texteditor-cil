// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using Cairo;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using Pango;
using Rectangle = Pango.Rectangle;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// Contains various extensions to <see cref="TextPosition"/> for working
	/// with <see cref="IDisplayContext"/>.
	/// </summary>
	public static class TextPositionHelper
	{
		#region Methods

		/// <summary>
		/// Gets the wrapped line associated with this buffer position.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <returns></returns>
		public static LayoutLine GetWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			Layout layout;
			int wrappedLineIndex;

			return bufferPosition.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);
		}

		/// <summary>
		/// Gets the wrapped line associated with this buffer position.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <param name="layout">The layout.</param>
		/// <param name="wrappedLineIndex">Index of the wrapped line.</param>
		/// <returns></returns>
		public static LayoutLine GetWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext,
			out Layout layout,
			out int wrappedLineIndex)
		{
			// Get the layout and text associated with the line.
			string text = displayContext.LineBuffer.GetLineText(bufferPosition.LinePosition);

			layout = displayContext.Renderer.GetLineLayout(
				bufferPosition.LinePosition, LineContexts.Unformatted);

			// Get the wrapped line associated with this character position.
			int unicodeIndex = PangoUtility.TranslateStringToPangoIndex(
				text, bufferPosition.CharacterPosition);
			int x;

			layout.IndexToLineX(unicodeIndex, false, out wrappedLineIndex, out x);

			// Return the resulting line.
			return layout.Lines[wrappedLineIndex];
		}

		/// <summary>
		/// Determines whether the position is at the beginning of a wrapped line.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		///   <c>true</c> if [is begining of wrapped line] [the specified display context]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsBeginingOfWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.CharacterPosition
				== bufferPosition.GetWrappedLine(displayContext).StartIndex;
		}

		/// <summary>
		/// Determines whether the position is at the beginning of the line.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="buffer">The buffer.</param>
		/// <returns>
		///   <c>true</c> if [is beginning of buffer] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsBeginningOfBuffer(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return bufferPosition.LinePosition == 0 && bufferPosition.CharacterPosition == 0;
		}

		/// <summary>
		/// Determines whether the position is at the beginning of the line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is beginning of buffer] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsBeginningOfBuffer(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.IsBeginningOfBuffer(displayContext.Renderer);
		}

		/// <summary>
		/// Determines whether the position is at the beginning of a line.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <returns>
		/// 	<c>true</c> if [is beginning of line] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsBeginningOfLine(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return bufferPosition.CharacterPosition == 0;
		}

		/// <summary>
		/// Determines whether the position is at the beginning of a line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is beginning of line] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsBeginningOfLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.IsBeginningOfLine(displayContext.Renderer);
		}

		/// <summary>
		/// Determines whether the position is at the end of the buffer.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <returns>
		/// 	<c>true</c> if [is end of buffer] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEndOfBuffer(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return bufferPosition.LinePosition == buffer.LineBuffer.LineCount - 1
				&& bufferPosition.IsEndOfLine(buffer);
		}

		/// <summary>
		/// Determines whether the position is at the end of the buffer.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is end of buffer] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEndOfBuffer(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.IsEndOfBuffer(displayContext.Renderer);
		}

		/// <summary>
		/// Determines whether the position is at the end of the line.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <returns>
		/// 	<c>true</c> if [is end of line] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEndOfLine(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return bufferPosition.CharacterPosition
				== buffer.LineBuffer.GetLineLength(
					bufferPosition.LinePosition, LineContexts.Unformatted);
		}

		/// <summary>
		/// Determines whether the position is at the end of the line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is end of line] [the specified buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEndOfLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.IsEndOfLine(displayContext.Renderer);
		}

		/// <summary>
		/// Determines whether the position is at the end of a wrapped line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is end of wrapped line] [the specified display context]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsEndOfWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			// Get the wrapped line and layout.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = bufferPosition.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Move to the end of the wrapped line. If this isn't the last, we
			// need to shift back one character.
			int wrappedCharacterIndex = wrappedLine.StartIndex + wrappedLine.Length;

			if (wrappedLineIndex != layout.LineCount - 1)
			{
				wrappedCharacterIndex--;
			}

			// Return if these are equal.
			return bufferPosition.CharacterPosition == wrappedCharacterIndex;
		}

		/// <summary>
		/// Determines whether this position represents the last line in the buffer.
		/// </summary>
		/// <param name="lineLayoutBuffer">The line layout buffer.</param>
		/// <returns>
		/// 	<c>true</c> if [is last line in buffer] [the specified line layout buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLastLineInBuffer(
			this TextPosition bufferPosition,
			EditorViewRenderer lineLayoutBuffer)
		{
			return bufferPosition.LinePosition == lineLayoutBuffer.LineBuffer.LineCount - 1;
		}

		/// <summary>
		/// Determines whether this position represents the last line in the buffer.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <returns>
		/// 	<c>true</c> if [is last line in buffer] [the specified line layout buffer]; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsLastLineInBuffer(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.IsLastLineInBuffer(displayContext.Renderer);
		}

		/// <summary>
		/// Moves the position to end beginning of buffer.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		public static TextPosition ToBeginningOfBuffer(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return new TextPosition(0, 0);
		}

		/// <summary>
		/// Moves the position to end beginning of buffer.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public static TextPosition ToBeginningOfBuffer(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.ToBeginningOfBuffer(displayContext.Renderer);
		}

		/// <summary>
		/// Moves the position to the beginning of line.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		public static TextPosition ToBeginningOfLine(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return new TextPosition(bufferPosition.LinePosition, 0);
		}

		/// <summary>
		/// Moves the position to the beginning of line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public static TextPosition ToBeginningOfLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.ToBeginningOfLine(displayContext.Renderer);
		}

		/// <summary>
		/// Moves the position to the beginning of wrapped line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public static TextPosition ToBeginningOfWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			// Wrapped lines (via Pango) work with UTF-8 encoding, not the
			// normal C# string indexes. We need to get the index and convert
			// it to a character string since that is what this library uses.
			LayoutLine wrappedLine = bufferPosition.GetWrappedLine(displayContext);
			int unicodeIndex = wrappedLine.StartIndex;

			// Because the wrappedLine works with UTF-8 encoding, we need to
			// convert it back to a C# string.
			string lineText =
				displayContext.LineBuffer.GetLineText(bufferPosition.LinePosition);
			int characterIndex = PangoUtility.TranslatePangoToStringIndex(
				lineText, unicodeIndex);

			// Create a new buffer position from the elements and return it.
			return new TextPosition(bufferPosition.LinePosition, characterIndex);
		}

		/// <summary>
		/// Moves the position to the end of buffer.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		public static TextPosition ToEndOfBuffer(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			int endLineIndex = buffer.LineBuffer.LineCount - 1;

			return new TextPosition(
				endLineIndex,
				buffer.LineBuffer.GetLineLength(endLineIndex, LineContexts.Unformatted));
		}

		/// <summary>
		/// Moves the position to the end of buffer.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <returns></returns>
		public static TextPosition ToEndOfBuffer(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.ToEndOfBuffer(displayContext.Renderer);
		}

		/// <summary>
		/// Moves the position to the end of line.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="buffer">The buffer.</param>
		/// <returns></returns>
		public static TextPosition ToEndOfLine(
			this TextPosition bufferPosition,
			EditorViewRenderer buffer)
		{
			return new TextPosition(
				bufferPosition.LinePosition,
				buffer.LineBuffer.GetLineLength(
					bufferPosition.LinePosition, LineContexts.Unformatted));
		}

		/// <summary>
		/// Moves the position to the end of line.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <returns></returns>
		public static TextPosition ToEndOfLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			return bufferPosition.ToEndOfLine(displayContext.Renderer);
		}

		/// <summary>
		/// Moves the position to the end of wrapped line.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public static TextPosition ToEndOfWrappedLine(
			this TextPosition bufferPosition,
			IDisplayContext displayContext)
		{
			// Get the wrapped line and layout.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = bufferPosition.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Move to the end of the wrapped line. If this isn't the last, we
			// need to shift back one character.
			int unicodeIndex = wrappedLine.StartIndex + wrappedLine.Length;

			if (wrappedLineIndex != layout.LineCount - 1)
			{
				unicodeIndex--;
			}

			// Because the wrappedLine works with UTF-8 encoding, we need to
			// convert it back to a C# string.
			string lineText =
				displayContext.LineBuffer.GetLineText(bufferPosition.LinePosition);
			int characterIndex = PangoUtility.TranslatePangoToStringIndex(
				lineText, unicodeIndex);

			// Create a new buffer position from the elements and return it.
			return new TextPosition(bufferPosition.LinePosition, characterIndex);
		}

		/// <summary>
		/// Converts the given line and character coordinates into pixel coordinates
		/// on the display.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="displayContext">The display context.</param>
		/// <param name="lineHeight">Will contains the height of the current line.</param>
		/// <returns></returns>
		public static PointD ToScreenCoordinates(
			this TextPosition bufferPosition,
			IDisplayContext displayContext,
			out int lineHeight)
		{
			// Get the line index, which needs to be a number in range.
			EditorViewRenderer buffer = displayContext.Renderer;
			int lineIndex = Math.Min(
				bufferPosition.LinePosition.Index,
				displayContext.LineBuffer.LineCount - 1);

			// Pull out some of the common things we'll be using in this method.
			int bufferLineIndex = buffer.LineBuffer.NormalizeLineIndex(lineIndex);
			Layout layout = buffer.GetLineLayout(
				bufferLineIndex, LineContexts.Unformatted);
			LineBlockStyle style = buffer.GetLineStyle(
				bufferLineIndex, LineContexts.Unformatted);

			// Figure out the top of the current line in relation to the entire
			// buffer and view. For lines beyond the first, we use
			// GetLineLayoutHeight because it also takes into account the line 
			// spacing and borders which we would have to calculate otherwise.
			double y = bufferLineIndex == 0
				? 0
				: buffer.GetLineLayoutHeight(0, bufferLineIndex - 1);

			// Add the style offset for the top-padding.
			y += style.Top;

			// The cursor position code uses Unicode instead of C# character
			// positions. This means we have to advance more than just one
			// value to calculate it. This actually uses UTF-8 encoding to
			// calculate the indexes.
			string lineText = displayContext.LineBuffer.GetLineText(lineIndex);
			int unicodeCharacter = PangoUtility.TranslateStringToPangoIndex(
				lineText, bufferPosition.CharacterPosition);

			// We need to figure out the relative position. If the position equals
			// the length of the string, we want to put the caret at the end of the
			// character. Otherwise, we put it on the front of the character to
			// indicate insert point.
			bool trailing = false;
			int lineLength = buffer.LineBuffer.GetLineLength(
				bufferLineIndex, LineContexts.Unformatted);

			if (unicodeCharacter == lineLength)
			{
				// Shift back one character to calculate the position and put
				// the cursor at the end of the character.
				unicodeCharacter--;
				trailing = true;
			}

			// Figure out which wrapped line we are actually on and the position
			// inside that line. If the character equals the length of the string,
			// then we want to move to the end of it.
			int wrappedLineIndex;
			int layoutX;
			layout.IndexToLineX(
				unicodeCharacter, trailing, out wrappedLineIndex, out layoutX);

			// Get the relative offset into the wrapped lines.
			Rectangle layoutPoint = layout.IndexToPos(unicodeCharacter);

			y += Units.ToPixels(layoutPoint.Y);

			// Get the height of the wrapped line.
			Rectangle ink = Rectangle.Zero;
			Rectangle logical = Rectangle.Zero;

			layout.Lines[wrappedLineIndex].GetPixelExtents(ref ink, ref logical);
			lineHeight = logical.Height;

			// Return the results.
			return new PointD(Units.ToPixels(layoutX), y);
		}

		#endregion
	}
}
