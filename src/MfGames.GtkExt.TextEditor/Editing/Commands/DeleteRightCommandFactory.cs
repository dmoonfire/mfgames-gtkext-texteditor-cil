// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.Commands;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Renderers;
using MfGames.HierarchicalPaths;

namespace MfGames.GtkExt.TextEditor.Editing.Commands
{
	/// <summary>
	/// Implements the command factory for handling the "delete left" (backspace).
	/// </summary>
	public class DeleteRightCommandFactory: TextEditingCommandFactory
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
			return "Delete Right";
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
			// Figure out which command we'll be passing the operation to.
			HierarchicalPath key;

			if (!displayContext.Caret.Selection.IsEmpty)
			{
				// If we have a selection, then we use the Delete Selection command.
				key = DeleteSelectionCommandFactory.Key;
			}
			else if (position.IsEndOfBuffer(controller.DisplayContext))
			{
				// If we are the beginning of the buffer, then we can't delete anything.
				return;
			}
			else if (position.IsEndOfLine(controller.DisplayContext))
			{
				// If we are at the beginning of the line, then we are combining paragraphs.
				key = JoinNextParagraphCommandFactory.Key;
			}
			else
			{
				// Delete the next character only.
				key = DeleteRightCharacterCommandFactory.Key;
			}

			// Execute the command and pass the results to calling method.
			var nextCommand = new CommandFactoryReference(key);
			commandFactory.Do(context, nextCommand);
		}

		#endregion

		#region Constructors

		static DeleteRightCommandFactory()
		{
			Key = new HierarchicalPath(
				"/Text Editor/Delete Right", HierarchicalPathOptions.InternStrings);
		}

		#endregion
	}
}
