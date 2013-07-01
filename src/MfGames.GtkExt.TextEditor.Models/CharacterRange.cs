// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models
{
	/// <summary>
	/// Defines a range of characters from the start to the end.
	/// </summary>
	public struct CharacterRange
	{
		#region Properties

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
		/// Gets the length of the range.
		/// </summary>
		/// <value>The length.</value>
		public int Length
		{
			get { return endIndex - startIndex; }
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
		/// Creates a new character range from a given start index and a length.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="length">The length.</param>
		/// <returns></returns>
		public static CharacterRange FromLength(
			int startIndex,
			int length)
		{
			return new CharacterRange(startIndex, startIndex + length);
		}

		/// <summary>
		/// Gets a substring of the given text, normalizing for length.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public string Substring(string value)
		{
			// If we have a null, then return a null.
			if (value == null)
			{
				return null;
			}

			// Check to see if we are trying to get the entire line.
			if (startIndex == 0
				&& endIndex >= value.Length)
			{
				return value;
			}

			// Figure out a safe substring from the given text and return it.
			int textEndIndex = Math.Min(endIndex, value.Length);
			int length = startIndex - textEndIndex;

			return value.Substring(startIndex, length);
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Characters {0}-{1}", startIndex, endIndex);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CharacterRange"/> struct.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		public CharacterRange(int startIndex)
			: this(startIndex, Int32.MaxValue)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException(
					"startIndex", "Start index cannot be less than zero.");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CharacterRange"/> struct.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		public CharacterRange(
			int startIndex,
			int endIndex)
		{
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
