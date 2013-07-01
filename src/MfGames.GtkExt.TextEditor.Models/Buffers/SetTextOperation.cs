// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Defines an operation that changes text of a single line.
	/// </summary>
	public class SetTextOperation: ILineBufferOperation
	{
		#region Properties

		/// <summary>
		/// Gets or sets the index of the line.
		/// </summary>
		/// <value>The index of the line.</value>
		public int LineIndex { get; private set; }

		/// <summary>
		/// Gets the type of the operation representing this object.
		/// </summary>
		/// <value>The type of the operation.</value>
		public LineBufferOperationType OperationType
		{
			[DebuggerStepThrough] get { return LineBufferOperationType.SetText; }
		}

		/// <summary>
		/// Gets the text for this operation.
		/// </summary>
		/// <value>The text.</value>
		public string Text { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SetTextOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <param name="text">The text.</param>
		public SetTextOperation(
			int lineIndex,
			string text)
		{
			LineIndex = lineIndex;
			Text = text;
		}

		#endregion
	}
}
