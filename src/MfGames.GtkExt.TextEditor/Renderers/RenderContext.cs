// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Cairo;
using MfGames.GtkExt.TextEditor.Interfaces;

namespace MfGames.GtkExt.TextEditor.Visuals
{
	/// <summary>
	/// Implements a basic render context used for rendering various elements
	/// of the text editor.
	/// </summary>
	public class RenderContext: IRenderContext
	{
		#region Properties

		/// <summary>
		/// Gets the Cairo context for rendering.
		/// </summary>
		/// <value>The cairo context.</value>
		public Context CairoContext { get; set; }

		/// <summary>
		/// Gets or sets the render region that can be drawn into.
		/// </summary>
		/// <value>The render region.</value>
		public Rectangle RenderRegion { get; set; }

		/// <summary>
		/// Gets or sets the vertical adjustment or offset into the viewing area.
		/// </summary>
		/// <value>The vertical adjustment.</value>
		public double VerticalAdjustment { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="RenderContext"/> class.
		/// </summary>
		/// <param name="cairoContext">The cairo context.</param>
		public RenderContext(Context cairoContext)
		{
			CairoContext = cairoContext;
		}

		#endregion
	}
}
