// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;

namespace MfGames.GtkExt.TextEditor.Renderers
{
	/// <summary>
	/// Implements a <see cref="EditorViewRenderer"/> wrapped around a 
	/// <see cref="LineBuffer"/>.
	/// </summary>
	public class LineBufferRenderer: EditorViewRenderer
	{
		#region Properties

		/// <summary>
		/// Gets the line buffer associated with this renderer.
		/// </summary>
		/// <value>The line buffer.</value>
		public override LineBuffer LineBuffer
		{
			[DebuggerStepThrough] get { return lineBuffer; }
		}

		/// <summary>
		/// Gets or sets the selection renderer.
		/// </summary>
		/// <value>The selection renderer.</value>
		public override SelectionRenderer SelectionRenderer
		{
			[DebuggerStepThrough] get { return selectionRenderer; }
			[DebuggerStepThrough] set { selectionRenderer = value; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the line buffer.
		/// </summary>
		/// <param name="value">The value.</param>
		public override void SetLineBuffer(LineBuffer value)
		{
			// Disconnect the events from the buffer.
			if (lineBuffer != null)
			{
				lineBuffer.LineChanged -= OnLineChanged;
				lineBuffer.LinesInserted -= OnLinesInserted;
				lineBuffer.LinesDeleted -= OnLinesDeleted;
			}

			// Set the buffer and hook up the events.
			lineBuffer = value;

			// Hook up the events for the buffer.
			if (lineBuffer != null)
			{
				lineBuffer.LineChanged += OnLineChanged;
				lineBuffer.LinesInserted += OnLinesInserted;
				lineBuffer.LinesDeleted += OnLinesDeleted;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		public LineBufferRenderer(IDisplayContext displayContext)
			: this(displayContext, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EditorViewRenderer"/> class.
		/// </summary>
		/// <param name="displayContext">The display context.</param>
		/// <param name="lineBuffer">The line buffer.</param>
		public LineBufferRenderer(
			IDisplayContext displayContext,
			LineBuffer lineBuffer)
			: base(displayContext)
		{
			// Save the buffer in a property.
			SetLineBuffer(lineBuffer);

			// Set up the selection.
			selectionRenderer = new SelectionRenderer();
		}

		#endregion

		#region Fields

		private LineBuffer lineBuffer;

		private SelectionRenderer selectionRenderer;

		#endregion
	}
}
