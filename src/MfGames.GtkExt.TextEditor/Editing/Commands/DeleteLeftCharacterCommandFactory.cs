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
	public class DeleteLeftCharacterCommandFactory: TextEditingCommandFactory
	{
		#region Properties

		public override HierarchicalPath FactoryKey
		{
			get { return Key; }
		}

		/// <summary>
		/// Contains the key for the command provided by this factory.
		/// </summary>
		public static HierarchicalPath Key { get; private set; }

		#endregion

		#region Methods

		public override string GetTitle(
			CommandFactoryReference commandFactoryReference)
		{
			return "Delete Left Character";
		}

		protected override void Do(
			object context,
			CommandFactoryManager<OperationContext> commandFactory,
			object commandData,
			OperationContext operationContext,
			EditorViewController controller,
			IDisplayContext displayContext,
			BufferPosition position)
		{
			IDeleteTextCommand<OperationContext> deleteCommand =
				controller.CommandController.CreateDeleteTextCommand(
					new SingleLineTextRange(
						displayContext.Caret.Position.LineIndex,
						(displayContext.Caret.Position.CharacterIndex - 1),
						displayContext.Caret.Position.CharacterIndex));
			deleteCommand.UpdateTextPosition = DoTypes.All;

			// Execute the command.
			controller.CommandController.Do(deleteCommand, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.Position =
					operationContext.Results.Value.BufferPosition;
			}
		}

		#endregion

		#region Constructors

		static DeleteLeftCharacterCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Delete Left Character", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
