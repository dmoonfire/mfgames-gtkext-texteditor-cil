// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Cairo;
using Gdk;
using Gtk;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Renderers;
using Global = Gtk.Global;
using Key = Gdk.Key;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Contains the various actions used for moving the caret (cursor) around
	/// the text buffer.
	/// </summary>
	[ActionFixture]
	public static class MenuActions
	{
		#region Methods

		/// <summary>
		/// Moves the caret to the end of the buffer.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Return, ModifierType.Mod1Mask)]
		public static void ShowContextMenu(EditorViewController controller)
		{
			// Get the coordinates to display the menu. Since the popup that
			// sets the coordinates based on the screen, we have to adjust from
			// text-specific coordinates clear to screen coordinates.

			// Start by getting the widget's screen coordinates.
			IDisplayContext displayContext = controller.DisplayContext;
			int screenX,
				screenY;

			displayContext.GdkWindow.GetOrigin(out screenX, out screenY);

			// Figure out the position of the position in the screen. We add
			// the screen relative coordinate to the widget-relative, plus add
			// the height of a single line to shift it down slightly.
			int lineHeight;
			PointD point =
				displayContext.Caret.Position.ToScreenCoordinates(
					displayContext, out lineHeight);

			var widgetY = (int) (screenY + lineHeight + point.Y);

			// Create the context menu and show it on the screen right below
			// where the user is currently focused.
			Menu contextMenu = controller.CreateContextMenu();

			if (contextMenu != null)
			{
				contextMenu.ShowAll();
				contextMenu.Popup(
					null,
					null,
					delegate(Menu delegateMenu,
						out int x,
						out int y,
						out bool pushIn)
					{
						x = screenX;
						y = widgetY;
						pushIn = true;
					},
					3,
					Global.CurrentEventTime);
			}
		}

		#endregion
	}
}
