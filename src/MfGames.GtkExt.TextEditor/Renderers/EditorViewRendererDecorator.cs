// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// Wraps around a <see cref="EditorViewRenderer"/> and allows for extending classes
	/// to override various methods and properties. This implementation simply
	/// calls the underlying <see cref="EditorViewRenderer"/> for everything.
	/// </summary>
	public abstract class EditorViewRendererDecorator: EditorViewRenderer
	{
		#region Properties

		/// <summary>
		/// Gets or sets the underlying Renderer.
		/// </summary>
		/// <value>The text renderer.</value>
		public EditorViewRenderer EditorViewRenderer
		{
			[DebuggerStepThrough] get { return editorViewRenderer; }

			private set
			{
				// Disconnect any events if we previously had a renderer.
				if (editorViewRenderer != null)
				{
					editorViewRenderer.LineChanged -= OnLineChanged;
					editorViewRenderer.LinesDeleted -= OnLinesDeleted;
					editorViewRenderer.LinesInserted -= OnLinesInserted;
				}

				// Set the value for the underlying data.
				editorViewRenderer = value;

				// Connect the events if we have a new value.
				if (editorViewRenderer != null)
				{
					editorViewRenderer.LineChanged += OnLineChanged;
					editorViewRenderer.LinesDeleted += OnLinesDeleted;
					editorViewRenderer.LinesInserted += OnLinesInserted;
				}
			}
		}

		/// <summary>
		/// Gets the line buffer associated with this renderer.
		/// </summary>
		/// <value>The line buffer.</value>
		public override LineBuffer LineBuffer
		{
			[DebuggerStepThrough] get { return EditorViewRenderer.LineBuffer; }
		}

		/// <summary>
		/// Gets or sets the selection renderer.
		/// </summary>
		/// <value>The selection renderer.</value>
		public override SelectionRenderer SelectionRenderer
		{
			[DebuggerStepThrough] get { return EditorViewRenderer.SelectionRenderer; }
			[DebuggerStepThrough] set { editorViewRenderer.SelectionRenderer = value; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the line buffer since the renderer.
		/// </summary>
		/// <param name="value">The value.</param>
		public override void SetLineBuffer(LineBuffer value)
		{
			EditorViewRenderer.SetLineBuffer(value);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewRendererDecorator"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="editorViewRenderer">The text renderer.</param>
		protected EditorViewRendererDecorator(
			IDisplayContext displayContext,
			EditorViewRenderer editorViewRenderer)
			: base(displayContext)
		{
			EditorViewRenderer = editorViewRenderer;

			if (editorViewRenderer == null)
			{
				throw new ArgumentNullException("editorViewRenderer");
			}
		}

		#endregion

		#region Fields

		private EditorViewRenderer editorViewRenderer;

		#endregion
	}
}
