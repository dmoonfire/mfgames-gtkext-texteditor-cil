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
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			[DebuggerStepThrough] get { return LineBufferOperationType.DeleteText; }
		}

		/// <summary>
		/// Gets or sets the character range to delete.
		/// </summary>
		/// <value>The character range.</value>
		public SingleLineTextRange TextRange { get; set; }

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// Grab the line from the line buffer.
			int lineIndex =
				TextRange.LinePosition.GetLineIndex(state.LineBuffer.LineCount);
			string lineText = state.LineBuffer.GetLineText(
				lineIndex, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			int firstCharacterIndex;
			int lastCharacterIndex;

			TextRange.GetFirstAndLastCharacterIndices(
				lineText, out firstCharacterIndex, out lastCharacterIndex);
			beginCharacterIndex = firstCharacterIndex;

			int length = lastCharacterIndex - firstCharacterIndex;

			// Remove the text from the string, but save it so we can restore it.
			originalText = lineText.Substring(firstCharacterIndex, length);

			buffer.Remove(firstCharacterIndex, length);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(lineIndex, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Do))
			{
				var firstCharacterPosition = new CharacterPosition(firstCharacterIndex);
				var firstTextPosition = new TextPosition(
					TextRange.LinePosition, firstCharacterPosition);
				originalPosition = state.Position;
				state.Results = new LineBufferOperationResults(firstTextPosition);
			}
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Grab the line from the line buffer.
			int lineIndex =
				TextRange.LinePosition.GetLineIndex(state.LineBuffer.LineCount);
			string lineText = state.LineBuffer.GetLineText(
				lineIndex, LineContexts.Unformatted);
			var buffer = new StringBuilder(lineText);

			// Normalize the character ranges.
			buffer.Insert(beginCharacterIndex, originalText);

			// Set the line in the buffer.
			lineText = buffer.ToString();
			state.LineBuffer.SetText(lineIndex, lineText);

			// If we are updating the position, we need to do it here.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new TextPosition(
							originalPosition.LinePosition.Index,
							originalPosition.CharacterPosition.Index));
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

		private int beginCharacterIndex;

		private TextPosition originalPosition;
		private string originalText;

		#endregion
	}
}
