// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Determines the usage of a style and can be used for filtering or
	/// controlling modifications.
	/// </summary>
	public enum StyleUsage: byte
	{
		/// <summary>
		/// Indicates that the style is required by the text editor.
		/// </summary>
		Editor,

		/// <summary>
		/// Indicates that the style is application-specific.
		/// </summary>
		Application,

		/// <summary>
		/// Indicates that the style is user-created.
		/// </summary>
		User,
	}
}
