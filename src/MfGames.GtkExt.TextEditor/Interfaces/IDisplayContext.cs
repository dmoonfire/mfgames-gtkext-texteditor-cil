// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Gtk;
using MfGames.GtkExt.TextEditor.Editing;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Styles;
using MfGames.GtkExt.TextEditor.Renderers;
using Pango;
using Layout = Pango.Layout;
using Rectangle = Cairo.Rectangle;
using Style = Gtk.Style;
using Window = Gdk.Window;

namespace MfGames.GtkExt.TextEditor.Interfaces
{
	/// <summary>
	/// Contains information about the display and its appearance.
	/// </summary>
	public interface IDisplayContext
	{
		#region Properties

		/// <summary>
		/// Gets or sets the vertical adjustment or offset into the viewing area.
		/// </summary>
		/// <value>The vertical adjustment.</value>
		double BufferOffsetY { get; }

		/// <summary>
		/// Gets the caret used to indicate where the user is editing.
		/// </summary>
		/// <value>The caret.</value>
		Caret Caret { get; }

		/// <summary>
		/// Gets the clipboard associated with this editor.
		/// </summary>
		/// <value>The clipboard.</value>
		Clipboard Clipboard { get; }

		/// <summary>
		/// Gets the GDK window associated with this context.
		/// </summary>
		/// <value>The GDK window.</value>
		Window GdkWindow { get; }

		/// <summary>
		/// Gets the GTK style associated with this context.
		/// </summary>
		/// <value>The GTK style.</value>
		Style GtkStyle { get; }

		/// <summary>
		/// Gets the line buffer associated with the context.
		/// </summary>
		/// <value>The line buffer.</value>
		LineBuffer LineBuffer { get; }

		/// <summary>
		/// Gets the Pango context associated with this display.
		/// </summary>
		/// <value>The pango context.</value>
		Context PangoContext { get; }

		/// <summary>
		/// Gets the line layout buffer.
		/// </summary>
		/// <value>The line layout buffer.</value>
		EditorViewRenderer Renderer { get; }

		/// <summary>
		/// Gets the width of the area that can be used for rendering text.
		/// </summary>
		/// <value>The width of the text.</value>
		int TextWidth { get; }

		/// <summary>
		/// Gets the text X coordinate.
		/// </summary>
		/// <value>The text X.</value>
		int TextX { get; }

		/// <summary>
		/// Gets the theme collection for this display.
		/// </summary>
		/// <value>The theme.</value>
		Theme Theme { get; }

		/// <summary>
		/// Gets the vertical adjustment.
		/// </summary>
		/// <value>The vertical adjustment.</value>
		Adjustment VerticalAdjustment { get; }

		/// <summary>
		/// Gets or sets the word splitter.
		/// </summary>
		/// <value>The word splitter.</value>
		IWordSplitter WordSplitter { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Requests the entire widget is redrawn.
		/// </summary>
		void RequestRedraw();

		/// <summary>
		/// Requests the given region is redrawn.
		/// </summary>
		/// <param name="region">The widget-relative region.</param>
		void RequestRedraw(Rectangle region);

		/// <summary>
		/// Requests the editor scroll to the caret.
		/// </summary>
		void RequestScrollToCaret();

		/// <summary>
		/// Scrolls the display to the caret.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		void ScrollToCaret(BufferPosition bufferPosition);

		/// <summary>
		/// Sets the layout according to the given layout and style.
		/// </summary>
		/// <param name="layout">The layout.</param>
		/// <param name="style">The style.</param>
		/// <param name="width">The width.</param>
		void SetLayout(
			Layout layout,
			BlockStyle style,
			int width);

		#endregion
	}
}
