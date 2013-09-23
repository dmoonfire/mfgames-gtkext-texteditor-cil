// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Gtk;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.Locking;
using Action = System.Action;
using Layout = Pango.Layout;
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// If we have a context, never cache it.
			if (lineContexts != LineContexts.None)
			{
				return base.GetLineLayout(lineIndex, lineContexts);
			}

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			Layout layout;

			using (new ReadLock(access))
			{
				CachedLine line = GetCachedLine(lineIndex);
				layout = line.Layout;
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			int results = 0;

			using (new ReadLock(access))
			{
				// Normalize to our line count.
				endLineIndex = Math.Min(endLineIndex, LineBuffer.LineCount - 1);

				// Go through the lines and get the count.
				for (int index = startLineIndex;
					index <= endLineIndex;
					index++)
				{
					CachedLine line = GetCachedLine(index);

					results += line.Height;
				}
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();

			// Return the resulting height of the region.
			return results;
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			using (new ReadLock(access))
			{
				// Start the start and end line to the first one.
				startLine = endLine = 0;

				// Go through and find the lines that are within range of the
				// view port.
				int height = 0;
				double bottom = viewArea.Y + viewArea.Height;

				for (int lineIndex = 0;
					lineIndex < lines.Count;
					lineIndex++)
				{
					// Get the line for the current index.
					CachedLine line = GetCachedLine(lineIndex);

					// If the line is current below the view port, then update
					// the two lines.
					endLine = lineIndex;

					if (height < viewArea.Y)
					{
						// We are below the line, so update it.
						startLine = lineIndex;
					}

					if (height > bottom)
					{
						break;
					}

					// Update the line height.
					height += line.Height;
				}
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// If we have a context, never cache it.
			if (lineContexts != LineContexts.None)
			{
				return base.GetLineStyle(lineIndex, lineContexts);
			}

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			LineBlockStyle style;

			using (new ReadLock(access))
			{
				CachedLine line = GetCachedLine(lineIndex);

				style = line.Style;
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
			// We need to get a write lock on the entire cache to avoid anything
			// else making changes.
			using (new NestableWriteLock(access))
			{
				// Go through each of the lines in the buffer.
				foreach (CachedLine line in lines)
				{
					line.Reset();
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// Make sure we're locked when we reset the buffer.
			using (new WriteLock(access))
			{
				base.SetLineBuffer(value);
				Clear();
				AllocateLines();
				backgroundUpdater.Restart();
			}
		}

		/// <summary>
		/// Updates the caret/selection on screen.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="previousSelection">The previous selection.</param>
		public override void UpdateSelection(
			IDisplayContext displayContext,
			TextRange previousSelection)
		{
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// We need to get a write lock on the entire cache to avoid
			// anything else making changes.
			using (new WriteLock(access))
			{
				// Only update the caches if one of the current or previous
				// selections was actually selecting something.
				TextRange currentSelection = displayContext.Caret.Selection;

				if (!previousSelection.IsEmpty
					|| !currentSelection.IsEmpty)
				{
					// Clear out the cache for all the lines in the new and old selections.
					int endLineIndex =
						displayContext.LineBuffer.NormalizeLineIndex(
							currentSelection.EndPosition.LinePosition);
					int previousEndLineIndex =
						displayContext.LineBuffer.NormalizeLineIndex(
							previousSelection.EndPosition.LinePosition);

					for (int lineIndex = currentSelection.StartPosition.LinePosition;
						lineIndex <= endLineIndex;
						lineIndex++)
					{
						CachedLine line = lines[lineIndex];
						line.Reset();
					}

					for (int lineIndex = previousSelection.StartPosition.LinePosition;
						lineIndex <= previousEndLineIndex;
						lineIndex++)
					{
						CachedLine line = lines[lineIndex];
						line.Reset();
					}
				}

				// Call the base implementation.
				// TODO base.UpdateSelection(displayContext, previousSelection);
			}

			// Process any queued changes.
			ProcessQueuedLineChanges();
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
			Application.Invoke(ProcessQueuedLineChanges);

			// Start the background cacher to handle the lines that aren't
			// visible on screen.
			backgroundUpdater.Restart();
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
			Application.Invoke(ProcessQueuedLineChanges);
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
			Application.Invoke(ProcessQueuedLineChanges);

			// Start the background cacher to handle the lines that aren't
			// visible on screen.
			backgroundUpdater.Restart();
		}

		private void AllocateLines()
		{
			LineBuffer lineBuffer = LineBuffer;

			if (lineBuffer != null)
			{
				for (int index = 0;
					index < lineBuffer.LineCount;
					index++)
				{
					lines.Add(new CachedLine());
				}
			}
		}

		/// <summary>
		/// Checks the current thread to see if the operation is happening on
		/// the GUI thread.
		/// </summary>
		private void CheckGuiThread()
		{
			// Check the current thread against the thread we've been created on.
			Thread currentThread = Thread.CurrentThread;

			if (currentThread != thread)
			{
				throw new InvalidOperationException(
					"The requested operation was not called on the GUI thread.");
			}
		}

		/// <summary>
		/// Clears out all the windows and returns the larger arrays back into
		/// the allocation list.
		/// </summary>
		private void Clear()
		{
			lines.Clear();
		}

		/// <summary>
		/// Gets the cached line and ensures it is populated.
		/// </summary>
		/// <param name="lineIndex">The line.</param>
		/// <returns></returns>
		private CachedLine GetCachedLine(int lineIndex)
		{
			CachedLine cachedLine = lines[lineIndex];
			cachedLine.Cache(EditorViewRenderer, lineIndex);
			return cachedLine;
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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// Get the line and reset it.
			CachedLine line = lines[args.LineIndex];

			line.Reset();

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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// It is very important for performance and caching that we delete
			// the line given instead of rebuilding the counts. Since we are
			// dealing with indexes, we need to get the count.
			int count = args.EndLineIndex - args.StartLineIndex + 1;

			lines.RemoveRange(args.StartLineIndex, count);

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
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// Create a short list of new cache items for the line. Since we are
			// dealing with indexes, we need to get the count.
			int count = args.EndLineIndex - args.StartLineIndex + 1;
			var newLines = new CachedLine[count];

			for (int index = 0;
				index < count;
				index++)
			{
				newLines[index] = new CachedLine();
			}

			// Insert the lines into the array.
			lines.InsertRange(args.StartLineIndex, newLines);

			// Call the base implementation to cascade the events up.
			base.OnLinesInserted(sender, args);
		}

		/// <summary>
		/// Processes any queued line changes. If a lock cannot be acquired,
		/// then this does nothing.
		/// </summary>
		private void ProcessQueuedLineChanges()
		{
			// Make sure we're on the proper thread.
			CheckGuiThread();

			// We have to make sure we aren't making changes to the queue
			// while we're processing these changes.
			lock (queuedLineEvents)
			{
				// Try to get a write lock on the access object. We choose not
				// to wait any time since we'll try again after each lock.
				if (!access.IsWriteLockHeld
					&& access.TryEnterWriteLock(0))
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

		private void ProcessQueuedLineChanges(
			object sender,
			EventArgs args)
		{
			ProcessQueuedLineChanges();
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
		/// Initializes a new instance of the <see cref="CachedTextRenderer" /> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="editorViewRenderer">The text renderer.</param>
		public CachedTextRenderer(
			IDisplayContext displayContext,
			EditorViewRenderer editorViewRenderer)
			: base(displayContext, editorViewRenderer)
		{
			// Keep track of the thread we've been created on.
			thread = Thread.CurrentThread;

			// Set the cache window properties.
			access = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
			queuedLineEvents = new List<Action>();

			// Create a collection of the initial buffer lines.
			lines = new CachedLineList();

			AllocateLines();

			// Create a background loader that will attempt to calculate the
			// layout and heights of lines using the GUI's idle loop.
			backgroundUpdater = new BackgroundCachedLineUpdater(this, lines);
			backgroundUpdater.Restart();
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

		private readonly BackgroundCachedLineUpdater backgroundUpdater;

		private int? lineHeight;

		/// <summary>
		/// Contains all the cached information about each line in the buffer.
		/// </summary>
		private readonly CachedLineList lines;

		private readonly List<Action> queuedLineEvents;
		private readonly Thread thread;

		#endregion
	}
}
