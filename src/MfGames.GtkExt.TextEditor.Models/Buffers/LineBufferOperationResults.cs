// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Contains the results from a line operation, including the new buffer
	/// position after the operation.
	/// </summary>
	public struct LineBufferOperationResults
	{
		#region Properties

		/// <summary>
		/// Gets or sets the buffer position after the operation.
		/// </summary>
		/// <value>The position.</value>
		public TextPosition TextPosition
		{
			get { return bufferPosition; }
			set { bufferPosition = value; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LineBufferOperationResults"/> struct.
		/// </summary>
		/// <param name="bufferPosition">The buffer position.</param>
		public LineBufferOperationResults(TextPosition bufferPosition)
		{
			this.bufferPosition = bufferPosition;
		}

		#endregion

		#region Fields

		private TextPosition bufferPosition;

		#endregion
	}
}
