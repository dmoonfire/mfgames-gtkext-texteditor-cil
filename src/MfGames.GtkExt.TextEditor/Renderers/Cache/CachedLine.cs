// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.Extensions.Pango;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using Pango;

namespace MfGames.GtkExt.TextEditor.Renderers.Cache
{
	/// <summary>
	/// Contains information about a single cached line in memory. This
	/// contains information about the height and style for a given line.
	/// </summary>
	internal class CachedLine
	{
		#region Properties

		/// <summary>
		/// Gets or sets the height of the line.
		/// </summary>
		/// <value>The height.</value>
		public int Height { get; set; }

		/// <summary>
		/// Determines if the line has been cached already.
		/// </summary>
		public bool IsCached
		{
			get { return Layout != null; }
		}

		/// <summary>
		/// Gets or sets the Pango layout for the line.
		/// </summary>
		/// <value>The layout.</value>
		public Layout Layout { get; set; }

		/// <summary>
		/// Gets or sets the style for the line.
		/// </summary>
		/// <value>The style.</value>
		public LineBlockStyle Style { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Caches information about a line into the cached line.
		/// </summary>
		/// <param name="view">The view.</param>
		/// <param name="line">The line.</param>
		public void Cache(
			EditorViewRenderer view,
			int line)
		{
			// If we already have a layout, we don't need to do anything.
			if (Layout != null)
			{
				return;
			}

			// Cache various elements of the rendering. This is an expensive
			// operation, so we want to minimize it.
			Layout layout = view.GetLineLayout(line, LineContexts.None);
			LineBlockStyle style = view.GetLineStyle(line, LineContexts.None);

			Style = style;
			Layout = layout;
			Height = (int) (layout.GetPixelHeight() + style.Height);
		}

		/// <summary>
		/// Resets the cached line.
		/// </summary>
		public void Reset()
		{
			Height = 0;
			Style = null;
			Layout = null;
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return String.Format("CachedLine: Height={0}", Height);
		}

		#endregion
	}
}
