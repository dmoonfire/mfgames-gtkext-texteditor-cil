// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using Cairo;
using Gdk;
using MfGames.GtkExt.Extensions.Pango;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.GtkExt.TextEditor.Renderers;
using Pango;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Contains the various actions used for moving the caret (cursor) around
	/// the text buffer.
	/// </summary>
	[ActionFixture]
	public static class MoveActions
	{
		#region Methods

		/// <summary>
		/// Moves the caret to the end of the buffer.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.KP_Home, ModifierType.ControlMask)]
		[KeyBinding(Key.Home, ModifierType.ControlMask)]
		public static void BeginningOfBuffer(EditorViewController controller)
		{
			IDisplayContext displayContext = controller.DisplayContext;
			Caret caret = displayContext.Caret;
			displayContext.ScrollToCaret(
				caret.Position.ToBeginningOfBuffer(displayContext));
		}

		/// <summary>
		/// Moves the caret to the end of the visible line.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.KP_Home)]
		[KeyBinding(Key.Home)]
		public static void BeginningOfWrappedLine(EditorViewController controller)
		{
			IDisplayContext displayContext = controller.DisplayContext;
			Caret caret = displayContext.Caret;
			displayContext.ScrollToCaret(
				caret.Position.ToBeginningOfWrappedLine(displayContext));
		}

		/// <summary>
		/// Moves the caret down one line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Down)]
		[KeyBinding(Key.Down)]
		public static void Down(EditorViewController controller)
		{
			// Extract a number of useful variable for this method.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			EditorViewRenderer buffer = displayContext.Renderer;

			// Figure out the layout and wrapped line we are currently on.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = position.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Figure out the X coordinate of the line. If there is an action context,
			// use that. Otherwise, calculate it from the character index of the position.
			int lineX = GetLineX(controller, wrappedLine, position);

			// Figure out which wrapped line we'll be moving the caret to.
			if (wrappedLine.IsLastLineInLayout())
			{
				// If we are the last line in the buffer, just do nothing.
				if (position.IsLastLineInBuffer(buffer))
				{
					return;
				}

				// Move to the next line.
				position.LineIndex++;
				layout = buffer.GetLineLayout(position.LineIndex, LineContexts.None);
				wrappedLine = layout.Lines[0];
			}
			else
			{
				// Just move down in the layout.
				wrappedLineIndex++;
				wrappedLine = layout.Lines[wrappedLineIndex];
			}

			// The wrapped line has the current wrapped line, so use the lineX
			// to figure out which character to use.
			int trailing;
			int index;

			wrappedLine.XToIndex(lineX, out index, out trailing);
			position.CharacterIndex = index;

			// Draw the new location of the caret.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Moves the caret to the end of the buffer.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.KP_End, ModifierType.ControlMask)]
		[KeyBinding(Key.End, ModifierType.ControlMask)]
		public static void EndOfBuffer(EditorViewController controller)
		{
			IDisplayContext displayContext = controller.DisplayContext;
			Caret caret = displayContext.Caret;
			displayContext.ScrollToCaret(caret.Position.ToEndOfBuffer(displayContext));
		}

		/// <summary>
		/// Moves the caret to the end of the line.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.KP_End)]
		[KeyBinding(Key.End)]
		public static void EndOfWrappedLine(EditorViewController controller)
		{
			IDisplayContext displayContext = controller.DisplayContext;
			Caret caret = displayContext.Caret;
			displayContext.ScrollToCaret(
				caret.Position.ToEndOfWrappedLine(displayContext));
		}

		/// <summary>
		/// Gets the buffer position from a given point.
		/// </summary>
		/// <param name="widgetPoint">The widget point.</param>
		/// <param name="displayContext">The display context.</param>
		/// <returns></returns>
		public static BufferPosition GetBufferPosition(
			PointD widgetPoint,
			IDisplayContext displayContext)
		{
			double y = widgetPoint.Y + displayContext.BufferOffsetY;
			int lineIndex = displayContext.Renderer.GetLineLayoutRange(y);
			Layout layout = displayContext.Renderer.GetLineLayout(
				lineIndex, LineContexts.None);

			// Shift the buffer-relative coordinates to layout-relative coordinates.
			double layoutY = y;

			if (lineIndex > 0)
			{
				layoutY -= displayContext.Renderer.GetLineLayoutHeight(0, lineIndex - 1);
			}

			int pangoLayoutY = Units.FromPixels((int) layoutY);

			// Shift the buffer-relative coordinates to handle padding.
			LineBlockStyle style = displayContext.Renderer.GetLineStyle(
				lineIndex, LineContexts.None);
			double layoutX = widgetPoint.X - style.Left;

			// Determines where in the layout is the point.
			int pangoLayoutX = Units.FromPixels((int) layoutX);
			int characterIndex,
				trailing;

			layout.XyToIndex(
				pangoLayoutX, pangoLayoutY, out characterIndex, out trailing);

			// Return the buffer position.
			return new BufferPosition(lineIndex, characterIndex + trailing);
		}

		/// <summary>
		/// Moves the caret left one character.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Left)]
		[KeyBinding(Key.Left)]
		public static void Left(EditorViewController controller)
		{
			// Move the character position.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;

			if (position.CharacterIndex == 0)
			{
				if (position.LineIndex > 0)
				{
					position.LineIndex--;
					position.CharacterIndex =
						displayContext.LineBuffer.GetLineLength(
							position.LineIndex, LineContexts.None);
				}
			}
			else
			{
				position.CharacterIndex--;
			}

			// Cause the text editor to redraw itself.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Moves the caret left one word.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Left, ModifierType.ControlMask)]
		[KeyBinding(Key.Left, ModifierType.ControlMask)]
		public static void LeftWord(EditorViewController controller)
		{
			// Get the text and line for the position in question.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			string text = displayContext.LineBuffer.GetLineText(
				position.LineIndex, LineContexts.None);

			// If there is no left boundary, we move up a line.
			int leftBoundary = displayContext.WordSplitter.GetPreviousWordBoundary(
				text, position.CharacterIndex);

			if (leftBoundary == -1)
			{
				// Check to see if we are at the top of the line or not.
				if (position.LineIndex > 0)
				{
					position.LineIndex--;
					position.CharacterIndex =
						displayContext.LineBuffer.GetLineLength(
							position.LineIndex, LineContexts.None);
				}
			}
			else
			{
				position.CharacterIndex = leftBoundary;
			}

			// Cause the text editor to redraw itself.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Moves the caret down one page.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Page_Down)]
		[KeyBinding(Key.Page_Down)]
		public static void PageDown(EditorViewController controller)
		{
			// Extract a number of useful variable for this method.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;

			// Figure out the layout and wrapped line we are currently on.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = position.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Figure out where in the buffer we're located.
			int lineHeight;

			PointD point = position.ToScreenCoordinates(displayContext, out lineHeight);

			// Shift down the buffer a full page size and clamp it to the actual
			// buffer size.
			double bufferY =
				Math.Min(
					point.Y + displayContext.VerticalAdjustment.PageSize,
					displayContext.Renderer.GetLineLayoutHeight(0, Int32.MaxValue));

			// Figure out the X coordinate of the line. If there is an action context,
			// use that. Otherwise, calculate it from the character index of the position.
			int lineX = Units.ToPixels(GetLineX(controller, wrappedLine, position));

			// Move to the calculated point.
			Point(
				displayContext, new PointD(lineX, bufferY - displayContext.BufferOffsetY));
		}

		/// <summary>
		/// Moves the caret down one page.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Page_Up)]
		[KeyBinding(Key.Page_Up)]
		public static void PageUp(EditorViewController controller)
		{
			// Extract a number of useful variable for this method.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;

			// Figure out the layout and wrapped line we are currently on.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = position.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Figure out where in the buffer we're located.
			int lineHeight;

			PointD point = position.ToScreenCoordinates(displayContext, out lineHeight);

			// Shift down the buffer a full page size and clamp it to the actual
			// buffer size.
			double bufferY =
				Math.Max(point.Y - displayContext.VerticalAdjustment.PageSize, 0);

			// Figure out the X coordinate of the line. If there is an action context,
			// use that. Otherwise, calculate it from the character index of the position.
			int lineX = Units.ToPixels(GetLineX(controller, wrappedLine, position));

			// Move to the calculated point.
			Point(
				displayContext, new PointD(lineX, bufferY - displayContext.BufferOffsetY));
		}

		/// <summary>
		/// Moves the caret to a specific widget-relative point on the screen.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="widgetPoint">The point in the widget.</param>
		public static void Point(
			IDisplayContext displayContext,
			PointD widgetPoint)
		{
			// Move to and draw the caret.
			displayContext.ScrollToCaret(GetBufferPosition(widgetPoint, displayContext));
		}

		/// <summary>
		/// Moves the caret right one character.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Right)]
		[KeyBinding(Key.Right)]
		public static void Right(EditorViewController controller)
		{
			// Move the character position.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			LineBuffer lineBuffer = displayContext.LineBuffer;

			if (position.CharacterIndex
				== lineBuffer.GetLineLength(position.LineIndex, LineContexts.None))
			{
				if (position.LineIndex < lineBuffer.LineCount - 1)
				{
					position.LineIndex++;
					position.CharacterIndex = 0;
				}
			}
			else
			{
				position.CharacterIndex++;
			}

			// Cause the text editor to redraw itself.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Moves the caret right one word.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Right, ModifierType.ControlMask)]
		[KeyBinding(Key.Right, ModifierType.ControlMask)]
		public static void RightWord(EditorViewController controller)
		{
			// Get the text and line for the position in question.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			string text = displayContext.LineBuffer.GetLineText(
				position.LineIndex, LineContexts.Unformatted);

			// If there is no right boundary, we move down a line.
			int rightBoundary = displayContext.WordSplitter.GetNextWordBoundary(
				text, position.CharacterIndex);

			if (rightBoundary == Int32.MaxValue)
			{
				// Check to see if we are at the bottom of the buffer.
				if (position.LineIndex + 1 >= displayContext.LineBuffer.LineCount)
				{
					return;
				}

				// Advance the position to the next line.
				position.LineIndex++;
				position.CharacterIndex = 0;
			}
			else
			{
				position.CharacterIndex = rightBoundary;
			}

			// Cause the text editor to redraw itself.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Selects all the text in the buffer.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.A, ModifierType.ControlMask)]
		public static void SelectAll(EditorViewController controller)
		{
			controller.DisplayContext.Caret.Selection.AnchorPosition =
				new BufferPosition(0, 0);
			controller.DisplayContext.Caret.Selection.TailPosition =
				new BufferPosition(Int32.MaxValue, Int32.MaxValue);

			controller.DisplayContext.RequestRedraw();
		}

		/// <summary>
		/// Expands the selection to the beginning of the buffer.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Home, ModifierType.ShiftMask | ModifierType.ControlMask)]
		[KeyBinding(Key.Home, ModifierType.ShiftMask | ModifierType.ControlMask)]
		public static void SelectBeginningOfBuffer(EditorViewController controller)
		{
			SelectAction(controller, BeginningOfBuffer);
		}

		/// <summary>
		/// Expands the selection to the beginning of the line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Home, ModifierType.ShiftMask)]
		[KeyBinding(Key.Home, ModifierType.ShiftMask)]
		public static void SelectBeginningOfWrappedLine(
			EditorViewController controller)
		{
			SelectAction(controller, BeginningOfWrappedLine);
		}

		/// <summary>
		/// Expands the selection down one line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Down, ModifierType.ShiftMask)]
		[KeyBinding(Key.Down, ModifierType.ShiftMask)]
		public static void SelectDown(EditorViewController controller)
		{
			SelectAction(controller, Down);
		}

		/// <summary>
		/// Expands the selection to the end of the buffer.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_End, ModifierType.ShiftMask | ModifierType.ControlMask)]
		[KeyBinding(Key.End, ModifierType.ShiftMask | ModifierType.ControlMask)]
		public static void SelectEndOfBuffer(EditorViewController controller)
		{
			SelectAction(controller, EndOfBuffer);
		}

		/// <summary>
		/// Expands the selection to the end of the line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_End, ModifierType.ShiftMask)]
		[KeyBinding(Key.End, ModifierType.ShiftMask)]
		public static void SelectEndOfWrappedLine(EditorViewController controller)
		{
			SelectAction(controller, EndOfWrappedLine);
		}

		/// <summary>
		/// Expands the selection left one character.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Left, ModifierType.ShiftMask)]
		[KeyBinding(Key.Left, ModifierType.ShiftMask)]
		public static void SelectLeft(EditorViewController controller)
		{
			SelectAction(controller, Left);
		}

		/// <summary>
		/// Expands the selection left one word.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Left, ModifierType.ShiftMask | ModifierType.ControlMask)]
		[KeyBinding(Key.Left, ModifierType.ShiftMask | ModifierType.ControlMask)]
		public static void SelectLeftWord(EditorViewController controller)
		{
			SelectAction(controller, LeftWord);
		}

		/// <summary>
		/// Selects the entire line the current currently is located on.
		/// </summary>
		/// <param name="controller">The controller.</param>
		public static void SelectLine(EditorViewController controller)
		{
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;

			displayContext.Caret.Selection.AnchorPosition =
				position.ToBeginningOfLine(displayContext);
			displayContext.Caret.Selection.TailPosition =
				position.ToEndOfLine(displayContext);
		}

		/// <summary>
		/// Expands the selection down one page.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Page_Down, ModifierType.ShiftMask)]
		[KeyBinding(Key.Page_Down, ModifierType.ShiftMask)]
		public static void SelectPageDown(EditorViewController controller)
		{
			SelectAction(controller, PageDown);
		}

		/// <summary>
		/// Expands the selection up one page.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Page_Up, ModifierType.ShiftMask)]
		[KeyBinding(Key.Page_Up, ModifierType.ShiftMask)]
		public static void SelectPageUp(EditorViewController controller)
		{
			SelectAction(controller, PageUp);
		}

		/// <summary>
		/// Expands the selection right one character.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Right, ModifierType.ShiftMask)]
		[KeyBinding(Key.Right, ModifierType.ShiftMask)]
		public static void SelectRight(EditorViewController controller)
		{
			SelectAction(controller, Right);
		}

		/// <summary>
		/// Expands the selection right one word.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[KeyBinding(Key.KP_Right, ModifierType.ShiftMask | ModifierType.ControlMask)]
		[KeyBinding(Key.Right, ModifierType.ShiftMask | ModifierType.ControlMask)]
		public static void SelectRightWord(EditorViewController controller)
		{
			SelectAction(controller, RightWord);
		}

		/// <summary>
		/// Expands the selection up one line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Up, ModifierType.ShiftMask)]
		[KeyBinding(Key.Up, ModifierType.ShiftMask)]
		public static void SelectUp(EditorViewController controller)
		{
			SelectAction(controller, Up);
		}

		/// <summary>
		/// Selects the word around the current cursor position.
		/// </summary>
		/// <param name="controller">The controller.</param>
		public static void SelectWord(EditorViewController controller)
		{
			// Pull out information about the current context.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			string lineText = displayContext.LineBuffer.GetLineText(
				position.LineIndex, LineContexts.Unformatted);

			// Find the boundaries for the current word.
			int startIndex = Math.Max(
				0,
				displayContext.WordSplitter.GetPreviousWordBoundary(
					lineText, position.CharacterIndex));
			int endIndex = Math.Min(
				lineText.Length,
				displayContext.WordSplitter.GetNextWordBoundary(
					lineText, position.CharacterIndex));

			// Set the selection to the boundaries.
			displayContext.Caret.Selection.AnchorPosition =
				new BufferPosition(position.LineIndex, startIndex);
			displayContext.Caret.Selection.TailPosition =
				new BufferPosition(position.LineIndex, endIndex);
		}

		/// <summary>
		/// Moves the caret up one line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.KP_Up)]
		[KeyBinding(Key.Up)]
		public static void Up(EditorViewController controller)
		{
			// Extract a number of useful variable for this method.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;
			EditorViewRenderer buffer = displayContext.Renderer;

			// Figure out the layout and wrapped line we are currently on.
			Layout layout;
			int wrappedLineIndex;
			LayoutLine wrappedLine = position.GetWrappedLine(
				displayContext, out layout, out wrappedLineIndex);

			// Figure out the X coordinate of the line. If there is an action context,
			// use that. Otherwise, calculate it from the character index of the position.
			int lineX = GetLineX(controller, wrappedLine, position);

			// Figure out which wrapped line we'll be moving the caret to.
			if (wrappedLineIndex == 0)
			{
				// If we are the last line in the buffer, just do nothing.
				if (position.LineIndex == 0)
				{
					return;
				}

				// Move to the next line.
				position.LineIndex--;
				layout = buffer.GetLineLayout(position.LineIndex, LineContexts.None);
				wrappedLineIndex = layout.LineCount - 1;
				wrappedLine = layout.Lines[wrappedLineIndex];
			}
			else
			{
				// Just move down in the layout.
				wrappedLineIndex--;
				wrappedLine = layout.Lines[wrappedLineIndex];
			}

			// The wrapped line has the current wrapped line, so use the lineX
			// to figure out which character to use.
			int trailing;
			int index;

			wrappedLine.XToIndex(lineX, out index, out trailing);
			position.CharacterIndex = index;

			// Draw the new location of the caret.
			displayContext.ScrollToCaret(position);
		}

		/// <summary>
		/// Gets the line X coordinates from either the state if we have one
		/// or calculate it from the buffer position's X coordinate.
		/// </summary>
		/// <param name="controller">The action context.</param>
		/// <param name="wrappedLine">The wrapped line.</param>
		/// <param name="position">The position.</param>
		/// <returns></returns>
		private static int GetLineX(
			EditorViewController controller,
			LayoutLine wrappedLine,
			BufferPosition position)
		{
			int lineX;
			var state = controller.States.Get<VerticalMovementActionState>();

			if (state == null)
			{
				// Calculate the line state from the caret position.
				lineX = wrappedLine.IndexToX(position.CharacterIndex, false);

				// Save a new state into the states.
				state = new VerticalMovementActionState(lineX);
				controller.States.Add(state);
			}
			else
			{
				// Get the line coordinate from the state.
				lineX = state.LayoutLineX;
			}

			return lineX;
		}

		/// <summary>
		/// Performs an action that handles a move action coupled with an
		/// extend or set selection.
		/// </summary>
		/// <param name="controller">The action context.</param>
		/// <param name="action">The action.</param>
		private static void SelectAction(
			EditorViewController controller,
			Action<EditorViewController> action)
		{
			// Grab the anchor position of the selection since that will
			// remain the same after the command.
			Caret caret = controller.DisplayContext.Caret;
			BufferPosition anchorPosition = caret.Selection.AnchorPosition;

			// Perform the move command.
			action(controller);

			// Restore the anchor position which will extend the selection back.
			caret.Selection.AnchorPosition = anchorPosition;
		}

		#endregion
	}
}
