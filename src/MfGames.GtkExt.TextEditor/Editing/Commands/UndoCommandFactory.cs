// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	public class UndoCommandFactory: TextEditingCommandFactory
	{
		#region Properties

		public override HierarchicalPath FactoryKey
		{
			get { return Key; }
		}

		public static HierarchicalPath Key { get; private set; }

		#endregion

		#region Methods

		public override string GetTitle(
			CommandFactoryReference commandFactoryReference)
		{
			return "Undo";
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
			if (controller.CommandController.CanUndo)
			{
				// Request that the previous command be undone.
				controller.CommandController.Undo(operationContext);

				// If we have a text position, we need to set it.
				if (operationContext.Results.HasValue)
				{
					displayContext.Caret.Position =
						operationContext.Results.Value.BufferPosition;
				}
			}
		}

		#endregion

		#region Constructors

		static UndoCommandFactory()
		{
			Key = new HierarchicalPath("/Undo", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
