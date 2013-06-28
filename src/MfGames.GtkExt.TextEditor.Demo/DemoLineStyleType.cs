// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.ComponentModel;

namespace GtkExtDemo.TextEditor
{
	/// <summary>
	/// Contains the various line styles used by the demo.
	/// </summary>
	public enum DemoLineStyleType
	{
		/// <summary>
		/// Represents the default font style.
		/// </summary>
		[Description("Text (T:)")]
		Default,

		/// <summary>
		/// Represents a bordered text.
		/// </summary>
		[Description("Bordered (B:)")]
		Borders,

		/// <summary>
		/// Represents a chapter which has borders and non-editable text.
		/// </summary>
		[Description("Chapter (C:)")]
		Chapter,

		/// <summary>
		/// Represents a heading line.
		/// </summary>
		[Description("Heading (H:)")]
		Heading,

		/// <summary>
		/// Represents a blank line.
		/// </summary>
		[Description("Break")]
		Break,
	}
}
