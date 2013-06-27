// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace MfGames.GtkExt.TextEditor.Models
{
	public class OperationContext
	{
		#region Properties

		public LineBuffer LineBuffer { get; private set; }
		public TextPosition Position { get; private set; }
		public LineBufferOperationResults? Results { get; set; }

		#endregion

		#region Constructors

		public OperationContext(
			LineBuffer lineBuffer,
			TextPosition position)
		{
			LineBuffer = lineBuffer;
			Position = position;
		}

		#endregion
	}
}
