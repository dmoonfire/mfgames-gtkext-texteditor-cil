// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Attribute used to mark a method has being an action the text editor
	/// could use. All methods take a single parameter, IDisplayContext.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class ActionAttribute: Attribute
	{
	}
}
