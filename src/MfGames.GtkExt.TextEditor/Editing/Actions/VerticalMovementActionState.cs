// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.GtkExt.TextEditor.Interfaces;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Used to contain the state between vertical movement.
	/// </summary>
	public class VerticalMovementActionState: IActionState
	{
		#region Properties

		/// <summary>
		/// Gets or sets the line X for vertical movements.
		/// </summary>
		/// <value>
		/// The line X-coordinate.
		/// </value>
		public int LayoutLineX { get; set; }

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
		/// Initializes a new instance of the <see cref="VerticalMovementActionState"/> class.
		/// </summary>
		/// <param name="layoutLineX">The X coordinate in Pango units.</param>
		public VerticalMovementActionState(int layoutLineX)
		{
			LayoutLineX = layoutLineX;
		}

		#endregion
	}
}
