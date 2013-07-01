// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Indicates a line changed.
	/// </summary>
	public class LineChangedArgs: EventArgs
	{
		#region Properties

		/// <summary>
		/// Gets or sets the index of the line for the arguments.
		/// </summary>
		/// <value>The index of the line.</value>
		public int LineIndex { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineChangedArgs"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		public LineChangedArgs(int lineIndex)
		{
			LineIndex = lineIndex;
		}

		#endregion
	}
}
