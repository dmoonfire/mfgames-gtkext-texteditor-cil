// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using C5;

namespace MfGames.GtkExt.TextEditor.Editing
{
	/// <summary>
	/// Contains a single action entry object.
	/// </summary>
	public class ActionEntry
	{
		#region Properties

		/// <summary>
		/// Gets or sets the name of the action.
		/// </summary>
		/// <value>
		/// The action name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets the type objects that represent the states that this action
		/// uses.
		/// </summary>
		/// <value>The state types.</value>
		public ArrayList<Type> StateTypes
		{
			get { return stateTypes; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Performs the specified action using the context.
		/// </summary>
		/// <param name="controller">The action context.</param>
		public void Perform(EditorViewController controller)
		{
			// Start by going through the states and remove anything that isn't
			// in our state types.
			controller.States.RemoveAllExcluding(stateTypes);

			// Perform the action itself.
			Action(controller);
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ActionEntry"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="action">The action.</param>
		public ActionEntry(
			string name,
			Action<EditorViewController> action)
		{
			// Save the action for processing.
			Action = action;
			Name = name;

			// Create a list of state types needed.
			stateTypes = new ArrayList<Type>();
		}

		#endregion

		#region Fields

		/// <summary>
		/// Gets the action delegate to perform this action.
		/// </summary>
		public Action<EditorViewController> Action;

		private readonly ArrayList<Type> stateTypes;

		#endregion
	}
}
