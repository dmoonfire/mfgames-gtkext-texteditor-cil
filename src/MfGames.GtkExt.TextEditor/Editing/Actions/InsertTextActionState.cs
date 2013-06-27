// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Represents an action state that combines multiple text inserts
	/// together when they are part of the same word (as defined by the word
	/// splitter).
	/// </summary>
	public class InsertTextActionState: IActionState
	{
		#region Properties

		/// <summary>
		/// Gets the command associated with the last insert text state.
		/// </summary>
		/// <value>The command.</value>
		public Command Command { get; private set; }

		/// <summary>
		/// Gets or sets the end position.
		/// </summary>
		/// <value>The end position.</value>
		public BufferPosition EndPosition
		{
			get { return Command.EndPosition; }
			set { Command.EndPosition = value; }
		}

		/// <summary>
		/// Gets the text operation.
		/// </summary>
		/// <value>The set text operation.</value>
		public InsertTextOperation Operation
		{
			get
			{
				// Even with the delete selection, the final operation will
				// be the set text operation.
				return (InsertTextOperation) Command.Operations.Last;
			}
		}

		/// <summary>
		/// Gets or sets the text inserted.
		/// </summary>
		/// <value>The text.</value>
		public string Text { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Determines whether this action state can be removed. This is also
		/// an opportunity for the action to clean up before removed.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance can remove; otherwise, <c>false</c>.
		/// </returns>
		public bool CanRemove()
		{
			return true;
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="InsertTextActionState"/> class.
		/// </summary>
		/// <param name="command">The command.</param>
		/// <param name="text">The text.</param>
		public InsertTextActionState(
			Command command,
			string text)
		{
			Command = command;
			Text = text;
		}

		#endregion
	}
}
