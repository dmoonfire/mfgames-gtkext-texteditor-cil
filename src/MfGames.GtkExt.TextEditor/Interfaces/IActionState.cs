// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Interfaces
{
	/// <summary>
	/// Interface that defines the properties and methods that are common
	/// among all action states. These classes are used to remember conditions
	/// of actions and are automatically removed by actions that don't use the
	/// same state.
	/// </summary>
	public interface IActionState
	{
		#region Methods

		/// <summary>
		/// Determines whether this action state can be removed. This is also
		/// an opportunity for the action to clean up before removed.
		/// </summary>
		/// <returns>
		///   <c>true</c> if this instance can remove; otherwise, <c>false</c>.
		/// </returns>
		bool CanRemove();

		#endregion
	}
}
