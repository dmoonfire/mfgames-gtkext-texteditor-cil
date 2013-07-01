// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using Gdk;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Defines a default key binding into the text editor.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class KeyBindingAttribute: Attribute
	{
		#region Properties

		/// <summary>
		/// Gets or sets the key code associated with this binding.
		/// </summary>
		/// <value>The key.</value>
		public Key Key { get; private set; }

		/// <summary>
		/// Gets or sets the modifier associated with this binding.
		/// </summary>
		/// <value>The modifier.</value>
		public ModifierType Modifier { get; private set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyBindingAttribute"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		public KeyBindingAttribute(Key key)
		{
			Key = key;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KeyBindingAttribute"/> class.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="modifier">The modifier.</param>
		public KeyBindingAttribute(
			Key key,
			ModifierType modifier)
			: this(key)
		{
			Modifier = modifier;
		}

		#endregion
	}
}
