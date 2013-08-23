// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Collections.Generic;
using MfGames.Commands;
using MfGames.Commands.TextEditing;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public class InsertCharacterCommandFactory: TextEditingCommandFactory
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
			return "Insert Character";
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
			// If we don't have a selection, this is a simple insert command.
			var commands = new List<IUndoableCommand<OperationContext>>();
			BufferPosition bufferPosition = displayContext.Caret.Position;

			if (!displayContext.Caret.Selection.IsEmpty)
			{
				// We are going to be deleting, so we have a modified buffer position.
				bufferPosition = displayContext.Caret.Selection.StartPosition;

				// Create and add the delete command.
				IUndoableCommand<OperationContext> deleteCommand =
					DeleteSelectionCommandFactory.CreateCommand(controller, displayContext);
				commands.Add(deleteCommand);
			}

			// Create the insert command using the (potentially) modified selection.
			string text = commandData.ToString();
			IInsertTextCommand<OperationContext> insertCommand =
				controller.CommandController.CreateInsertTextCommand(
					new TextPosition(bufferPosition.LineIndex, bufferPosition.CharacterIndex),
					text);
			insertCommand.UpdateTextPosition = DoTypes.All;
			commands.Add(insertCommand);

			// Figure out if we have a single command or more than one.
			IUndoableCommand<OperationContext> doCommand;

			if (commands.Count == 1)
			{
				doCommand = commands[0];
			}
			else
			{
				// We need a composite command for this operation.
				var composite = new CompositeCommand<OperationContext>();

				foreach (IUndoableCommand<OperationContext> command in commands)
				{
					composite.Commands.Add(command);
				}

				// Submit the composite command.
				doCommand = composite;
			}

			// Execute the command.
			controller.CommandController.Do(doCommand, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.SetAndScrollToPosition(
					operationContext.Results.Value.BufferPosition);
			}
		}

		#endregion

		#region Constructors

		static InsertCharacterCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Insert Character", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
