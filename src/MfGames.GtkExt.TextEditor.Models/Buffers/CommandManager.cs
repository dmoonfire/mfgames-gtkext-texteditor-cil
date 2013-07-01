// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Implements a manager for commands that handles undo and redo functionality.
	/// </summary>
	public class CommandManager
	{
		#region Properties

		/// <summary>
		/// Gets the redo commands.
		/// </summary>
		public CommandCollection RedoCommands { get; private set; }

		/// <summary>
		/// Gets the undo commands.
		/// </summary>
		public CommandCollection UndoCommands { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		/// Adds the specified command to the command manager.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Add(Command command)
		{
			// Throw an exception if there are no command.
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			// Adding a command automatically purges the redo list.
			RedoCommands.Clear();

			// Check to see if there are any undo commands. If there isn't
			// any undo commands, then we don't add it to the undo list.
			if (command.UndoOperations.Count > 0)
			{
				UndoCommands.Push(command);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandManager"/> class.
		/// </summary>
		public CommandManager()
		{
			RedoCommands = new CommandCollection();
			UndoCommands = new CommandCollection();
		}

		#endregion
	}
}
