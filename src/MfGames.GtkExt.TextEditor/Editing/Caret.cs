// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;
using Cairo;
using MfGames.GtkExt.Extensions.Cairo;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.GtkExt.TextEditor.Renderers;

namespace MfGames.GtkExt.TextEditor.Editing
{
	/// <summary>
	/// Represents the elements needed for displaying and rendering the caret.
	/// </summary>
	public class Caret
	{
		#region Properties

		/// <summary>
		/// Gets or sets the buffer position of the caret.
		/// </summary>
		/// <value>The buffer position.</value>
		public BufferPosition Position
		{
			[DebuggerStepThrough] get { return Selection.TailPosition; }

			[DebuggerStepThrough]
			set
			{
				Selection.TailPosition = value;
				Selection.AnchorPosition = value;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Draws the caret using the given context objects.
		/// </summary>
		/// <param name="renderContext">The render context.</param>
		public void Draw(IRenderContext renderContext)
		{
			// Get the draw region.
			Rectangle drawRegion = GetDrawRegion();

			// Make sure the render area intersects with the caret.
			if (!renderContext.RenderRegion.IntersectsWith(drawRegion))
			{
				// Not visible, don't show anything.
				return;
			}

			// Turn off antialiasing for a sharper, thin line.
			Context context = renderContext.CairoContext;

			Antialias oldAntialias = context.Antialias;
			context.Antialias = Antialias.None;

			// Draw the caret on the screen.
			try
			{
				context.LineWidth = 1;
				context.Color = new Color(0, 0, 0, 1);

				context.MoveTo(drawRegion.X, drawRegion.Y);
				context.LineTo(drawRegion.X, drawRegion.Y + drawRegion.Height);
				context.Stroke();
			}
			finally
			{
				// Restore the context.
				context.Antialias = oldAntialias;
			}
		}

		/// <summary>
		/// Gets the region that the caret would be drawn in.
		/// </summary>
		/// <returns></returns>
		public Rectangle GetDrawRegion()
		{
			// Get the coordinates on the screen and the height of the current line.
			int lineHeight;
			PointD point = Position.ToScreenCoordinates(displayContext, out lineHeight);
			double x = point.X;
			double y = point.Y;

			// Translate the buffer coordinates into the screen visible coordinates.
			y -= displayContext.BufferOffsetY;

			// Shift the contents to compenstate for the margins.
			LineBlockStyle style = displayContext.Renderer.GetLineStyle(Position.LineIndex,LineContexts.None);

			x += displayContext.TextX;
			x += style.Left;

			// Return the resulting rectangle.
			return new Rectangle(x, y, 1, lineHeight);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Caret"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public Caret(IDisplayContext displayContext)
		{
			this.displayContext = displayContext;
		}

		#endregion

		#region Fields

		/// <summary>
		/// Contains the selection of the caret.
		/// </summary>
		public BufferSegment Selection;

		private readonly IDisplayContext displayContext;

		#endregion
	}
}
