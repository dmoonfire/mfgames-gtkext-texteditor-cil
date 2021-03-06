// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Defines the contexts that may change what is generated by the line
	/// buffer.
	/// </summary>
	[Flags]
	public enum LineContexts
	{
		/// <summary>
		/// Indicates that there is nothing significant about the request.
		/// </summary>
		None,

		/// <summary>
		/// Indicates that the request is for the current line.
		/// </summary>
		CurrentLine = 1,

		/// <summary>
		/// Indicates that the request should be a bare request without any
		/// non-editable or dynamic text.
		/// </summary>
		Unformatted = 2,
	}
}
