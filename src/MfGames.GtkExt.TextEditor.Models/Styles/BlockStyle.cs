// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;
using Pango;
using Color = Cairo.Color;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents formatting of a block, not unlike a div tag in HTML.
	/// </summary>
	public abstract class BlockStyle
	{
		#region Properties

		/// <summary>
		/// Gets or sets the text alignment.
		/// </summary>
		/// <value>The alignment.</value>
		public Alignment? Alignment { get; set; }

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color? BackgroundColor { get; set; }

		/// <summary>
		/// Gets or sets the borders.
		/// </summary>
		/// <value>The borders.</value>
		public OptionalBorders Borders
		{
			[DebuggerStepThrough] get { return borders; }
			[DebuggerStepThrough] set { borders = value ?? new OptionalBorders(); }
		}

		/// <summary>
		/// Gets or sets the font description.
		/// </summary>
		/// <value>The font description.</value>
		public FontDescription FontDescription { get; set; }

		/// <summary>
		/// Gets or sets the foreground color.
		/// </summary>
		/// <value>The color of the foreground.</value>
		public Color? ForegroundColor { get; set; }

		/// <summary>
		/// Gets the height of the various elements in the style.
		/// </summary>
		/// <value>The height.</value>
		public double Height
		{
			get { return GetMargins().Height + GetPadding().Height + GetBorders().Height; }
		}

		/// <summary>
		/// Gets the left spacing.
		/// </summary>
		/// <value>The left.</value>
		public double Left
		{
			get { return GetMargins().Left + GetPadding().Left + GetBorders().Left.LineWidth; }
		}

		/// <summary>
		/// Gets or sets the margins.
		/// </summary>
		/// <value>The margins.</value>
		public OptionalSpacing Margins
		{
			[DebuggerStepThrough] get { return margins; }
			set { margins = value ?? new OptionalSpacing(); }
		}

		/// <summary>
		/// Gets or sets the padding.
		/// </summary>
		/// <value>The padding.</value>
		public OptionalSpacing Padding
		{
			[DebuggerStepThrough] get { return padding; }
			set { padding = value ?? new OptionalSpacing(); }
		}

		/// <summary>
		/// Gets the right spacing.
		/// </summary>
		/// <value>The left.</value>
		public double Right
		{
			get
			{
				return GetMargins().Right + GetPadding().Right
					+ GetBorders().Right.LineWidth;
			}
		}

		/// <summary>
		/// Gets or sets the style usage.
		/// </summary>
		/// <value>The style usage.</value>
		public StyleUsage StyleUsage { get; set; }

		/// <summary>
		/// Gets the top spacing.
		/// </summary>
		/// <value>The top.</value>
		public double Top
		{
			get { return GetMargins().Top + GetPadding().Top + GetBorders().Top.LineWidth; }
		}

		/// <summary>
		/// Gets the width of the various elements in the style.
		/// </summary>
		/// <value>The width.</value>
		public double Width
		{
			get { return GetMargins().Width + GetPadding().Width + GetBorders().Width; }
		}

		/// <summary>
		/// Gets or sets the wrap mode.
		/// </summary>
		/// <value>The wrap mode.</value>
		public WrapMode? WrapMode { get; set; }

		/// <summary>
		/// Gets the ParentBlockStyle block style for this element.
		/// </summary>
		/// <value>The ParentBlockStyle block style.</value>
		protected abstract BlockStyle ParentBlockStyle { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Gets the alignment from this selector or the parent.
		/// </summary>
		/// <returns></returns>
		public Alignment GetAlignment()
		{
			// If we have a value, then use that directly.
			if (Alignment.HasValue)
			{
				return Alignment.Value;
			}

			// If we have a ParentBlockStyle, then cascade up into it.
			if (ParentBlockStyle != null)
			{
				return ParentBlockStyle.GetAlignment();
			}

			// Otherwise, return a sane default.
			return Pango.Alignment.Left;
		}

		/// <summary>
		/// Gets the background color from this selector or the parent.
		/// </summary>
		/// <returns></returns>
		public Color? GetBackgroundColor()
		{
			// If we have a value, then use that directly.
			if (BackgroundColor.HasValue)
			{
				return BackgroundColor.Value;
			}

			// If we have a ParentBlockStyle, then cascade up into it.
			if (ParentBlockStyle != null)
			{
				return ParentBlockStyle.GetBackgroundColor();
			}

			// Otherwise, return nothing to indicate no background.
			return null;
		}

		/// <summary>
		/// Gets the completed borders by processing the ParentBlockStyles.
		/// </summary>
		/// <returns></returns>
		public Borders GetBorders()
		{
			// If we have all four borders, then return them.
			if (borders.Complete)
			{
				return borders.ToBorders();
			}

			// If the current is empty, then just get the ParentBlockStyle.
			if (borders.Empty)
			{
				return ParentBlockStyle != null
					? ParentBlockStyle.GetBorders()
					: new Borders();
			}

			// If we don't have a ParentBlockStyle, then we set the rest of the values
			// to zero and return it.
			if (ParentBlockStyle == null)
			{
				return borders.ToBorders();
			}

			// If we have a ParentBlockStyle, then we need to merge all the values
			// together.
			Borders parentBorders = ParentBlockStyle.GetBorders();

			return new Borders(
				borders.Top ?? parentBorders.Top,
				borders.Right ?? parentBorders.Right,
				borders.Bottom ?? parentBorders.Bottom,
				borders.Left ?? parentBorders.Left);
		}

		/// <summary>
		/// Gets the font description from this selector or the parent.
		/// </summary>
		/// <returns></returns>
		public FontDescription GetFontDescription()
		{
			// If we have a value, then use that directly.
			if (FontDescription != null)
			{
				return FontDescription;
			}

			// If we have a ParentBlockStyle, then cascade up into it.
			if (ParentBlockStyle != null)
			{
				return ParentBlockStyle.GetFontDescription();
			}

			// Otherwise, return a sane default.
			return FontDescriptionCache.GetFontDescription("Sans 12");
		}

		/// <summary>
		/// Gets the foreground color from this selector or the parent.
		/// </summary>
		/// <returns></returns>
		public Color GetForegroundColor()
		{
			// If we have a value, then use that directly.
			if (ForegroundColor.HasValue)
			{
				return ForegroundColor.Value;
			}

			// If we have a ParentBlockStyle, then cascade up into it.
			if (ParentBlockStyle != null)
			{
				return ParentBlockStyle.GetForegroundColor();
			}

			// Otherwise, return a sane default.
			return new Color(0, 0, 0);
		}

		/// <summary>
		/// Gets the completed margins by processing the ParentBlockStyles.
		/// </summary>
		/// <returns></returns>
		public Spacing GetMargins()
		{
			// If we have all four margins, then return them.
			if (margins.Complete)
			{
				return margins.ToSpacing();
			}

			// If the current is empty, then just get the ParentBlockStyle.
			if (margins.Empty)
			{
				return ParentBlockStyle != null
					? ParentBlockStyle.GetMargins()
					: new Spacing();
			}

			// If we don't have a ParentBlockStyle, then we set the rest of the values
			// to zero and return it.
			if (ParentBlockStyle == null)
			{
				return margins.ToSpacing();
			}

			// If we have a ParentBlockStyle, then we need to merge all the values
			// together.
			Spacing parentMargins = ParentBlockStyle.GetMargins();

			return new Spacing(
				margins.Top.HasValue
					? margins.Top.Value
					: parentMargins.Top,
				margins.Right.HasValue
					? margins.Right.Value
					: parentMargins.Right,
				margins.Bottom.HasValue
					? margins.Bottom.Value
					: parentMargins.Bottom,
				margins.Left.HasValue
					? margins.Left.Value
					: parentMargins.Left);
		}

		/// <summary>
		/// Gets the completed paddings by processing the ParentBlockStyles.
		/// </summary>
		/// <returns></returns>
		public Spacing GetPadding()
		{
			// If we have all four padding, then return them.
			if (padding.Complete)
			{
				return padding.ToSpacing();
			}

			// If the current is empty, then just get the ParentBlockStyle.
			if (padding.Empty)
			{
				return ParentBlockStyle != null
					? ParentBlockStyle.GetPadding()
					: new Spacing();
			}

			// If we don't have a ParentBlockStyle, then we set the rest of the values
			// to zero and return it.
			if (ParentBlockStyle == null)
			{
				return padding.ToSpacing();
			}

			// If we have a ParentBlockStyle, then we need to merge all the values
			// together.
			Spacing parentPadding = ParentBlockStyle.GetPadding();

			return new Spacing(
				padding.Top.HasValue
					? padding.Top.Value
					: parentPadding.Top,
				padding.Right.HasValue
					? padding.Right.Value
					: parentPadding.Right,
				padding.Bottom.HasValue
					? padding.Bottom.Value
					: parentPadding.Bottom,
				padding.Left.HasValue
					? padding.Left.Value
					: parentPadding.Left);
		}

		/// <summary>
		/// Gets the wrap mode from this selector or the parent.
		/// </summary>
		/// <returns></returns>
		public WrapMode GetWrap()
		{
			// If we have a value, then use that directly.
			if (WrapMode.HasValue)
			{
				return WrapMode.Value;
			}

			// If we have a ParentBlockStyle, then cascade up into it.
			if (ParentBlockStyle != null)
			{
				return ParentBlockStyle.GetWrap();
			}

			// Otherwise, return a sane default.
			return Pango.WrapMode.Word;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="BlockStyle"/> class.
		/// </summary>
		protected BlockStyle()
		{
			margins = new OptionalSpacing();
			padding = new OptionalSpacing();
			borders = new OptionalBorders();
		}

		#endregion

		#region Fields

		private OptionalBorders borders;
		private OptionalSpacing margins;
		private OptionalSpacing padding;

		#endregion
	}
}
