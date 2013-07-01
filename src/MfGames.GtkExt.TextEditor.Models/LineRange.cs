// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models
{
	/// <summary>
	/// Defines a range of lines from the start to the end.
	/// </summary>
	public struct LineRange
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines in the range.
		/// </summary>
		/// <value>The line count.</value>
		public int Count
		{
			get { return endIndex - startIndex; }
		}

		/// <summary>
		/// Gets the end character index.
		/// </summary>
		public int EndIndex
		{
			get { return endIndex; }
		}

		/// <summary>
		/// Gets a value indicating whether this range is empty.
		/// </summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty
		{
			get { return startIndex == endIndex; }
		}

		/// <summary>
		/// Gets the start character index.
		/// </summary>
		public int StartIndex
		{
			get { return startIndex; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Creates a new line range from a given start index and a length.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static LineRange FromCount(
			int startIndex,
			int length)
		{
			return new LineRange(startIndex, startIndex + length);
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Lines {0}-{1}", startIndex, endIndex);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineRange"/> struct.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		public LineRange(int startIndex)
			: this(startIndex, Int32.MaxValue)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LineRange"/> struct.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		public LineRange(
			int startIndex,
			int endIndex)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException(
					"startIndex", "Start index cannot be less than zero.");
			}

			if (endIndex < startIndex)
			{
				throw new ArgumentOutOfRangeException(
					"endIndex", "End index cannot be less than start index.");
			}

			this.startIndex = startIndex;
			this.endIndex = endIndex;
		}

		#endregion

		#region Fields

		private readonly int endIndex;
		private readonly int startIndex;

		#endregion
	}
}
