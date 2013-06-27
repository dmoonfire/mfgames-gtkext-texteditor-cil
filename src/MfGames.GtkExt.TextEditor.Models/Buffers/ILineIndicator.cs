// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Defines the functionality of a line indicator.
	/// </summary>
	public interface ILineIndicator
	{
		#region Properties

		/// <summary>
		/// Gets the style used to draw the line indicator.
		/// </summary>
		/// <value>The line indicator style.</value>
		string LineIndicatorStyle { get; }

		#endregion
	}
}
