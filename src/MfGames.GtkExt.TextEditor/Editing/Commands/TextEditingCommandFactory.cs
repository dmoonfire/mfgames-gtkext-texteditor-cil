// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public abstract class TextEditingCommandFactory:
		ICommandFactory<OperationContext>
	{
		#region Properties

		public abstract HierarchicalPath FactoryKey { get; }

		#endregion

		#region Methods

		public void Do(
			object context,
			CommandFactoryReference commandFactoryReference,
			CommandFactoryManager<OperationContext> controller)
		{
			// Pull out some useful variables for processing.
			var editViewController = (EditorViewController) context;
			IDisplayContext displayContext = editViewController.DisplayContext;
			BufferPosition position = displayContext.Caret.Position;

			// Set up the operation context for this request.
			var textPosition = new TextPosition(
				displayContext.Caret.Position.LineIndex,
				displayContext.Caret.Position.CharacterIndex);
			var operationContext = new OperationContext(
				displayContext.LineBuffer, textPosition);

			// Create the commands and execute them.
			Do(
				context,
				controller,
				commandFactoryReference.Data,
				operationContext,
				editViewController,
				displayContext,
				position);
		}

		public abstract string GetTitle(
			CommandFactoryReference commandFactoryReference);

		protected abstract void Do(
			object context,
			CommandFactoryManager<OperationContext> commandFactory,
			object commandData,
			OperationContext operationContext,
			EditorViewController editViewController,
			IDisplayContext displayContext,
			BufferPosition position);

		#endregion
	}
}
