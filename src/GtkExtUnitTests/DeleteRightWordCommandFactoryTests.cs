// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using Gtk;
using MfGames.Commands;
using MfGames.GtkExt.TextEditor;
using MfGames.GtkExt.TextEditor.Editing;
using MfGames.GtkExt.TextEditor.Editing.Actions;
using MfGames.GtkExt.TextEditor.Editing.Commands;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Renderers;
using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
	public class DeleteRightWordCommandFactoryTests
	{
		#region Methods

		[Test]
		public void DeleteMiddleOfSentence()
		{
			// Arrange
			EditorViewController controller;
			Caret caret;
			LineBuffer lineBuffer;
			SetupTests(out controller, out caret, out lineBuffer);

			var factory = new DeleteRightWordCommandFactory();
			var reference = new CommandFactoryReference(factory.FactoryKey);

			caret.Position = new BufferPosition(2, 9);

			// Act
			factory.Do(controller, reference, controller.CommandFactory);

			// Assert
			Assert.AreEqual(
				2, caret.Position.LineIndex, "Caret was on an unexpected line.");
			Assert.AreEqual(
				9, caret.Position.CharacterIndex, "Caret was on an unexpected character.");

			Assert.AreEqual(3, lineBuffer.LineCount);
			Assert.AreEqual(DefaultLine, lineBuffer.GetLineText(0));
			Assert.AreEqual(DefaultLine, lineBuffer.GetLineText(1));
			Assert.AreEqual("one, two , four five. Six.", lineBuffer.GetLineText(2));
		}

		[Test]
		public void DeleteMiddleOfSentenceUndo()
		{
			// Arrange
			EditorViewController controller;
			Caret caret;
			LineBuffer lineBuffer;
			SetupTests(out controller, out caret, out lineBuffer);

			var factory = new DeleteRightWordCommandFactory();
			var undo = new UndoCommandFactory();
			var reference = new CommandFactoryReference(factory.FactoryKey);

			caret.Position = new BufferPosition(2, 9);

			factory.Do(controller, reference, controller.CommandFactory);

			// Act
			undo.Do(controller, reference, controller.CommandFactory);

			// Assert
			Assert.AreEqual(
				2, caret.Position.LineIndex, "Caret was on an unexpected line.");
			Assert.AreEqual(
				9, caret.Position.CharacterIndex, "Caret was on an unexpected character.");

			Assert.AreEqual(3, lineBuffer.LineCount);
			Assert.AreEqual(DefaultLine, lineBuffer.GetLineText(0));
			Assert.AreEqual(DefaultLine, lineBuffer.GetLineText(1));
			Assert.AreEqual("one, two three, four five. Six.", lineBuffer.GetLineText(2));
		}

		/// <summary>
		/// Sets up the basic unit tests with set strings and controls.
		/// </summary>
		private void SetupTests(
			out EditorViewController controller,
			out Caret caret,
			out LineBuffer lineBuffer)
		{
			// Set up Gtk so we can create the view.
			Application.Init();

			// Set up an editor without a cached renderer and a memory buffer
			// we can easily verify.
			var view = new EditorView();
			caret = view.Caret;
			lineBuffer = new MemoryLineBuffer();
			controller = view.Controller;
			var renderer = new LineBufferRenderer(view, lineBuffer);

			view.SetRenderer(renderer);

			// Create three lines of text.
			TextActions.InsertText(controller, DefaultLine);
			TextActions.InsertParagraph(controller);
			TextActions.InsertText(controller, DefaultLine);
			TextActions.InsertParagraph(controller);
			TextActions.InsertText(controller, DefaultLine);
		}

		#endregion

		#region Fields

		private const string DefaultLine = "one, two three, four five. Six.";

		#endregion
	}
}
