// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.Commands.TextEditing.Composites;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public class JoinPreviousParagraphCommandFactory: TextEditingCommandFactory
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
			return "Join Previous Paragraph";
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
			var command =
				new JoinPreviousParagraphCommand<OperationContext>(
					controller.CommandController, position.LineIndex);

			controller.CommandController.Do(command, operationContext);

			// If we have a text position, we need to set it.
			if (operationContext.Results.HasValue)
			{
				displayContext.Caret.Position =
					operationContext.Results.Value.BufferPosition;
			}
		}

		#endregion

		#region Constructors

		static JoinPreviousParagraphCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Join Previous Paragraph",
				HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
