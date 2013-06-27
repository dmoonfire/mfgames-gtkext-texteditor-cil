// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using System.Threading;
using Cairo;
using GLib;
using Gdk;
using Gtk;
using MfGames.GtkExt.TextEditor.Indicators;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.GtkExt.TextEditor.Renderers;
using MfGames.GtkExt.TextEditor.Visuals;
using MfGames.Locking;
using Rectangle = Gdk.Rectangle;

namespace MfGames.GtkExt.TextEditor
{
	/// <summary>
	/// Implements a visual bar of indicators from a given line buffer.
	/// </summary>
	public class IndicatorView: DrawingArea
	{
		#region Properties

		/// <summary>
		/// Gets or sets the display context.
		/// </summary>
		/// <value>The display context.</value>
		private EditorView EditorView { get; set; }

		/// <summary>
		/// Gets the theme associated with this bar.
		/// </summary>
		/// <value>The theme.</value>
		private Theme Theme
		{
			[DebuggerStepThrough] get { return EditorView.Theme; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Called when the bar is exposed (drawn).
		/// </summary>
		/// <param name="exposeEvent">The drawing event..</param>
		/// <returns></returns>
		protected override bool OnExposeEvent(EventExpose exposeEvent)
		{
			// Figure out the area we are rendering into. We subtract one
			// from the width and height because of rounding causes one-pixel
			// borders off the bottom and right edges.
			Rectangle area = exposeEvent.Region.Clipbox;
			var cairoArea = new Cairo.Rectangle(
				area.X, area.Y, area.Width - 1, area.Height - 1);

			using (Context cairoContext = CairoHelper.Create(exposeEvent.Window))
			{
				// Create a render context.
				var renderContext = new RenderContext(cairoContext);
				renderContext.RenderRegion = cairoArea;

				// Paint the background of the entire indicator bar.
				BlockStyle backgroundStyle = Theme.RegionStyles[BackgroundRegionName]
					?? new RegionBlockStyle();
				DrawingUtility.DrawLayout(
					EditorView, renderContext, cairoArea, backgroundStyle);

				// Show the visible area, if we have one.
				BlockStyle visibleStyle = Theme.RegionStyles[VisibleRegionName];
				double barX = area.X + backgroundStyle.Left + 0.5;
				double barWidth = area.Width - backgroundStyle.Width - 1;
				double barY = area.Y + backgroundStyle.Top + 0.5;

				if (visibleStyle != null)
				{
					// Figure out the area and adjust the bar variables with this style.
					var visibleArea = new Cairo.Rectangle(
						barX,
						barY,
						barWidth,
						indicatorLinesUsed * Theme.IndicatorPixelHeight + visibleStyle.Height);

					barX += visibleStyle.Left;
					barWidth -= visibleStyle.Width;
					barY += visibleStyle.Top;

					// Draw the style's elements.
					DrawingUtility.DrawLayout(
						EditorView, renderContext, visibleArea, visibleStyle);
				}

				// Draw all the indicator lines on the display.
				cairoContext.LineWidth = EditorView.Theme.IndicatorPixelHeight;
				cairoContext.Antialias = Antialias.None;

				for (int index = 0;
					index < indicatorLinesUsed;
					index++)
				{
					// Make sure the line has been processed and it visible.
					IndicatorLine indicatorLine = indicatorLines[index];

					if (!indicatorLine.NeedIndicators
						&& indicatorLine.Visible)
					{
						indicatorLine.Draw(EditorView, cairoContext, barX, barY, barWidth);
					}

					// Shift the y-coordinate down.
					barY += EditorView.Theme.IndicatorPixelHeight;
				}
			}

			// Return the render.
			return base.OnExposeEvent(exposeEvent);
		}

		/// <summary>
		/// Called when the widget is resized.
		/// </summary>
		/// <param name="allocation">The allocation.</param>
		protected override void OnSizeAllocated(Rectangle allocation)
		{
			// Call the base implementation for allocation.
			base.OnSizeAllocated(allocation);

			// Allocate the lines internally.
			AllocateIndicatorLines();
		}

		/// <summary>
		/// Reallocates the indicator line objects.
		/// </summary>
		private void AllocateIndicatorLines()
		{
			// Figure out how many lines we can show on the screen.
			double height = Allocation.Height;

			RegionBlockStyle style = Theme.RegionStyles[BackgroundRegionName];
			height -= style == null
				? 0
				: style.Height;

			style = Theme.RegionStyles[VisibleRegionName];
			height -= style == null
				? 0
				: style.Height;

			visibleIndicatorLines = (int) Math.Floor(height / Theme.IndicatorPixelHeight);

			// Create a new indicator line which is then populated
			// with null values to reset the bar.
			indicatorLines = new IndicatorLine[visibleIndicatorLines];

			for (int index = 0;
				index < visibleIndicatorLines;
				index++)
			{
				indicatorLines[index] = new IndicatorLine();
			}

			// Assign the lines, since we may have changed.
			AssignIndicatorLines();
		}

		/// <summary>
		/// Goes through the buffer lines and assigns those lines to the
		/// indicator lines.
		/// </summary>
		private void AssignIndicatorLines()
		{
			// Go through all the lines and put them in a known and reset state.
			// Reset the lines we're using and clear out the lines we aren't.
			indicatorLinesUsed = 0;

			for (int indicatorLineIndex = 0;
				indicatorLineIndex < visibleIndicatorLines;
				indicatorLineIndex++)
			{
				IndicatorLine indicatorLine = indicatorLines[indicatorLineIndex];

				indicatorLine.Reset();
				indicatorLine.StartLineIndex = -1;
				indicatorLine.EndLineIndex = -1;
			}

			// If we don't have any lines or if we have no height, then don't
			// do anything.
			if (visibleIndicatorLines == 0
				|| editorViewRenderer == null
				|| editorViewRenderer.LineBuffer == null)
			{
				return;
			}

			// Check for lines in the buffer. If we have none, then we can't
			// do anything.
			int lineCount = EditorView.LineBuffer.LineCount;

			if (lineCount == 0)
			{
				return;
			}

			// Figure out roughly how many buffer lines we'll pack into a single
			// indicator line. This is a double since there will be a fractional
			// amount per line but it will fill out the height better.
			double bufferLinesPerIndicatorLine = Math.Max(
				1, (double) lineCount / visibleIndicatorLines);

			// Go through all the lines and allocate the ranges to each indicator
			// line.
			int lastBufferLineIndex = -1;
			double lastFractionalBufferLineIndex = 0.0;

			for (int indicatorLineIndex = 0;
				indicatorLineIndex < visibleIndicatorLines;
				indicatorLineIndex++)
			{
				// Get the indicator line for the current line.
				IndicatorLine indicatorLine = indicatorLines[indicatorLineIndex];

				indicatorLinesUsed++;

				// Figure out how many lines would be used at this point if
				// we were using doubles. We do this since 1.5 means that every
				// other line would have 2 instead of 1, but it would fill out
				// the visible bar better. Otherwise, doing it just through integer
				// math would cut the bar in half when it went from 1 to 2.
				lastFractionalBufferLineIndex += bufferLinesPerIndicatorLine;

				// Figure out the integer indexes for the start and end of this
				// indicator line.
				int startBufferLineIndex = lastBufferLineIndex + 1;
				int endBufferLineIndex = Math.Min(
					lineCount, (int) Math.Floor(lastFractionalBufferLineIndex)) - 1;

				lastBufferLineIndex = endBufferLineIndex;

				// Set up the indicator line for the given line indexes.
				indicatorLine.Visible = true;
				indicatorLine.StartLineIndex = startBufferLineIndex;
				indicatorLine.EndLineIndex = endBufferLineIndex;

				// If this range ends with the last line in the buffer, break out.
				if (endBufferLineIndex >= lineCount - 1)
				{
					break;
				}
			}

			// Since we assigned the lines, we start updating the idle.
			StartBackgroundUpdate();
		}

		/// <summary>
		/// Called when the buffer changes.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnBufferChanged(
			object sender,
			EventArgs args)
		{
			AssignIndicatorLines();
		}

		/// <summary>
		/// Called when the GUI is idle and we can finish updating.
		/// </summary>
		/// <returns>True if this idle should remain in effect.</returns>
		private bool OnIdle()
		{
			// Keep track of our start time since we want to limit how long
			// we are in this function. Using UtcNow is more efficient than
			// local time because it does no time zone processing.
			const int maximumProcessTime = 100;
			DateTime start = DateTime.UtcNow;

			try
			{
				// Look for lines that need to be populated. We can do this since
				// we are on the GUI thread.
				bool startedAtBeginning = lastIndicatorLineUpdated == 0;

				for (int index = lastIndicatorLineUpdated;
					index < indicatorLines.Length;
					index++)
				{
					// If we need data, then do something.
					IndicatorLine indicatorLine = indicatorLines[index];

					if (indicatorLine.NeedIndicators)
					{
						// We need to update this indicator.
						indicatorLine.Update(EditorView, editorViewRenderer);
					}

					// Update the last indicator update.
					lastIndicatorLineUpdated = index;

					// Check to see if we exceeded our time.
					TimeSpan elapsed = DateTime.UtcNow - start;

					if (elapsed.TotalMilliseconds > maximumProcessTime)
					{
						return true;
					}
				}

				// If we didn't start at the beginning, then we start over to see if
				// there are more that need updating. Otherwise, we are done.
				if (startedAtBeginning)
				{
					// We set the flag to indicate we aren't running an idle
					// function and detach from GLib's idle processing. This is
					// done to save CPU cycles when nothing changes.
					using (new WriteLock(sync))
					{
						idleRunning = false;
						return false;
					}
				}
				else
				{
					lastIndicatorLineUpdated = 0;
				}
			}
			finally
			{
				// In all of these cases, we need to queue a redraw.
				QueueDraw();
			}

			return true;
		}

		/// <summary>
		/// Called when a single line changes.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The event arguments.</param>
		private void OnLineChanged(
			object sender,
			LineChangedArgs args)
		{
			foreach (IndicatorLine indicatorLine in indicatorLines)
			{
				if (args.LineIndex >= indicatorLine.StartLineIndex
					&& args.LineIndex <= indicatorLine.EndLineIndex)
				{
					indicatorLine.Reset();
					StartBackgroundUpdate();
				}
			}
		}

		/// <summary>
		/// Called when the text editor's renderer changes.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnTextRendererChanged(
			object sender,
			EventArgs e)
		{
			SetTextRenderer(EditorView.Renderer);
		}

		/// <summary>
		/// Updates the text renderer from the text control.
		/// </summary>
		/// <param name="value">The value.</param>
		private void SetTextRenderer(EditorViewRenderer value)
		{
			// If we had a previous renderer, disconnect the events.
			if (editorViewRenderer != null)
			{
				editorViewRenderer.LineChanged -= OnLineChanged;
				editorViewRenderer.LinesInserted -= OnBufferChanged;
				editorViewRenderer.LinesDeleted -= OnBufferChanged;
			}

			// Set the new indicator buffer.
			editorViewRenderer = value;

			// If we have a new indicator buffer, attach events.
			if (editorViewRenderer != null)
			{
				editorViewRenderer.LineChanged += OnLineChanged;
				editorViewRenderer.LinesInserted += OnBufferChanged;
				editorViewRenderer.LinesDeleted += OnBufferChanged;
			}

			// Rebuild the lines in the buffer.
			AssignIndicatorLines();
			QueueDraw();
		}

		/// <summary>
		/// Starts the background update of the elements if it isn't already
		/// running.
		/// </summary>
		private void StartBackgroundUpdate()
		{
			using (new WriteLock(sync))
			{
				// If the idle is already running, then we don't need to worry
				// about the idle. If it isn't, then set the flag and attach
				// the idle function to the Gtk# loop.
				if (!idleRunning)
				{
					idleRunning = true;
					Idle.Add(OnIdle);
				}
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicatorView"/> class.
		/// </summary>
		/// <param name="editorView">The text editor.</param>
		public IndicatorView(EditorView editorView)
		{
			// Save the control variables.
			if (editorView == null)
			{
				throw new ArgumentNullException("editorView");
			}

			EditorView = editorView;

			// Hoop up to the text editor event.
			editorView.LineBufferChanged += OnTextRendererChanged;
			SetTextRenderer(editorView.Renderer);

			// Start the background update.
			sync = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
		}

		#endregion

		#region Fields

		/// <summary>
		/// The name of the style for the background view.
		/// </summary>
		public const string BackgroundRegionName = "IndicatorViewBackground";

		/// <summary>
		/// The name of the region style for the visible bar area.
		/// </summary>
		public const string VisibleRegionName = "IndicatorViewVisible";

		private EditorViewRenderer editorViewRenderer;

		private bool idleRunning;
		private IndicatorLine[] indicatorLines;
		private int indicatorLinesUsed;

		/// <summary>
		/// Keeps track of the last indicator line updated.
		/// </summary>
		private int lastIndicatorLineUpdated;

		private readonly ReaderWriterLockSlim sync;
		private int visibleIndicatorLines;

		#endregion
	}
}
