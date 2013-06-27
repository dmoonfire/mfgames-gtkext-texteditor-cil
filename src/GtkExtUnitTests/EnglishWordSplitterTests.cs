// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using MfGames.GtkExt.TextEditor.Editing;
using NUnit.Framework;

namespace MfGames.GtkExt.TextEditor.Tests
{
	/// <summary>
	/// Defines tests that explore the functionality of the 
	/// <c>EnglishWordSplitter</c> class.
	/// </summary>
	[TestFixture]
	public class EnglishWordSplitterTests
	{
		#region Methods

		[Test]
		public void NextOneWord()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "word";
			const int index = 1;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void NextPuncutationWithSpace()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One. Two.";
			const int index = 3;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(5, boundary);
		}

		[Test]
		public void NextPuncutationWithoutSpace()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One.Two.";
			const int index = 3;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void PreviousAtEndOfLine()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One. Two.";
			const int index = 9;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(".", text.Substring(boundary));
			Assert.AreEqual(8, boundary);
		}

		[Test]
		public void PreviousOneWord()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "word";
			const int index = 1;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(0, boundary);
		}

		[Test]
		public void PreviousPuncutationWithSpace()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One. Two.";
			const int index = 6;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(5, boundary);
		}

		[Test]
		public void PreviousPuncutationWithoutSpace()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One.Two.";
			const int index = 5;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void PreviousPuncutationWithoutSpaceInMiddleWithEndingSpace()
		{
			// Setup
			var splitter = new EnglishWordSplitter();
			const string text = "One.Two ";
			const int index = 8;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two ", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		#endregion
	}
}
