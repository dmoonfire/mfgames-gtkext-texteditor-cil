// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;
using C5;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Represents the various style elements of the text editor. This is based
	/// on CSS styles in that if a style isn't defined at this level, the
	/// parent elements are checked. This allows for simple changes at higher
	/// levels to cascade down to child elements.
	/// </summary>
	public class LineBlockStyle: BlockStyle
	{
		#region Properties

		/// <summary>
		/// Gets the children styles associated with this one.
		/// </summary>
		/// <value>The children.</value>
		public LinkedList<LineBlockStyle> Children
		{
			[DebuggerStepThrough] get { return children; }
		}

		/// <summary>
		/// Gets the margin styles.
		/// </summary>
		/// <value>The margin styles.</value>
		public MarginBlockStyleCollection MarginStyles { get; private set; }

		/// <summary>
		/// Gets or sets the parent selector style. Setting the parent will
		/// also establish a corresponding link in the parent's children styles
		/// into this one. Setting to null will remove any cascading.
		/// </summary>
		/// <value>The parent.</value>
		public LineBlockStyle Parent
		{
			[DebuggerStepThrough] get { return parent; }
			set
			{
				if (parent != null)
				{
					parent.Children.Remove(this);
				}

				parent = value;

				if (parent != null)
				{
					parent.Children.Add(this);
				}
			}
		}

		/// <summary>
		/// Gets the parent block style for this element.
		/// </summary>
		/// <value>The parent block style.</value>
		protected override BlockStyle ParentBlockStyle
		{
			get { return parent; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineBlockStyle"/> class.
		/// </summary>
		public LineBlockStyle()
		{
			children = new LinkedList<LineBlockStyle>();
			MarginStyles = new MarginBlockStyleCollection(this);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LineBlockStyle"/> class.
		/// </summary>
		/// <param name="parent">The parent.</param>
		public LineBlockStyle(LineBlockStyle parent)
			: this()
		{
			Parent = parent;
		}

		#endregion

		#region Fields

		private readonly LinkedList<LineBlockStyle> children;
		private LineBlockStyle parent;

		#endregion
	}
}
