// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents a style for rendering the margin.
	/// </summary>
	public class MarginBlockStyle: BlockStyle
	{
		#region Properties

		/// <summary>
		/// Gets the line style associated with this margin style.
		/// </summary>
		/// <value>The line style.</value>
		public LineBlockStyle ParentLineStyle
		{
			[DebuggerStepThrough] get { return parentLineStyle; }
		}

		/// <summary>
		/// Gets the parent margin style.
		/// </summary>
		/// <value>The margin style.</value>
		public MarginBlockStyle ParentMarginStyle
		{
			[DebuggerStepThrough] get { return parentMarginStyle; }
			[DebuggerStepThrough] set { parentMarginStyle = value; }
		}

		/// <summary>
		/// Gets the name of the style.
		/// </summary>
		/// <value>The name of the style.</value>
		public string StyleName
		{
			get { return styleName; }
		}

		/// <summary>
		/// Gets the ParentBlockStyle block style for this element.
		/// </summary>
		/// <value>The ParentBlockStyle block style.</value>
		protected override BlockStyle ParentBlockStyle
		{
			get
			{
				// If we have a margin style, we use that.
				if (parentMarginStyle != null)
				{
					return parentMarginStyle;
				}

				// If we don't have a parent line style, then return null.
				if (parentLineStyle == null)
				{
					return null;
				}

				// Otherwise, return the parent's line number.
				return parentLineStyle.MarginStyles.GetParent(styleName);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MarginBlockStyle"/> class.
		/// </summary>
		/// <param name="styleName">Name of the style.</param>
		/// <param name="parentLineStyle">The parent line style.</param>
		public MarginBlockStyle(
			string styleName,
			LineBlockStyle parentLineStyle)
		{
			if (styleName == null)
			{
				throw new ArgumentNullException("styleName");
			}

			this.styleName = styleName;
			this.parentLineStyle = parentLineStyle;
		}

		#endregion

		#region Fields

		private readonly LineBlockStyle parentLineStyle;
		private MarginBlockStyle parentMarginStyle;
		private readonly string styleName;

		#endregion
	}
}
