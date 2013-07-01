// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Used to indicate an event applying to a range of lines.
	/// </summary>
	public class LineRangeEventArgs: EventArgs
	{
		#region Properties

		/// <summary>
		/// Gets or sets the end index of the line.
		/// </summary>
		/// <value>The end index of the line.</value>
		public int EndLineIndex { get; private set; }

		/// <summary>
		/// Gets or sets the start index of the line.
		/// </summary>
		/// <value>The start index of the line.</value>
		public int StartLineIndex { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineRangeEventArgs"/> class.
		/// </summary>
		/// <param name="startLineIndex">Start index of the line.</param>
		/// <param name="endLineIndex">End index of the line.</param>
		public LineRangeEventArgs(
			int startLineIndex,
			int endLineIndex)
		{
			StartLineIndex = startLineIndex;
			EndLineIndex = endLineIndex;
		}

		#endregion
	}
}
