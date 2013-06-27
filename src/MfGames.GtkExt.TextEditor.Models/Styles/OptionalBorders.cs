// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents the borders of all four sides.
	/// </summary>
	public class OptionalBorders
	{
		#region Properties

		/// <summary>
		/// Gets or sets the bottom border.
		/// </summary>
		/// <value>The bottom.</value>
		public Border Bottom { get; set; }

		/// <summary>
		/// Gets a value indicating whether all four directions have values.
		/// </summary>
		/// <value><c>true</c> if complete; otherwise, <c>false</c>.</value>
		public bool Complete
		{
			get { return Right != null && Left != null && Top != null && Bottom != null; }
		}

		/// <summary>
		/// Gets a value indicating whether all four directions have no values.
		/// </summary>
		/// <value><c>true</c> if empty; otherwise, <c>false</c>.</value>
		public bool Empty
		{
			get { return Right == null && Left == null && Top == null && Bottom == null; }
		}

		/// <summary>
		/// Gets or sets the left border.
		/// </summary>
		/// <value>The left.</value>
		public Border Left { get; set; }

		/// <summary>
		/// Gets or sets the right border.
		/// </summary>
		/// <value>The right.</value>
		public Border Right { get; set; }

		/// <summary>
		/// Gets or sets the top border.
		/// </summary>
		/// <value>The top.</value>
		public Border Top { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Sets the border on all sides.
		/// </summary>
		/// <param name="border">The border.</param>
		public void SetBorder(Border border)
		{
			Top = border;
			Bottom = border;
			Right = border;
			Left = border;
		}

		/// <summary>
		/// Converts the optional borders object to a borders object.
		/// </summary>
		/// <returns></returns>
		public Borders ToBorders()
		{
			return new Borders(
				Top ?? new Border(),
				Right ?? new Border(),
				Bottom ?? new Border(),
				Left ?? new Border());
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format(
				"Borders? T:{0} R:{1} B:{2} L:{3}", Top, Right, Bottom, Left);
		}

		#endregion
	}
}
