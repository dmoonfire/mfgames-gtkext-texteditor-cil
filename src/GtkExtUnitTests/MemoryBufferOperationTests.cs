// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Models.Buffers;
using NUnit.Framework;

namespace MfGames.GtkExt.TextEditor.Models.Tests
{
	/// <summary>
	/// Tests the various functionality of operations on the memory buffer.
	/// </summary>
	[TestFixture]
	public class MemoryBufferOperationTests
	{
		#region Methods

		/// <summary>
		/// Creates the buffer and verifies the setup works.
		/// </summary>
		[Test]
		public void CreateBuffer()
		{
			// This test does nothing, just verifies that the setup works.
		}

		/// <summary>
		/// Deletes the text from the beginning of the line.
		/// </summary>
		[Test]
		public void DeleteTextFromBeginningOfLine()
		{
			// Setup
			const string input = "one two three";

			buffer.SetText(0, input);

			// Operation
			LineBufferOperationResults results = buffer.DeleteText(0, 0, 4);

			// Verification
			Assert.AreEqual("two three", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"two three".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(0, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Deletes the text from the end of the line.
		/// </summary>
		[Test]
		public void DeleteTextFromEndOfLine()
		{
			// Setup
			const string input = "one two three";

			buffer.SetText(0, input);

			// Operation
			LineBufferOperationResults results = buffer.DeleteText(0, 7, 14);

			// Verification
			Assert.AreEqual("one two", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual("one two".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(7, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Deletes the text from the line using the max value index.
		/// </summary>
		[Test]
		public void DeleteTextFromMaxEndOfLine()
		{
			// Setup
			const string input = "one two three";

			buffer.SetText(0, input);

			// Operation
			LineBufferOperationResults results = buffer.DeleteText(0, 7, Int32.MaxValue);

			// Verification
			Assert.AreEqual("one two", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual("one two".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(7, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Deletes the text from the middle of line.
		/// </summary>
		[Test]
		public void DeleteTextFromMiddleOfLine()
		{
			// Setup
			const string input = "one two three";

			buffer.SetText(0, input);

			// Operation
			LineBufferOperationResults results = buffer.DeleteText(0, 4, 8);

			// Verification
			Assert.AreEqual("one three", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"one three".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(4, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Inserts the one at the beginning of the buffer.
		/// </summary>
		[Test]
		public void InsertOneLine()
		{
			// Setup

			// Operation
			LineBufferOperationResults results = buffer.InsertLines(0, 1);

			// Validation
			Assert.AreEqual(2, buffer.LineCount);
			Assert.AreEqual(1, results.BufferPosition.LineIndex);
			Assert.AreEqual(0, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Inserts the text into the beginning of a line.
		/// </summary>
		[Test]
		public void InsertTextIntoBeginningOfLine()
		{
			// Setup
			const string input = "Test ";

			buffer.SetText(0, "Original");

			// Operation
			LineBufferOperationResults results =
				buffer.InsertText(new BufferPosition(0, 0), input);

			// Verification
			Assert.AreEqual("Test Original", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"Test Original".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(input.Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Inserts the text into an empty line.
		/// </summary>
		[Test]
		public void InsertTextIntoEmptyLine()
		{
			// Setup
			const string input = "Test";

			// Operation
			LineBufferOperationResults results =
				buffer.InsertText(new BufferPosition(0, 0), input);

			// Verification
			Assert.AreEqual(input, buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(input.Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(input.Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Appends text to the end of the line.
		/// </summary>
		[Test]
		public void InsertTextIntoEndOfLine()
		{
			// Setup
			const string input = " Test";

			buffer.SetText(0, "Original");

			// Operation
			LineBufferOperationResults results =
				buffer.InsertText(new BufferPosition(0, "Original".Length), input);

			// Verification
			Assert.AreEqual("Original Test", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"Original Test".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(
				"Original Test".Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Inserts the text at the end of the line using MaxValue as the position.
		/// </summary>
		[Test]
		public void InsertTextIntoMaxEndOfLine()
		{
			// Setup
			const string input = " Test";

			buffer.SetText(0, "Original");

			// Operation
			LineBufferOperationResults results =
				buffer.InsertText(new BufferPosition(0, Int32.MaxValue), input);

			// Verification
			Assert.AreEqual("Original Test", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"Original Test".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(
				"Original Test".Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Inserts the text into the middle of a line.
		/// </summary>
		[Test]
		public void InsertTextIntoMiddleOfLine()
		{
			// Setup
			const string input = "two ";

			buffer.SetText(0, "one three");

			// Operation
			LineBufferOperationResults results =
				buffer.InsertText(new BufferPosition(0, 4), input);

			// Verification
			Assert.AreEqual("one two three", buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(
				"one two three".Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(4 + input.Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Sets the text into an empty line.
		/// </summary>
		[Test]
		public void SetTextIntoEmptyLine()
		{
			// Setup
			const string input = "Test";

			// Operation
			LineBufferOperationResults results = buffer.SetText(0, input);

			// Verification
			Assert.AreEqual(input, buffer.GetLineText(0, LineContexts.None));
			Assert.AreEqual(input.Length, buffer.GetLineLength(0, LineContexts.None));
			Assert.AreEqual(0, results.BufferPosition.LineIndex);
			Assert.AreEqual(input.Length, results.BufferPosition.CharacterIndex);
		}

		/// <summary>
		/// Sets up the test and creates the initial memory buffer.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			buffer = new MemoryLineBuffer();
		}

		#endregion

		#region Fields

		private MemoryLineBuffer buffer;

		#endregion
	}
}
