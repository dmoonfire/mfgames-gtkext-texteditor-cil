// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;
using System.Text;
using MfGames.Commands;
using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Represents an operation to insert text into the buffer. Unlike
	/// <see cref="SetTextOperation"/>, this deletes text at a specific position
	/// and returns the buffer position for resulting position.
	/// </summary>
	public class DeleteTextOperation: TextEditingOperation,
		ILineBufferOperation,
		IDeleteTextCommand<OperationContext>
	{
		#region Properties

		/// <summary>
		/// Gets or sets the character range to delete.
		/// </summary>
		/// <value>The character range.</value>
		public SingleLineTextRange TextRange { get; set; }

		/// <summary>
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			[DebuggerStepThrough] get { return LineBufferOperationType.DeleteText; }
		}

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// Grab the line from the line buffer.
			int lineIndex = TextRange.LinePosition.NormalizeIndex(
				state.LineBuffer.LineCount);
			string lineText = state.LineBuffer.GetLineText(
				lineIndex, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			startCharacterIndex = TextRange.BeginCharacterPosition.NormalizeIndex(
				lineText, TextRange.EndCharacterPosition, WordSearchDirection.Left);
			int endCharacterIndex = TextRange.EndCharacterPosition.NormalizeIndex(
				lineText, TextRange.BeginCharacterPosition, WordSearchDirection.Right);
			int length = endCharacterIndex - startCharacterIndex;

			originalText = lineText.Substring(startCharacterIndex, length);

			buffer.Remove(startCharacterIndex, length);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(lineIndex, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Do))
			{
				originalPosition = state.Position;
				state.Results =
					new LineBufferOperationResults(TextRange.BeginTextPosition);
			}
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Grab the line from the line buffer.
			int lineIndex = TextRange.LinePosition.NormalizeIndex(
				state.LineBuffer.LineCount);
			string lineText = state.LineBuffer.GetLineText(
				lineIndex, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			buffer.Insert(startCharacterIndex, originalText);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(lineIndex, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new TextPosition(
							originalPosition.LinePosition.Index, originalPosition.CharacterPosition.Index));
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteTextOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="startCharacterIndex">Start index of the character.</param>
		/// <param name="endCharacterIndex">End index of the character.</param>
		public DeleteTextOperation(
			int lineIndex,
			int startCharacterIndex,
			int endCharacterIndex)
			: this(
				new SingleLineTextRange(lineIndex, startCharacterIndex, endCharacterIndex))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteTextOperation" /> class.
		/// </summary>
		/// <param name="characterRange">The character range.</param>
		public DeleteTextOperation(SingleLineTextRange characterRange)
		{
			TextRange = characterRange;
		}

		#endregion

		#region Fields

		private TextPosition originalPosition;
		private string originalText;
		private int startCharacterIndex;

		#endregion
	}
}
