// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Diagnostics;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Defines an operation that allows the buffer to update a line after the
	/// user has exited it.
	/// </summary>
	public class ExitLineOperation: ILineBufferOperation
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
			[DebuggerStepThrough] get { return LineBufferOperationType.ExitLine; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ExitLineOperation"/> class.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		public ExitLineOperation(int lineIndex)
		{
			LineIndex = lineIndex;
		}

		#endregion
	}
}
