// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Interfaces;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Attribute that indicates the types of objects that are used to maintain
	/// state for this method. All other states are requested to be removed
	/// before the method is called.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class ActionStateAttribute: Attribute
	{
		#region Properties

		/// <summary>
		/// Gets the type object that represents an action state.
		/// </summary>
		/// <value>The type of the state.</value>
		public Type StateType { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ActionStateAttribute"/> class.
		/// </summary>
		/// <param name="stateType">Type of state object to leave in the action states.</param>
		public ActionStateAttribute(Type stateType)
		{
			// Save the state to be retrieved later.
			StateType = stateType;

			// Make sure the state extends the proper class.
			if (!typeof (IActionState).IsAssignableFrom(StateType))
			{
				throw new Exception(
					"Can only assign an IActionState type of ActionState attributes");
			}
		}

		#endregion
	}
}
