// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Gdk;
using Gtk;
using MfGames.GtkExt.TextEditor.Editing;
using MfGames.GtkExt.TextEditor.Editing.Actions;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Renderers;
using NUnit.Framework;
using Action = System.Action;
using Key = Gdk.Key;

namespace MfGames.GtkExt.TextEditor.Tests
{
	/// <summary>
	/// Tests the various functionality of text actions.
	/// </summary>
	[TestFixture]
	public class TextActionTests
	{
		#region Methods

		/// <summary>
		/// Inserts the multiple paragraphs into the buffer.
		/// </summary>
		[Test]
		public void InsertMultipleParagraphs()
		{
			// Setup

			// Operation
			TextActions.InsertText(controller, "One");
			TextActions.InsertParagraph(controller);
			TextActions.InsertText(controller, "Two");
			TextActions.InsertParagraph(controller);
			TextActions.InsertText(controller, "Three");

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("One", buffer.GetLineText(0));
			Assert.AreEqual("Two", buffer.GetLineText(1));
			Assert.AreEqual("Three", buffer.GetLineText(2));
		}

		/// <summary>
		/// Inserts a short amount of text using the HandleKeyPress.
		/// </summary>
		[Test]
		public void InsertTextUsingHandleKeyPress()
		{
			// Setup

			// Operation
			controller.HandleKeyPress(Key.T, ModifierType.None, 'T');
			controller.HandleKeyPress(Key.h, ModifierType.None, 'e');
			controller.HandleKeyPress(Key.i, ModifierType.None, 's');
			controller.HandleKeyPress(Key.s, ModifierType.None, 't');

			// Verification
			Assert.AreEqual(1, buffer.LineCount);
			Assert.AreEqual("Test", buffer.GetLineText(0));
		}

		/// <summary>
		/// Inserts the text using the TextAction single character entry.
		/// </summary>
		[Test]
		public void InsertTextUsingTextActionChar()
		{
			// Setup

			// Operation
			TextActions.InsertText(controller, 'T');
			TextActions.InsertText(controller, 'e');
			TextActions.InsertText(controller, 's');
			TextActions.InsertText(controller, 't');

			// Verification
			Assert.AreEqual(1, buffer.LineCount);
			Assert.AreEqual("Test", buffer.GetLineText(0));
		}

		/// <summary>
		/// Inserts the text using the TextAction single character entry.
		/// </summary>
		[Test]
		public void InsertTextUsingTextActionString()
		{
			// Setup

			// Operation
			TextActions.InsertText(controller, "Test");

			// Verification
			Assert.AreEqual(1, buffer.LineCount);
			Assert.AreEqual("Test", buffer.GetLineText(0));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew ";
			editor.Caret.Position = new BufferPosition(1, 0);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("New Line 2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\nNew";
			editor.Caret.Position = new BufferPosition(1, 0).ToEndOfLine(renderer);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2 Inserted", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleEolAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew\n";
			editor.Caret.Position = new BufferPosition(1, 0);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("Line 2", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleEolAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\nNew\n";
			editor.Caret.Position = new BufferPosition(1, 0).ToEndOfLine(renderer);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2 Inserted", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleEolInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew\n";
			editor.Caret.Position = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line Insert", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("2", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteMultipleInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew ";
			editor.Caret.Position = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line Insert", buffer.GetLineText(1));
			Assert.AreEqual("New 2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert ";
			editor.Caret.Position = new BufferPosition(1, 0);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert Line 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted";
			editor.Caret.Position = new BufferPosition(1, 0).ToEndOfLine(renderer);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2 Inserted", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleEolAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\n";
			editor.Caret.Position = new BufferPosition(1, 0);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("Line 2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleEolAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\n";
			editor.Caret.Position = new BufferPosition(1, 0).ToEndOfLine(renderer);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2 Inserted", buffer.GetLineText(1));
			Assert.AreEqual("", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleEolInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\n";
			editor.Caret.Position = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line Insert", buffer.GetLineText(1));
			Assert.AreEqual("2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert ";
			editor.Caret.Position = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line Insert 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew ";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 0);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("New 2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\nNew";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 6);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Lin Inserted", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleEolAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 0);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("2", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleEolAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\nNew\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 6);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Lin Inserted", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleEolInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(5, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("LinInsert", buffer.GetLineText(1));
			Assert.AreEqual("New", buffer.GetLineText(2));
			Assert.AreEqual("2", buffer.GetLineText(3));
			Assert.AreEqual("Line 3", buffer.GetLineText(4));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionMultipleInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\nNew ";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("LinInsert", buffer.GetLineText(1));
			Assert.AreEqual("New 2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert ";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 0);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 6);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Lin Inserted", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleEolAtBeginning()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 0);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Insert", buffer.GetLineText(1));
			Assert.AreEqual("2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleEolAtEnd()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = " Inserted\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 6);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Lin Inserted", buffer.GetLineText(1));
			Assert.AreEqual("", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleEolInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert\n";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(4, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("LinInsert", buffer.GetLineText(1));
			Assert.AreEqual("2", buffer.GetLineText(2));
			Assert.AreEqual("Line 3", buffer.GetLineText(3));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void PasteSingleSelectionSingleInMiddle()
		{
			// Setup
			InsertPatternIntoBuffer(3);
			editor.Clipboard.Text = "Insert ";
			editor.Caret.Selection.AnchorPosition = new BufferPosition(1, 3);
			editor.Caret.Selection.TailPosition = new BufferPosition(1, 5);

			// Operation
			TextActions.Paste(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("LinInsert 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Sets up the individual tests with a clean slate.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			// Set up an editor without a cached renderer and a memory buffer
			// we can easily verify.
			editor = new EditorView();
			controller = editor.Controller;
			buffer = new MemoryLineBuffer();
			renderer = new LineBufferRenderer(editor, buffer);

			editor.SetRenderer(renderer);
		}

		/// <summary>
		/// Configures the entire fixture to ensure Gtk# is initialized.
		/// </summary>
		[TestFixtureSetUp]
		public void SetupFixture()
		{
			// Set up Gtk
			Application.Init();
		}

		/// <summary>
		/// Verifies that the pattern insert method works correctly.
		/// </summary>
		[Test]
		public void TestInsertPatternIntoBuffer()
		{
			// Setup

			// Operation
			InsertPatternIntoBuffer(3);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleAtBeginning()
		{
			Undo(PasteMultipleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleAtEnd()
		{
			Undo(PasteMultipleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleEolAtBeginning()
		{
			Undo(PasteMultipleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleEolAtEnd()
		{
			Undo(PasteMultipleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleEolInMiddle()
		{
			Undo(PasteMultipleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteMultipleInMiddle()
		{
			Undo(PasteMultipleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleAtBeginning()
		{
			Undo(PasteSingleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleAtEnd()
		{
			Undo(PasteSingleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleEolAtBeginning()
		{
			Undo(PasteSingleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleEolAtEnd()
		{
			Undo(PasteSingleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleEolInMiddle()
		{
			Undo(PasteSingleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleInMiddle()
		{
			Undo(PasteSingleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleAtBeginning()
		{
			Undo(PasteSingleSelectionMultipleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleAtEnd()
		{
			Undo(PasteSingleSelectionMultipleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleEolAtBeginning()
		{
			Undo(PasteSingleSelectionMultipleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleEolAtEnd()
		{
			Undo(PasteSingleSelectionMultipleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleEolInMiddle()
		{
			Undo(PasteSingleSelectionMultipleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionMultipleInMiddle()
		{
			Undo(PasteSingleSelectionMultipleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleAtBeginning()
		{
			Undo(PasteSingleSelectionSingleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleAtEnd()
		{
			Undo(PasteSingleSelectionSingleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleEolAtBeginning()
		{
			Undo(PasteSingleSelectionSingleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleEolAtEnd()
		{
			Undo(PasteSingleSelectionSingleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleEolInMiddle()
		{
			Undo(PasteSingleSelectionSingleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoPasteSingleSelectionSingleInMiddle()
		{
			Undo(PasteSingleSelectionSingleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleAtBeginning()
		{
			UndoRedoUndo(PasteMultipleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleAtEnd()
		{
			UndoRedoUndo(PasteMultipleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleEolAtBeginning()
		{
			UndoRedoUndo(PasteMultipleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleEolAtEnd()
		{
			UndoRedoUndo(PasteMultipleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleEolInMiddle()
		{
			UndoRedoUndo(PasteMultipleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteMultipleInMiddle()
		{
			UndoRedoUndo(PasteMultipleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleAtBeginning()
		{
			UndoRedoUndo(PasteSingleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleAtEnd()
		{
			UndoRedoUndo(PasteSingleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleEolAtBeginning()
		{
			UndoRedoUndo(PasteSingleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleEolAtEnd()
		{
			UndoRedoUndo(PasteSingleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleEolInMiddle()
		{
			UndoRedoUndo(PasteSingleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleInMiddle()
		{
			UndoRedoUndo(PasteSingleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleAtBeginning()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleAtEnd()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleEolAtBeginning()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleEolAtEnd()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleEolInMiddle()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionMultipleInMiddle()
		{
			UndoRedoUndo(PasteSingleSelectionMultipleInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleAtBeginning()
		{
			UndoRedoUndo(PasteSingleSelectionSingleAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleAtEnd()
		{
			UndoRedoUndo(PasteSingleSelectionSingleAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleEolAtBeginning()
		{
			UndoRedoUndo(PasteSingleSelectionSingleEolAtBeginning);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleEolAtEnd()
		{
			UndoRedoUndo(PasteSingleSelectionSingleEolAtEnd);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleEolInMiddle()
		{
			UndoRedoUndo(PasteSingleSelectionSingleEolInMiddle);
		}

		/// <summary>
		/// Pastes a single line text into the middle of a string.
		/// </summary>
		[Test]
		public void UndoRedoUndoPasteSingleSelectionSingleInMiddle()
		{
			UndoRedoUndo(PasteSingleSelectionSingleInMiddle);
		}

		/// <summary>
		/// Verifies that the unit tests can start without errors.
		/// </summary>
		[Test]
		public void VerifySetup()
		{
		}

		/// <summary>
		/// Inserts patterned text into the buffer.
		/// </summary>
		private void InsertPatternIntoBuffer(int lines)
		{
			for (int i = 0;
				i < lines;
				i++)
			{
				if (i > 0)
				{
					TextActions.InsertParagraph(controller);
				}

				TextActions.InsertText(controller, "Line " + (i + 1));
			}
		}

		/// <summary>
		/// Runs the test, then runs the undo operation and verifies that the
		/// buffer is identical to the original one.
		/// </summary>
		/// <param name="test">The test.</param>
		private void Undo(Action test)
		{
			// Setup
			BufferPosition startingPosition = editor.Caret.Position;
			test();

			// Operation
			CommandActions.Undo(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
			Assert.AreEqual(startingPosition, editor.Caret.Position);
		}

		/// <summary>
		/// Performs the action, undoes it, redoes it, and undoes it. Then
		/// verifies that the buffer is correct.
		/// </summary>
		/// <param name="test">The test.</param>
		private void UndoRedoUndo(Action test)
		{
			// Setup
			BufferPosition startingPosition = editor.Caret.Position;
			test();

			// Operation
			CommandActions.Undo(controller);
			CommandActions.Redo(controller);
			CommandActions.Undo(controller);

			// Verification
			Assert.AreEqual(3, buffer.LineCount);
			Assert.AreEqual("Line 1", buffer.GetLineText(0));
			Assert.AreEqual("Line 2", buffer.GetLineText(1));
			Assert.AreEqual("Line 3", buffer.GetLineText(2));
			Assert.AreEqual(startingPosition, editor.Caret.Position);
		}

		#endregion

		#region Fields

		private MemoryLineBuffer buffer;
		private EditorViewController controller;
		private EditorView editor;
		private EditorViewRenderer renderer;

		#endregion
	}
}
