// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents the borders of all four sides.
	/// </summary>
	public class Borders
	{
		#region Properties

		/// <summary>
		/// Gets or sets the bottom border.
		/// </summary>
		/// <value>The bottom.</value>
		public Border Bottom
		{
			[DebuggerStepThrough] get { return bottom; }
			set { bottom = value ?? new Border(); }
		}

		/// <summary>
		/// Gets the sum of the top and bottom spacing.
		/// </summary>
		/// <value>The height.</value>
		public double Height
		{
			get { return Top.LineWidth + Bottom.LineWidth; }
		}

		/// <summary>
		/// Gets or sets the left border.
		/// </summary>
		/// <value>The left.</value>
		public Border Left
		{
			[DebuggerStepThrough] get { return left; }
			set { left = value ?? new Border(); }
		}

		/// <summary>
		/// Gets or sets the right border.
		/// </summary>
		/// <value>The right.</value>
		public Border Right
		{
			[DebuggerStepThrough] get { return right; }
			set { right = value ?? new Border(); }
		}

		/// <summary>
		/// Gets or sets the top border.
		/// </summary>
		/// <value>The top.</value>
		public Border Top
		{
			[DebuggerStepThrough] get { return top; }
			set { top = value ?? new Border(); }
		}

		/// <summary>
		/// Gets the sum of the left and right spacing.
		/// </summary>
		/// <value>The width.</value>
		public double Width
		{
			get { return Right.LineWidth + Left.LineWidth; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Borders"/> class.
		/// </summary>
		public Borders()
		{
			Top = Right = Bottom = Left = new Border();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Borders"/> class.
		/// </summary>
		/// <param name="top">The top.</param>
		/// <param name="right">The right.</param>
		/// <param name="bottom">The bottom.</param>
		/// <param name="left">The left.</param>
		public Borders(
			Border top,
			Border right,
			Border bottom,
			Border left)
		{
			Top = top;
			Right = right;
			Bottom = bottom;
			Left = left;
		}

		#endregion

		#region Fields

		private Border bottom;
		private Border left;
		private Border right;
		private Border top;

		#endregion
	}
}
