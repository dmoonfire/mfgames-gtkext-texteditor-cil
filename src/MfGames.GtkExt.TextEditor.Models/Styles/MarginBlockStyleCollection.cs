// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using C5;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Contains a list of margin block styles.
	/// </summary>
	public class MarginBlockStyleCollection: ArrayList<MarginBlockStyle>
	{
		#region Methods

		/// <summary>
		/// Creates a new margin block style and returns it.
		/// </summary>
		/// <param name="styleName">Name of the style.</param>
		/// <returns></returns>
		public MarginBlockStyle Add(string styleName)
		{
			// Check for nulls.
			if (styleName == null)
			{
				throw new ArgumentNullException("styleName");
			}

			// See if we already have it.
			foreach (MarginBlockStyle marginStyle in this)
			{
				if (marginStyle.StyleName == styleName)
				{
					return marginStyle;
				}
			}

			// Create a new one and return it.
			var style = new MarginBlockStyle(styleName, lineStyle);

			Add(style);

			return style;
		}

		/// <summary>
		/// Gets the margin block style, moving up in parent if it isn't local.
		/// </summary>
		/// <param name="styleName">Name of the style.</param>
		/// <returns></returns>
		public MarginBlockStyle Get(string styleName)
		{
			// Look through our styles for the name.
			foreach (MarginBlockStyle marginStyle in this)
			{
				if (marginStyle.StyleName == styleName)
				{
					return marginStyle;
				}
			}

			// We couldn't find it, so check the parent.
			return GetParent(styleName);
		}

		/// <summary>
		/// Gets the style from the parent.
		/// </summary>
		/// <param name="styleName">Name of the style.</param>
		/// <returns></returns>
		public MarginBlockStyle GetParent(string styleName)
		{
			LineBlockStyle parentLineStyle = lineStyle.Parent;

			return parentLineStyle == null
				? null
				: parentLineStyle.MarginStyles.Get(styleName);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MarginBlockStyleCollection"/> class.
		/// </summary>
		/// <param name="lineStyle">The line style.</param>
		public MarginBlockStyleCollection(LineBlockStyle lineStyle)
		{
			if (lineStyle == null)
			{
				throw new ArgumentNullException("lineStyle");
			}

			this.lineStyle = lineStyle;
		}

		#endregion

		#region Fields

		private readonly LineBlockStyle lineStyle;

		#endregion
	}
}
