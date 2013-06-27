// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

namespace MfGames.GtkExt.TextEditor.Models.Buffers
{
	/// <summary>
	/// Represents an operation performed on the line buffer.
	/// </summary>
	public interface ILineBufferOperation
	{
		#region Properties

		/// <summary>
		/// Gets the type of the operation representing this object. The value
		/// returned by this corresponds to a specific implementing class of
		/// <see cref="ILineBufferOperation"/>.
		/// </summary>
		/// <value>The type of the operation.</value>
		LineBufferOperationType OperationType { get; }

		#endregion
	}
}
