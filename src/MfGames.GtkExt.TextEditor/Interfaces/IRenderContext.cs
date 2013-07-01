// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Cairo;

namespace MfGames.GtkExt.TextEditor.Interfaces
{
	/// <summary>
	/// Contains information a rendering context including the elements needed
	/// to draw out elements.
	/// </summary>
	public interface IRenderContext
	{
		#region Properties

		/// <summary>
		/// Gets the Cairo context for rendering.
		/// </summary>
		/// <value>The cairo context.</value>
		Context CairoContext { get; }

		/// <summary>
		/// Gets or sets the render region that can be drawn into.
		/// </summary>
		/// <value>The render region.</value>
		Rectangle RenderRegion { get; set; }

		#endregion
	}
}
