// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using Cairo;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models.Styles;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// The abstract base class for margin renderers. These can be used to show
	/// margin markers, line numbers, or even folding marks.
	/// </summary>
	public abstract class MarginRenderer
	{
		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MarginRenderer"/> is visible.
		/// </summary>
		/// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
		public bool Visible
		{
			get { return visible; }
			set
			{
				visible = value;
				FireWidthChanged();
			}
		}

		/// <summary>
		/// Gets the width of the margin.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			[DebuggerStepThrough] get { return width; }
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the width or visiblity of the margin changes.
		/// </summary>
		public event EventHandler WidthChanged;

		#endregion

		#region Methods

		/// <summary>
		/// Draws the margin at the given position.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="renderContext">The render context.</param>
		/// <param name="lineIndex">The line index being rendered.</param>
		/// <param name="point">The point of the specific line number.</param>
		/// <param name="height">The height of the rendered line.</param>
		/// <param name="lineBlockStyle">The line block style.</param>
		public abstract void Draw(
			IDisplayContext displayContext,
			IRenderContext renderContext,
			int lineIndex,
			PointD point,
			double height,
			LineBlockStyle lineBlockStyle);

		/// <summary>
		/// Resets this margin to the default width and setting.
		/// </summary>
		public virtual void Reset()
		{
			// We don't need to fire an event since this is called from the
			// collection's Reset().
			width = 0;
		}

		/// <summary>
		/// Resizes the specified margin based on the context.
		/// </summary>
		/// <param name="editorView">The text editor.</param>
		public virtual void Resize(EditorView editorView)
		{
			// The default implementation is to do nothing.
		}

		/// <summary>
		/// Sets the width of the margin.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public void SetWidth(int value)
		{
			bool fireEvent = width != value;

			width = value;

			if (fireEvent)
			{
				FireWidthChanged();
			}
		}

		/// <summary>
		/// Fires the WidthChanged event.
		/// </summary>
		private void FireWidthChanged()
		{
			if (WidthChanged != null)
			{
				WidthChanged(this, EventArgs.Empty);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MarginRenderer"/> class.
		/// </summary>
		protected MarginRenderer()
		{
			visible = true;
		}

		#endregion

		#region Fields

		private bool visible;
		private int width;

		#endregion
	}
}
