// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Defines the various operations that a line buffer can receive.
	/// </summary>
	public enum LineBufferOperationType: byte
	{
		/// <summary>
		/// Indicates that the associated operation extends <see cref="SetTextOperation"/>.
		/// </summary>
		SetText,

		/// <summary>
		/// Indicates that the associated operation extends 
		/// <see cref="InsertTextOperation"/>.
		/// </summary>
		InsertText,

		/// <summary>
		/// Indicates that the associated operation extends 
		/// <see cref="DeleteTextOperation"/>.
		/// </summary>
		DeleteText,

		/// <summary>
		/// Indicates that the associated operation extends <see cref="InsertLinesOperation"/>.
		/// </summary>
		InsertLines,

		/// <summary>
		/// Indicates that the associated operation extends <see cref="DeleteLinesOperation"/>.
		/// </summary>
		DeleteLines,

		/// <summary>
		/// Indicates that the user has scrolled off a line. The associated operation
		/// extends <see cref="ExitLineOperation"/>.
		/// </summary>
		ExitLine,
	}
}
