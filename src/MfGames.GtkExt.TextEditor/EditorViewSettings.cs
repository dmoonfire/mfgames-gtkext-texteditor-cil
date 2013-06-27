// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor
{
	/// <summary>
	/// Contains the settings for the text editor.
	/// </summary>
	public class EditorViewSettings
	{
		#region Properties

		public int CaretScrollPad { get; set; }
		public bool ShowLineNumbers { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the scroll padding area should be visible.
		/// </summary>
		/// <value>
		///   <c>true</c> if [show scroll padding]; otherwise, <c>false</c>.
		/// </value>
		public bool ShowScrollPadding { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewSettings"/> class.
		/// </summary>
		public EditorViewSettings()
		{
			ShowLineNumbers = true;
			CaretScrollPad = 3;
			ShowScrollPadding = false;
		}

		#endregion
	}
}
