// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MfGames.Extensions.System.Collections.Generic;
using MfGames.GtkExt.TextEditor.Buffers;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.Locking;
using Pango;
using Rectangle = Cairo.Rectangle;

namespace MfGames.GtkExt.TextEditor.Renderers.Cache
{
	/// <summary>
	/// Implements a dynamic cache around a <see cref="EditorViewRenderer"/> to reduce
	/// processing overhead at the expense of larger memory usage.
	/// </summary>
	public class CachedTextRenderer: EditorViewRendererDecorator
	{
		#region Properties

		/// <summary>
		/// Gets the line buffer associated with this renderer.
		/// </summary>
		/// <value>The line buffer.</value>
		public override LineBuffer LineBuffer
		{
			[DebuggerStepThrough] get { return base.LineBuffer; }
		}

		/// <summary>
		/// Sets the width on the underlying buffer and resets the cache windows
		/// if the width changes.
		/// </summary>
		/// <value>The width.</value>
		public override int Width
		{
			set
			{
				// Check to see if we have a chance. If we don't, then we don't
				// have to do anything.
				if (base.Width == value)
				{
					return;
				}

				// Reset the cache windows since the line layout didn't change,
				// but we have to recalculate all the heights again.
				Reset();

				// Set the new width in the underlying buffer.
				base.Width = value;
			}
		}

		/// <summary>
		/// Gets the size of a window cache.
		/// </summary>
		/// <value>The size of the window.</value>
		public int WindowSize
		{
			get { return windowSize; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets the line layout for a given line.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <param name="lineContexts"></param>
		/// <returns></returns>
		public override Layout GetLineLayout(
			int lineIndex,
			LineContexts lineContexts)
		{
			// If we have a context, never cache it.
			if (lineContexts != LineContexts.None)
			{
				return base.GetLineLayout(lineIndex, lineContexts);
			}

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			Layout layout;

			using (new WriteLock(access))
			{
				// Make sure we have all the windows allocated.
				AllocateWindows();

				// Go through the windows and find the starting one.
				lineIndex = LineBuffer.NormalizeLineIndex(lineIndex);
				int windowIndex = GetWindowIndex(lineIndex);
				CachedWindow window = windows[windowIndex];

				// Get the layout from the window.
				layout = window.GetLineLayout(DisplayContext, lineIndex);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();

			// Return the resulting layout.
			return layout;
		}

		/// <summary>
		/// Uses the cache to retrieve the heights of the individual lines.
		/// </summary>
		/// <param name="startLineIndex">The start line.</param>
		/// <param name="endLineIndex">The end line.</param>
		/// <returns></returns>
		public override int GetLineLayoutHeight(
			int startLineIndex,
			int endLineIndex)
		{
			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			int height;

			using (new WriteLock(access))
			{
				AllocateWindows();
				height = InternalGetLineLayoutHeight(startLineIndex, endLineIndex);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();

			// Return the resulting height of the region.
			return height;
		}

		/// <summary>
		/// Gets the height of a single line of "normal" text.
		/// </summary>
		/// <returns></returns>
		public override int GetLineLayoutHeight()
		{
			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			int height;

			using (new WriteLock(access))
			{
				if (!lineHeight.HasValue)
				{
					lineHeight = base.GetLineLayoutHeight();
				}

				height = lineHeight.Value;
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();

			// Return the resulting height.
			return height;
		}

		/// <summary>
		/// Gets the lines that are visible in the given view area.
		/// </summary>
		/// <param name="viewArea">The view area.</param>
		/// <param name="startLine">The start line.</param>
		/// <param name="endLine">The end line.</param>
		public override void GetLineLayoutRange(
			Rectangle viewArea,
			out int startLine,
			out int endLine)
		{
			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			using (new WriteLock(access))
			{
				// Go through and find the windows that have the starting and ending
				// area.
				int height = 0;
				int startWindowIndex = -1;
				int endWindowIndex = -1;
				int startWindowHeight = 0;
				int endWindowHeight = 0;
				double bottom = viewArea.Y + viewArea.Height;

				foreach (CachedWindow window in windows)
				{
					// Get the window height.
					int windowHeight = window.GetLineLayoutHeight(DisplayContext);

					// Check for starting line.
					if (viewArea.Y >= height
						&& viewArea.Y <= height + windowHeight)
					{
						// The starting line is somewhere in this window.
						startWindowIndex = window.WindowIndex;
						startWindowHeight = height;
					}

					// Check for ending line.
					if (bottom >= height
						&& bottom <= height + windowHeight)
					{
						// The starting line is somewhere in this window.
						endWindowIndex = window.WindowIndex;
						endWindowHeight = height;
					}

					// If we have both a start and end window, we're done with this
					// loop and can process it.
					if (startWindowIndex >= 0
						&& endWindowIndex >= 0)
					{
						break;
					}

					// Add to the current height.
					height += windowHeight;
				}

				// Make sure we have a starting and ending line index. If we don't have
				// a starting line, then just show the last one.
				if (startWindowIndex == -1)
				{
					startLine = endLine = LineBuffer.LineCount - 1;
					return;
				}

				// Determine what the start line is inside the starting cache.
				var startWindowOffset = (int) (viewArea.Y - startWindowHeight);
				startLine = windows[startWindowIndex].GetLineLayoutContaining(
					DisplayContext, startWindowOffset);

				// Get the ending line from the ending cache.
				if (endWindowIndex == -1)
				{
					endLine = LineBuffer.LineCount - 1;
					return;
				}

				var endWindowOffset = (int) (viewArea.Y + viewArea.Height - endWindowHeight);
				endLine = windows[endWindowIndex].GetLineLayoutContaining(
					DisplayContext, endWindowOffset);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Gets the line style for a given line.
		/// </summary>
		/// <param name="lineIndex">The line number.</param>
		/// <param name="lineContexts">The line contexts.</param>
		/// <returns></returns>
		public override LineBlockStyle GetLineStyle(
			int lineIndex,
			LineContexts lineContexts)
		{
			// If we have a context, never cache it.
			if (lineContexts != LineContexts.None)
			{
				return base.GetLineStyle(lineIndex, lineContexts);
			}

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			LineBlockStyle style;

			using (new WriteLock(access))
			{
				// Make sure we have all the windows allocated.
				AllocateWindows();

				// Go through the windows and find the starting one.
				lineIndex = LineBuffer.NormalizeLineIndex(lineIndex);
				int windowIndex = GetWindowIndex(lineIndex);
				CachedWindow window = windows[windowIndex];

				// Get the layout from the window.
				style = window.GetLineStyle(DisplayContext, lineIndex);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();

			// Return the resulting style.
			return style;
		}

		/// <summary>
		/// Marks the individual windows as needing to recalculate their heights.
		/// </summary>
		public override void Reset()
		{
			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			using (new WriteLock(access))
			{
				// Reset the line heights.
				lineHeight = null;

				// Reset each of the windows.
				foreach (CachedWindow window in windows)
				{
					window.Reset();
					Clear(window);
				}
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Sets the line buffer since the renderer.
		/// </summary>
		/// <param name="value">The value.</param>
		public override void SetLineBuffer(LineBuffer value)
		{
			base.SetLineBuffer(value);
			Reset();
		}

		/// <summary>
		/// Updates the caret/selection on screen.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="previousSelection">The previous selection.</param>
		public override void UpdateSelection(
			IDisplayContext displayContext,
			BufferSegment previousSelection)
		{
			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			using (new WriteLock(access))
			{
				// Only update the caches if one of the current or previous
				// selections was actually selecting something.
				BufferSegment currentSelection = displayContext.Caret.Selection;

				if (!previousSelection.IsEmpty
					|| !currentSelection.IsEmpty)
				{
					// Clear out the cache for all the lines in the new and old selections.
					int endLineIndex =
						displayContext.LineBuffer.NormalizeLineIndex(
							currentSelection.EndPosition.LineIndex);
					int previousEndLineIndex =
						displayContext.LineBuffer.NormalizeLineIndex(
							previousSelection.EndPosition.LineIndex);

					for (int lineIndex = currentSelection.StartPosition.LineIndex;
						lineIndex <= endLineIndex;
						lineIndex++)
					{
						// Get the window for the line change and reset that window.
						int cachedWindowIndex = GetWindowIndex(lineIndex);
						CachedWindow cachedWindow = windows[cachedWindowIndex];

						cachedWindow.Reset(lineIndex - cachedWindow.WindowStartLine);
					}

					for (int lineIndex = previousSelection.StartPosition.LineIndex;
						lineIndex <= previousEndLineIndex;
						lineIndex++)
					{
						// Get the window for the line change and reset that window.
						int cachedWindowIndex = GetWindowIndex(lineIndex);
						CachedWindow cachedWindow = windows[cachedWindowIndex];

						cachedWindow.Reset(lineIndex - cachedWindow.WindowStartLine);
					}
				}

				// Call the base implementation.
				// TODO base.UpdateSelection(displayContext, previousSelection);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Gets a set of allocated cached lines, releasing any as needed.
		/// </summary>
		/// <returns></returns>
		internal CachedLine[] GetAllocatedCachedLines()
		{
			// Get an array of lines from the list.
			if (allocatedLines.Count == 0)
			{
				// We don't have any allocated lines, so free the last.
				ClearLeastRecentlyUsedWindow();
			}

			// Return the first set of allocated lines in the array.
			CachedLine[] first = allocatedLines[0];
			allocatedLines.RemoveAt(0);
			return first;
		}

		/// <summary>
		/// Retrieves the heights of a given line range, without locking.
		/// </summary>
		/// <param name="startLineIndex">Start index of the line.</param>
		/// <param name="endLineIndex">End index of the line.</param>
		/// <returns></returns>
		internal int InternalGetLineLayoutHeight(
			int startLineIndex,
			int endLineIndex)
		{
			// Normalize the end line so we don't go over our bounds.
			endLineIndex = LineBuffer.NormalizeLineIndex(endLineIndex);

			// Go through the windows and find the starting one.
			int startingWindowIndex = GetWindowIndex(startLineIndex);
			int endingWindowIndex = GetWindowIndex(endLineIndex);

			CachedWindow startingWindow = windows[startingWindowIndex];
			CachedWindow endingWindow = windows[endingWindowIndex];

			// Make sure that both the starting and ending windows are populated.
			// This handles if the windows are the same since Populate() checks
			// the loaded status.
			startingWindow.Populate(DisplayContext);
			endingWindow.Populate(DisplayContext);

			// Get the height of the lines inside the starting window.
			int height = startingWindow.GetLineLayoutHeight(
				DisplayContext, startLineIndex, endLineIndex);

			// If the end window is different, get those line heights also.
			if (startingWindowIndex != endingWindowIndex)
			{
				height += endingWindow.GetLineLayoutHeight(
					DisplayContext, startLineIndex, endLineIndex);
			}

			// Retrieve all the cache windows between the two ranges.
			for (int windowIndex = startingWindowIndex + 1;
				windowIndex < endingWindowIndex;
				windowIndex++)
			{
				CachedWindow window = windows[windowIndex];
				height += window.GetLineLayoutHeight(DisplayContext);
			}
			return height;
		}

		/// <summary>
		/// Called when a line is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The args.</param>
		protected override void OnLineChanged(
			object sender,
			LineChangedArgs args)
		{
			// Queue up a line change since we need to keep track of the changes
			// but this might be called while another thread is locked.
			QueueLineEvent(() => ProcessLineChanged(sender, args));

			// Attempt to resolve the updates. This will do nothing if a lock
			// is currently acquired.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Called when the inner buffer deletes lines.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The args.</param>
		protected override void OnLinesDeleted(
			object sender,
			LineRangeEventArgs args)
		{
			// Queue up a line change since we need to keep track of the changes
			// but this might be called while another thread is locked.
			QueueLineEvent(() => ProcessLinesDeleted(sender, args));

			// Attempt to resolve the updates. This will do nothing if a lock
			// is currently acquired.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Called when the inner buffer inserts lines.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The args.</param>
		protected override void OnLinesInserted(
			object sender,
			LineRangeEventArgs args)
		{
			// Queue up a line change since we need to keep track of the changes
			// but this might be called while another thread is locked.
			QueueLineEvent(() => ProcessLinesInserted(sender, args));

			// Attempt to resolve the updates. This will do nothing if a lock
			// is currently acquired.
			ProcessQueuedLineChanges();
		}

		/// <summary>
		/// Goes through and makes sure all the windows are allocated for the
		/// underlying buffer.
		/// </summary>
		private void AllocateWindows()
		{
			// If we have no lines, then we don't need any buffers.
			int lineCount = LineBuffer.LineCount;

			if (lineCount == 0)
			{
				Clear();
			}

			// We need a window for every windowSize lines.
			int windowsNeeded = lineCount / windowSize;

			if (lineCount % windowSize > 0)
			{
				windowsNeeded++;
			}

			// If we don't have enough, allocate more.
			while (windows.Count < windowsNeeded)
			{
				windows.Add(new CachedWindow(this, windows.Count));
			}

			// If we have too many, then free them.
			while (windows.Count > windowsNeeded)
			{
				CachedWindow window = windows.RemoveLast();
				Clear(window);
			}
		}

		/// <summary>
		/// Clears out all the windows and returns the larger arrays back into
		/// the allocation list.
		/// </summary>
		private void Clear()
		{
			// Go through all the windows and returned the allocated lines back
			// to the list.
			foreach (CachedWindow window in windows)
			{
				Clear(window);
			}

			// Clear out the array.
			windows.Clear();
		}

		/// <summary>
		/// Clears the specified window of allocations.
		/// </summary>
		/// <param name="window">The window.</param>
		private void Clear(CachedWindow window)
		{
			if (window.Lines != null)
			{
				// Clear out the lines to make sure the garbage collection can
				// release them as needed.
				foreach (CachedLine line in window.Lines)
				{
					line.Reset();
				}

				// Move the lines list back into the allocation list.
				allocatedLines.Add(window.Lines);
				window.Lines = null;
			}
		}

		/// <summary>
		/// Clears the least recently used window that has lines.
		/// </summary>
		private void ClearLeastRecentlyUsedWindow()
		{
			// Go through the windows and find the cache window that has the
			// oldest data.
			int lruWindowIndex = -1;
			DateTime lruWindowAccessed = DateTime.MaxValue;

			for (int index = 0;
				index < windows.Count;
				index++)
			{
				// If the window doesn't have lines, we don't use it.
				CachedWindow window = windows[index];

				if (window.Lines == null)
				{
					continue;
				}

				// Check to see if this window is older than the current.
				if (window.LastAccessed < lruWindowAccessed)
				{
					lruWindowAccessed = window.LastAccessed;
					lruWindowIndex = index;
				}
			}

			// The index will contains the last index.
			if (lruWindowIndex == -1)
			{
				throw new Exception("Cannot find LRU cache window");
			}

			// Clear this window.
			Clear(windows[lruWindowIndex]);
		}

		/// <summary>
		/// Gets the index of the window for a given line.
		/// </summary>
		/// <param name="line">The line.</param>
		/// <returns></returns>
		private int GetWindowIndex(int line)
		{
			// Figure out the window based on the windowSize.
			int window = line / windowSize;
			return window;
		}

		/// <summary>
		/// Processes the line changed. This will never be called inside the
		/// access' write lock.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The args.</param>
		private void ProcessLineChanged(
			object sender,
			LineChangedArgs args)
		{
			// Make sure we allocated all the windows.
			AllocateWindows();

			// Get the window for the line change and reset that line.
			int cachedWindowIndex = GetWindowIndex(args.LineIndex);
			CachedWindow cachedWindow = windows[cachedWindowIndex];

			cachedWindow.Reset(args.LineIndex - cachedWindow.WindowStartLine);

			// Call the base implementation to cascade the events up.
			base.OnLineChanged(sender, args);
		}

		/// <summary>
		/// Processes the lines deleted. This will never be called inside the
		/// access' write lock.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="LineRangeEventArgs"/> instance containing the event data.</param>
		private void ProcessLinesDeleted(
			object sender,
			LineRangeEventArgs args)
		{
			// Clear out everything and reallocate the windows.
			Clear();
			AllocateWindows();

			// Call the base implementation to cascade the events up.
			base.OnLinesDeleted(sender, args);
		}

		/// <summary>
		/// Processes the lines inserted. This will never be called inside the
		/// access' write lock.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="LineRangeEventArgs"/> instance containing the event data.</param>
		private void ProcessLinesInserted(
			object sender,
			LineRangeEventArgs args)
		{
			// Clear out everything and reallocate the windows.
			Clear();
			AllocateWindows();

			// Call the base implementation to cascade the events up.
			base.OnLinesInserted(sender, args);
		}

		/// <summary>
		/// Processes any queued line changes. If a lock cannot be acquired,
		/// then this does nothing.
		/// </summary>
		private void ProcessQueuedLineChanges()
		{
			// We have to make sure we aren't making changes to the queue
			// while we're processing these changes.
			lock (queuedLineEvents)
			{
				// Try to get a write lock on the access object. We choose not
				// to wait any time since we'll try again after each lock.
				if (access.TryEnterWriteLock(0))
				{
					try
					{
						// We are inside the lock, so process the changes.
						foreach (Action action in queuedLineEvents)
						{
							action();
						}

						// Clear out the queued chanegs lock.
						queuedLineEvents.Clear();
					}
					finally
					{
						// We need to release the write lock.
						access.ExitWriteLock();
					}
				}
			}
		}

		/// <summary>
		/// Queues a line change for processing.
		/// </summary>
		/// <param name="action">The action.</param>
		private void QueueLineEvent(Action action)
		{
			// Add the line index into the queued changes. If we have a
			// negative already in there, then we don't add in new changes.
			// Likewise, if we now have a -1, we make sure it is the only
			// one in the list.
			lock (queuedLineEvents)
			{
				queuedLineEvents.Add(action);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CachedTextRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="lineBuffer">The line buffer.</param>
		public CachedTextRenderer(
			IDisplayContext displayContext,
			LineBuffer lineBuffer)
			: this(displayContext, new LineBufferRenderer(displayContext, lineBuffer))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CachedTextRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="editorViewRenderer">The text renderer.</param>
		public CachedTextRenderer(
			IDisplayContext displayContext,
			EditorViewRenderer editorViewRenderer)
			: this(displayContext, editorViewRenderer, 8, 16)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CachedTextRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="editorViewRenderer">The text renderer.</param>
		/// <param name="maximumLoadedWindows">The maximum loaded windows.</param>
		/// <param name="windowSize">Size of the window.</param>
		public CachedTextRenderer(
			IDisplayContext displayContext,
			EditorViewRenderer editorViewRenderer,
			int maximumLoadedWindows,
			int windowSize)
			: base(displayContext, editorViewRenderer)
		{
			// Set the cache window properties.
			access = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
			queuedLineEvents = new List<Action>();
			this.windowSize = windowSize;

			// Create the collection of windows.
			windows = new List<CachedWindow>();

			// Pre-create the window arrays.
			allocatedLines = new List<CachedLine[]>();

			for (int index = 0;
				index < maximumLoadedWindows;
				index++)
			{
				// Create the array and add it to the allocated list.
				var lines = new CachedLine[windowSize];

				allocatedLines.Add(lines);

				for (int line = 0;
					line < windowSize;
					line++)
				{
					lines[line] = new CachedLine();
				}
			}
		}

		#endregion

		#region Fields

		/// <summary>
		/// The access lock to handle the fact that most of these functions
		/// can come in from different threads.
		/// </summary>
		private readonly ReaderWriterLockSlim access;

		/// <summary>
		/// Contains a list of allocated lines that were created but are currently
		/// not in use. This is to avoid memory pressure by allocating them once
		/// and not freeing the memory until the class is freed.
		/// </summary>
		private readonly List<CachedLine[]> allocatedLines;

		private int? lineHeight;
		private readonly List<Action> queuedLineEvents;

		/// <summary>
		/// Contains the size of the individual windows.
		/// </summary>
		private readonly int windowSize;

		/// <summary>
		/// Contains all the windows in this cache.
		/// </summary>
		private readonly List<CachedWindow> windows;

		#endregion
	}
}
