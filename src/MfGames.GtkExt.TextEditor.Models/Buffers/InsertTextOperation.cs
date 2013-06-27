// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Diagnostics;
using System.Text;
using MfGames.Commands;
using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Represents an operation to insert text into the buffer. Unlike
	/// <see cref="SetTextOperation"/>, this inserts text into a specific position
	/// and returns the buffer position for the end of the insert.
	/// </summary>
	public class InsertTextOperation: TextEditingOperation,
		ILineBufferOperation,
		IInsertTextCommand<OperationContext>
	{
		#region Properties

		/// <summary>
		/// Gets or sets the buffer position for the insert operation.
		/// </summary>
		/// <value>The buffer position.</value>
		public TextPosition BufferPosition { get; private set; }

		/// <summary>
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			[DebuggerStepThrough] get { return LineBufferOperationType.InsertText; }
		}

		/// <summary>
		/// Gets the text for this operation.
		/// </summary>
		/// <value>The text.</value>
		public string Text { get; set; }

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// Grab the line from the line buffer.
			string lineText = state.LineBuffer.GetLineText(
				(int) BufferPosition.Line, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			int characterIndex = BufferPosition.Character.NormalizeIndex(lineText);

			buffer.Insert(characterIndex, Text);

			originalInsertPoint = characterIndex;
			originalPosition = state.Position;

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText((int) BufferPosition.Line, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Do))
			{
				state.Results =
					new LineBufferOperationResults(
						new BufferPosition(BufferPosition.Line, characterIndex + Text.Length));
			}
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Grab the line from the line buffer.
			string lineText = state.LineBuffer.GetLineText(
				(int) BufferPosition.Line, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			buffer.Remove(originalInsertPoint, Text.Length);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText((int) BufferPosition.Line, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new BufferPosition(originalPosition.Line, originalPosition.Character));
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="InsertTextOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <param name="text">The text.</param>
		public InsertTextOperation(
			LinePosition lineIndex,
			CharacterPosition characterIndex,
			string text)
			: this(new TextPosition(lineIndex, characterIndex), text)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="InsertTextOperation"/> class.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		/// <param name="text">The text.</param>
		public InsertTextOperation(
			TextPosition bufferPosition,
			string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}

			BufferPosition = bufferPosition;
			Text = text;
		}

		#endregion

		#region Fields

		private int originalInsertPoint;
		private TextPosition originalPosition;

		#endregion
	}
}
