// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using C5;
using Cairo;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.GtkExt.TextEditor.Renderers;

namespace MfGames.GtkExt.TextEditor.Margins
{
	/// <summary>
	/// Encapsulates a list of margin renderers. This handles the packing code
	/// and processing visbility, widths, and heights.
	/// </summary>
	public class MarginRendererCollection: LinkedList<MarginRenderer>
	{
		#region Properties

		/// <summary>
		/// Gets the width of the entire collection.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			[DebuggerStepThrough] get { return width; }
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the width or visiblity of the margin changes.
		/// </summary>
		public event EventHandler WidthChanged;

		#endregion

		#region Methods

		public override bool Add(MarginRenderer item)
		{
			item.WidthChanged += OnWidthChanged;
			RecalculateWidth();
			return base.Add(item);
		}

		/// <summary>
		/// Draws the margins at the given position.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="renderContext">The render context.</param>
		/// <param name="lineIndex">The line index being rendered.</param>
		/// <param name="point">The point of the specific line number.</param>
		/// <param name="height">The height of the rendered line.</param>
		/// <param name="lineBlockStyle">The line block style.</param>
		public void Draw(
			IDisplayContext displayContext,
			IRenderContext renderContext,
			int lineIndex,
			PointD point,
			double height,
			LineBlockStyle lineBlockStyle)
		{
			// Go through the margins and draw each one so they don't overlap.
			double dx = point.X;

			foreach (MarginRenderer marginRenderer in this)
			{
				// If it isn't visible, then we do nothing.
				if (!marginRenderer.Visible)
				{
					continue;
				}

				// Draw out the individual margin.
				marginRenderer.Draw(
					displayContext,
					renderContext,
					lineIndex,
					new PointD(dx, point.Y),
					height,
					lineBlockStyle);

				// Add to the x coordinate so we don't overlap the renders.
				dx += marginRenderer.Width;
			}
		}

		public override void Insert(
			int i,
			MarginRenderer item)
		{
			item.WidthChanged += OnWidthChanged;
			RecalculateWidth();
			base.Insert(i, item);
		}

		public override bool Remove(MarginRenderer item)
		{
			item.WidthChanged -= OnWidthChanged;
			RecalculateWidth();
			return base.Remove(item);
		}

		/// <summary>
		/// Resets all the individual margin renderers in the collection.
		/// </summary>
		public void Reset()
		{
			supressEvents = true;

			try
			{
				foreach (MarginRenderer marginRenderer in this)
				{
					marginRenderer.Reset();
				}
			}
			finally
			{
				supressEvents = false;
			}
		}

		/// <summary>
		/// Resizes the margins to fit the new line buffer.
		/// </summary>
		/// <param name="editorView">The text editor.</param>
		public void Resize(EditorView editorView)
		{
			Reset();

			foreach (MarginRenderer marginRenderer in this)
			{
				marginRenderer.Resize(editorView);
			}
		}

		/// <summary>
		/// Fires the <see cref="WidthChanged"/> event.
		/// </summary>
		private void FireWidthChanged()
		{
			if (WidthChanged != null
				&& !supressEvents)
			{
				WidthChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Called when the width of a child element is changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnWidthChanged(
			object sender,
			EventArgs e)
		{
			RecalculateWidth();
		}

		/// <summary>
		/// Recalculates the width of the entire collection by adding up the
		/// widths of all the margins within it.
		/// </summary>
		private void RecalculateWidth()
		{
			// Gather up the new total width of the collection.
			int newWidth = 0;

			foreach (MarginRenderer marginRenderer in this)
			{
				if (marginRenderer.Visible)
				{
					newWidth += marginRenderer.Width;
				}
			}

			// If the width has changed, then fire an event.
			if (newWidth != width)
			{
				width = newWidth;
				FireWidthChanged();
			}
		}

		#endregion

		#region Fields

		private bool supressEvents;
		private int width;

		#endregion
	}
}
