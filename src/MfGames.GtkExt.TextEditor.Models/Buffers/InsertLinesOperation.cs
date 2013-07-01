// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Indicates an operation that inserts lines into a line buffer.
	/// </summary>
	public class InsertLinesOperation: TextEditingOperation,
		ILineBufferOperation,
		IInsertLineCommand<OperationContext>
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines to insert.
		/// </summary>
		/// <value>The count.</value>
		public int Count { get; private set; }

		/// <summary>
		/// Gets the index of the line to insert before.
		/// </summary>
		/// <value>The index of the line.</value>
		public int LineIndex { get; private set; }

		/// <summary>
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			get { return LineBufferOperationType.InsertLines; }
		}

		#endregion

		#region Methods

		public override void Do(OperationContext state)
		{
			// Save the position, in case we need it.
			InitialPosition = state.Position;

			// Insert the line into the buffer.
			state.LineBuffer.InsertLines(LineIndex, 1);

			// If we are updating the position, then set it.
			if (UpdateTextPosition.HasFlag(DoTypes.Do))
			{
				state.Results =
					new LineBufferOperationResults(new BufferPosition(LineIndex, 0));
			}
		}

		public override void Redo(OperationContext state)
		{
			Do(state);
		}

		public override void Undo(OperationContext state)
		{
			// Delete the created line.
			state.LineBuffer.DeleteLines(LineIndex, 1);

			// If we were updating the position, we need to restore it.
			// If we are updating the position, then set it.
			if (UpdateTextPosition.HasFlag(DoTypes.Undo))
			{
				state.Results =
					new LineBufferOperationResults(
						new BufferPosition(InitialPosition.Line, InitialPosition.Character));
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="InsertLinesOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="count">The count.</param>
		public InsertLinesOperation(
			int lineIndex,
			int count)
		{
			LineIndex = lineIndex;
			Count = count;
		}

		#endregion
	}
}
