// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Collections.Generic;

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Implements an ordered command collection.
	/// </summary>
	public class CommandCollection: List<Command>
	{
		#region Methods

		/// <summary>
		/// Pushes the specified command to the beginning of the list.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Push(Command command)
		{
			Insert(0, command);
		}

		#endregion
	}
}
