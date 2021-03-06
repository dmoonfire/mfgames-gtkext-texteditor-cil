// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Collections.Generic;

namespace MfGames.GtkExt.TextEditor.Models.Styles
{
	/// <summary>
	/// Implements a dictionary for managing block styles.
	/// </summary>
	/// <typeparam name="TBlockStyle">The type of the block style.</typeparam>
	public class BlockStyleDictionary<TBlockStyle>: Dictionary<string, TBlockStyle>
		where TBlockStyle: BlockStyle
	{
		#region Properties

		/// <summary>
		/// Gets or sets the <see cref="TBlockStyle"/> with the specified key.
		/// </summary>
		public new TBlockStyle this[string key]
		{
			get
			{
				return ContainsKey(key)
					? base[key]
					: null;
			}
			set { base[key] = value; }
		}

		#endregion
	}
}
