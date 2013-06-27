// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Contains spacing values used for margins and padding.
	/// </summary>
	public class Spacing
	{
		#region Properties

		/// <summary>
		/// Gets or sets the bottom spacing.
		/// </summary>
		/// <value>The bottom.</value>
		public double Bottom { get; set; }

		/// <summary>
		/// Gets the sum of the top and bottom spacing.
		/// </summary>
		/// <value>The height.</value>
		public double Height
		{
			get { return Top + Bottom; }
		}

		/// <summary>
		/// Gets or sets the left spacing.
		/// </summary>
		/// <value>The left.</value>
		public double Left { get; set; }

		/// <summary>
		/// Gets or sets the right spacing.
		/// </summary>
		/// <value>The right.</value>
		public double Right { get; set; }

		/// <summary>
		/// Gets or sets the top spacing.
		/// </summary>
		/// <value>The top.</value>
		public double Top { get; set; }

		/// <summary>
		/// Gets the sum of the left and right spacing.
		/// </summary>
		/// <value>The width.</value>
		public double Width
		{
			get { return Right + Left; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Spacing"/> class.
		/// </summary>
		public Spacing()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Spacing"/> class.
		/// </summary>
		/// <param name="top">The top.</param>
		/// <param name="right">The right.</param>
		/// <param name="bottom">The bottom.</param>
		/// <param name="left">The left.</param>
		public Spacing(
			double top,
			double right,
			double bottom,
			double left)
		{
			Top = top;
			Right = right;
			Bottom = bottom;
			Left = left;
		}

		#endregion
	}
}
