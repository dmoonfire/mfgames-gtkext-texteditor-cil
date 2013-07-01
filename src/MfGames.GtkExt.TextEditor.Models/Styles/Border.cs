// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Cairo;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents a single edge of a border.
	/// </summary>
	public class Border
	{
		#region Properties

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color.</value>
		public Color Color { get; set; }

		/// <summary>
		/// Gets or sets the width of the border.
		/// </summary>
		/// <value>The width.</value>
		public double LineWidth { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Border {0} {1}", LineWidth, Color.ToRgbHexString());
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Border"/> class.
		/// </summary>
		public Border()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Border"/> class.
		/// </summary>
		/// <param name="lineWidth">Width of the line.</param>
		/// <param name="color">The color.</param>
		public Border(
			double lineWidth,
			Color color)
		{
			LineWidth = lineWidth;
			Color = color;
		}

		#endregion
	}
}
