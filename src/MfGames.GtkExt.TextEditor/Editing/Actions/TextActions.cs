// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System.Text;
using Gdk;
using MfGames.Commands;
using MfGames.Commands.TextEditing;
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
			TextRange selection = displayContext.Caret.Selection;

			if (selection.IsEmpty)
			{
				return;
			}

#if REMOVED
			// Go through the selection and figure out if we have a single-line
			// copy.
			LineBuffer lineBuffer = displayContext.LineBuffer;

			int endLineIndex =
				lineBuffer.NormalizeLineIndex(selection.EndPosition.LinePosition);
			string firstLine = lineBuffer.GetLineText(
				selection.StartPosition.LinePosition, LineContexts.Unformatted);

			if (endLineIndex == selection.StartPosition.LinePosition)
			{
				// Single-line copy is much easier since we just need a substring.
				string singleLineText =
					firstLine.Substring(
						selection.StartPosition.CharacterPosition,
						selection.EndCharacterPosition
							- selection.StartPosition.CharacterPosition);

				// Set the clipboard's text and return.
				displayContext.Clipboard.Text = singleLineText;
				return;
			}

			// For multiple line copies, we need to copy every line from the first
			// to the last. We already have the first, so just copy that.
			var buffer = new StringBuilder();
			buffer.Append(firstLine.Substring(selection.StartPosition.CharacterPosition));
			buffer.Append("\n");

			// Loop through the second to just shy of the last line, adding
			// each one as a full line.
			for (int lineIndex = selection.StartPosition.LinePosition + 1;
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
				          .Substring(0, selection.EndCharacterPosition));

			// Set the clipboard value.
			displayContext.Clipboard.Text = buffer.ToString();
#endif
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
			TextRange selection = displayContext.Caret.Selection;

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
