// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Indicates an operation that inserts lines into a line buffer.
	/// </summary>
	public class DeleteLinesOperation: TextEditingOperation,
		ILineBufferOperation,
		IDeleteLineCommand<OperationContext>
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines to delete.
		/// </summary>
		/// <value>The count.</value>
		public int Count { get; private set; }

		/// <summary>
		/// Gets the index of the first line to start deleting.
		/// </summary>
		/// <value>The index of the line.</value>
		public int Line { get; private set; }

		/// <summary>
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			get { return LineBufferOperationType.DeleteLines; }
		}

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// We need to save the state of the line before we delete it.
			savedText = state.LineBuffer.GetLineText(Line, LineContexts.Unformatted);

			// Delete the line from the buffer.
			state.LineBuffer.DeleteLines(Line, 1);
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Insert the line back into the buffer.
			state.LineBuffer.InsertLines(Line, 1);

			// Restore the text in the line.
			state.LineBuffer.SetText(Line, savedText);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteLinesOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="count">The count.</param>
		public DeleteLinesOperation(
			int lineIndex,
			int count)
		{
			Line = lineIndex;
			Count = count;
		}

		#endregion

		#region Fields

		private string savedText;

		#endregion
	}
}
