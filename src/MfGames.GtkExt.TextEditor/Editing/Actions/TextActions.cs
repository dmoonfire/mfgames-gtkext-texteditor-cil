// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Text;
using Gdk;
using MfGames.Commands;
using MfGames.GtkExt.TextEditor.Editing.Commands;
using MfGames.GtkExt.TextEditor.Interfaces;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace MfGames.GtkExt.TextEditor.Editing.Actions
{
	/// <summary>
	/// Contains the various actions used for moving the caret (cursor) around
	/// the text buffer.
	/// </summary>
	[ActionFixture]
	public static class TextActions
	{
		#region Methods

		/// <summary>
		/// Copies the selection into the clipboard.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[ActionState(typeof (VerticalMovementActionState))]
		[KeyBinding(Key.C, ModifierType.ControlMask)]
		[KeyBinding(Key.Insert, ModifierType.ControlMask)]
		public static void Copy(EditorViewController controller)
		{
			// If we don't have anything selected, we don't do anything.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferSegment selection = displayContext.Caret.Selection;

			if (selection.IsEmpty)
			{
				return;
			}

			// Go through the selection and figure out if we have a single-line
			// copy.
			LineBuffer lineBuffer = displayContext.LineBuffer;

			int endLineIndex =
				lineBuffer.NormalizeLineIndex(selection.EndPosition.LineIndex);
			string firstLine = lineBuffer.GetLineText(
				selection.StartPosition.LineIndex, LineContexts.Unformatted);

			if (endLineIndex == selection.StartPosition.LineIndex)
			{
				// Single-line copy is much easier since we just need a substring.
				string singleLineText =
					firstLine.Substring(
						selection.StartPosition.CharacterIndex,
						selection.EndPosition.CharacterIndex
							- selection.StartPosition.CharacterIndex);

				// Set the clipboard's text and return.
				displayContext.Clipboard.Text = singleLineText;
				return;
			}

			// For multiple line copies, we need to copy every line from the first
			// to the last. We already have the first, so just copy that.
			var buffer = new StringBuilder();
			buffer.Append(firstLine.Substring(selection.StartPosition.CharacterIndex));
			buffer.Append("\n");

			// Loop through the second to just shy of the last line, adding
			// each one as a full line.
			for (int lineIndex = selection.StartPosition.LineIndex + 1;
				lineIndex < endLineIndex;
				lineIndex++)
			{
				buffer.Append(lineBuffer.GetLineText(lineIndex, LineContexts.Unformatted));
				buffer.Append("\n");
			}

			// Add the last line, which is a substring, but we don't add a
			// newline to the end of this one.
			buffer.Append(
				lineBuffer.GetLineText(endLineIndex, LineContexts.Unformatted)
				          .Substring(0, selection.EndPosition.CharacterIndex));

			// Set the clipboard value.
			displayContext.Clipboard.Text = buffer.ToString();
		}

		/// <summary>
		/// Copies, then deletes the selected text.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.X, ModifierType.ControlMask)]
		public static void Cut(EditorViewController controller)
		{
			// If we don't have anything selected, we don't do anything.
			IDisplayContext displayContext = controller.DisplayContext;
			BufferSegment selection = displayContext.Caret.Selection;

			if (selection.IsEmpty)
			{
				return;
			}

			// Copy the text first.
			Copy(controller);

			// Then delete the text. Since we know we have a selection, this
			// will only delete the selected text.
			DeleteLeft(controller);
		}

		/// <summary>
		/// Deletes the character to the left.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.BackSpace)]
		public static void DeleteLeft(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(DeleteLeftCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Deletes the left word from the caret.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.BackSpace, ModifierType.ControlMask)]
		public static void DeleteLeftWord(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(LargeDeleteLeftCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Deletes the character to the right.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Delete)]
		public static void DeleteRight(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(DeleteRightCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Deletes the right word from the caret.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Delete, ModifierType.ControlMask)]
		public static void DeleteRightWord(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(LargeDeleteRightCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Inserts the paragraph at the current buffer position.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.Return)]
		public static void InsertParagraph(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(SplitParagraphCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		/// <summary>
		/// Moves the caret down one line.
		/// </summary>
		/// <param name="controller">The display context.</param>
		/// <param name="unicode">The Unicode character.</param>
		public static void InsertText(
			EditorViewController controller,
			char unicode)
		{
			// Bridge into the new command controller subsystem.
			var commandReference =
				new CommandFactoryReference(InsertCharacterCommandFactory.Key, unicode);
			controller.CommandFactory.Do(controller, commandReference);

			//// Because InsertText isn't a proper "action", we need to manually
			//// remove all action states.
			//controller.States.RemoveAllExcluding(typeof (InsertTextActionState));
			//var actionState = controller.States.Get<InsertTextActionState>();

			//// If we have a selection, we need to delete it and work from the
			//// resulting text instead of what is currently in the buffer.
			//IDisplayContext displayContext = controller.DisplayContext;
			//Caret caret = controller.DisplayContext.Caret;
			//BufferPosition position = caret.Position;
			//var command = new Command(position);

			//string lineText;

			//bool deletedSelection = DeleteSelection(
			//	controller, command, ref position, out lineText);

			//if (!deletedSelection)
			//{
			//	// There is no selection, so get the line text from the buffer.
			//	lineText = displayContext.LineBuffer.GetLineText(
			//		caret.Position.LineIndex, LineContexts.Unformatted);
			//}

			//// Create the operation to change the text.
			//var insertTextOperation =
			//	new InsertTextOperation(
			//		(Position) position.LineIndex,
			//		(Position) position.CharacterIndex,
			//		unicode.ToString());

			//// Figure out if we are doing a new command or joining into the
			//// previous one. If we are joining, then we just perform the operations
			//// to set the line text and adding to the command.
			//if (actionState != null)
			//{
			//	// Pull out the text and see if we are entering a word boundary.
			//	string stateText = actionState.Text + unicode;
			//	int wordBoundary = displayContext.WordSplitter.GetNextWordBoundary(
			//		stateText, 0);

			//	if (wordBoundary == stateText.Length)
			//	{
			//		// We aren't at a word boundary, so append the text to
			//		// the state so we can undo/redo it later. Start by setting
			//		// the text to the text value it would have been if the
			//		// operations are combined.
			//		actionState.Text = stateText;

			//		// Change the redo operation to what would be the text
			//		// after this and the previous operations. The undo operation
			//		// doesn't change because it will be the same initial state.
			//		actionState.Operation.Text = stateText;

			//		// After the insert completes, the state's end position would
			//		// shift to the right one more for the new character.
			//		position.CharacterIndex++;
			//		actionState.EndPosition = position;

			//		// Perform the operation and do the various redraws.
			//		// Scroll to the command's end position.
			//		LineBufferOperationResults results = controller.Do(insertTextOperation);

			//		displayContext.ScrollToCaret(results.BufferPosition);

			//		// We are done.
			//		return;
			//	}
			//}

			//// We either don't have a previous state we can append to or there
			//// was no state to start with. So, create a new command with both
			//// the redo and undo operations.
			//command.Operations.Add(insertTextOperation);

			//if (!deletedSelection)
			//{
			//	// We don't need the undo operation if we deleted a selection.
			//	command.UndoOperations.Add(
			//		new SetTextOperation(position.LineIndex, lineText));
			//}

			//// Shift the cursor over since we know this won't be changing lines
			//// and we can avoid some additional refreshes.
			//position.CharacterIndex++;

			//// Perform the operation on the buffer.
			//command.EndPosition = position;
			//controller.Do(command);

			//// Create a new action state and add it to the states list.
			//if (actionState != null)
			//{
			//	controller.States.Remove(actionState);
			//}

			//actionState = new InsertTextActionState(command, unicode.ToString());
			//controller.States.Add(actionState);
		}

		/// <summary>
		/// Inserts the text into the buffer.
		/// </summary>
		/// <param name="controller">The controller.</param>
		/// <param name="input">The input.</param>
		public static void InsertText(
			EditorViewController controller,
			string input)
		{
			foreach (char c in input)
			{
				InsertText(controller, c);
			}
		}

		/// <summary>
		/// Pastes the contents of the clipboard into the buffer.
		/// </summary>
		/// <param name="controller">The action context.</param>
		[Action]
		[KeyBinding(Key.V, ModifierType.ControlMask)]
		public static void Paste(EditorViewController controller)
		{
			// Bridge into the new command controller subsystem.
			var commandReference = new CommandFactoryReference(PasteCommandFactory.Key);
			controller.CommandFactory.Do(controller, commandReference);
		}

		#endregion
	}
}
