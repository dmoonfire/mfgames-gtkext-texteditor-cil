// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Used to mark classes that contain Action attributes and used to
	/// automatically configure keybindings for the editor.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class ActionFixtureAttribute: Attribute
	{
	}
}
