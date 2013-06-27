// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using C5;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Implements a command, which is a collection of operations both
	/// to perform the command and undo it.
	/// </summary>
	public class Command
	{
		#region Properties

		/// <summary>
		/// Gets or sets the position at the end of the operations.
		/// </summary>
		/// <value>The end position.</value>
		public BufferPosition EndPosition { get; set; }

		/// <summary>
		/// Gets the operations for the command.
		/// </summary>
		public ArrayList<ILineBufferOperation> Operations { get; private set; }

		/// <summary>
		/// Gets or sets the position for the start of the operations.
		/// </summary>
		/// <value>The operation position.</value>
		public BufferPosition StartPosition { get; set; }

		/// <summary>
		/// Gets the undo operations for this command.
		/// </summary>
		public ArrayList<ILineBufferOperation> UndoOperations { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		public Command()
		{
			Operations = new ArrayList<ILineBufferOperation>();
			UndoOperations = new ArrayList<ILineBufferOperation>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Command"/> class.
		/// </summary>
		/// <param name="startPosition">The start position.</param>
		public Command(BufferPosition startPosition)
			: this()
		{
			EndPosition = StartPosition = startPosition;
		}

		#endregion
	}
}
