// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Contains spacing values used for margins and padding. Each of them
	/// can also be null to indicate no value.
	/// </summary>
	public class OptionalSpacing
	{
		#region Properties

		/// <summary>
		/// Gets or sets the bottom spacing.
		/// </summary>
		/// <value>The bottom.</value>
		public double? Bottom { get; set; }

		/// <summary>
		/// Gets a value indicating whether all four directions have values.
		/// </summary>
		/// <value><c>true</c> if complete; otherwise, <c>false</c>.</value>
		public bool Complete
		{
			get { return Right.HasValue && Left.HasValue && Top.HasValue && Bottom.HasValue; }
		}

		/// <summary>
		/// Gets a value indicating whether all four directions have no values.
		/// </summary>
		/// <value><c>true</c> if empty; otherwise, <c>false</c>.</value>
		public bool Empty
		{
			get
			{
				return !Right.HasValue && !Left.HasValue && !Top.HasValue
					&& !Bottom.HasValue;
			}
		}

		/// <summary>
		/// Gets or sets the left spacing.
		/// </summary>
		/// <value>The left.</value>
		public double? Left { get; set; }

		/// <summary>
		/// Gets or sets the right spacing.
		/// </summary>
		/// <value>The right.</value>
		public double? Right { get; set; }

		/// <summary>
		/// Gets or sets the top spacing.
		/// </summary>
		/// <value>The top.</value>
		public double? Top { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Converts the optional spacing to a spacing object.
		/// </summary>
		/// <returns></returns>
		public Spacing ToSpacing()
		{
			return new Spacing(
				Top.HasValue
					? Top.Value
					: 0,
				Right.HasValue
					? Right.Value
					: 0,
				Bottom.HasValue
					? Bottom.Value
					: 0,
				Left.HasValue
					? Left.Value
					: 0);
		}

		#endregion
	}
}
