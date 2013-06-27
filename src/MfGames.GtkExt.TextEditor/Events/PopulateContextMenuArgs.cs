// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using Gtk;
using MfGames.GtkExt.TextEditor.Editing;

namespace MfGames.GtkExt.TextEditor.Events
{
	/// <summary>
	/// Arguments for when the text editor needs to populate the context
	/// menu with contextual elements. Listeners are able to add elements based
	/// on the current buffer position.
	/// </summary>
	public class PopulateContextMenuArgs: EventArgs
	{
		#region Properties

		/// <summary>
		/// Gets or sets the action context for this context.
		/// </summary>
		/// <value>The action context.</value>
		public EditorViewController Controller { get; set; }

		/// <summary>
		/// Contains the menu that will be shown to the user. If this is set to 
		/// <see langword="null"/>, then no menu will be shown.
		/// </summary>
		public Menu Menu { get; set; }

		#endregion
	}
}
