// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.GtkExt.TextEditor.Editing;
using MfGames.GtkExt.TextEditor.Editing.Commands;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.HierarchicalPaths;

namespace MfGames.Commands
{
	public class RedoCommandFactory: TextEditingCommandFactory
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
			return "Redo";
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
			if (controller.CommandController.CanRedo)
			{
				// Request that the previous undone command be redone.
				controller.CommandController.Redo(operationContext);

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

		static RedoCommandFactory()
		{
			Key = new HierarchicalPath("/Redo", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
