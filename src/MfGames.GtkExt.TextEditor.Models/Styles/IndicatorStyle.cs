// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using Cairo;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Encapsulates a style of drawing indicators.
	/// </summary>
	public class IndicatorStyle: IComparable<IndicatorStyle>
	{
		#region Properties

		/// <summary>
		/// Gets or sets the color of the indicator line.
		/// </summary>
		/// <value>The color.</value>
		public Color Color { get; set; }

		/// <summary>
		/// Gets or sets the name of the style.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the priority of the style. The higher indicators have
		/// priority over the lower ones.
		/// </summary>
		/// <value>The priority.</value>
		public int Priority { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(IndicatorStyle other)
		{
			return other.Priority.CompareTo(Priority);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicatorStyle"/> class.
		/// </summary>
		public IndicatorStyle()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicatorStyle"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="color">The color.</param>
		public IndicatorStyle(
			string name,
			int priority,
			Color color)
		{
			Name = name;
			Priority = priority;
			Color = color;
		}

		#endregion
	}
}
