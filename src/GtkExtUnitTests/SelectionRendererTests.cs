// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Renderers;
using NUnit.Framework;

namespace MfGames.GtkExt.TextEditor.Tests
{
	/// <summary>
	/// Tests the various functionality and markup of the selection helper.
	/// </summary>
	[TestFixture]
	public class SelectionRendererTests
	{
		#region Methods

		/// <summary>
		/// Tests how the selection helper handles blank strings.
		/// </summary>
		[Test]
		public void HandleBlank()
		{
			// Setup
			string markup = string.Empty;
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(1, 2);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(string.Empty, output);
		}

		/// <summary>
		/// Tests how the selection helper handles <see langword="null"/>.
		/// </summary>
		[Test]
		public void HandleNull()
		{
			// Setup
			const string markup = null;
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(1, 2);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.IsNull(output);
		}

		[Test]
		public void MarkupContaining()
		{
			// Setup
			const string markup = "this i<span>s</span> a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>i<span>s</span> a</span> string", output);
		}

		[Test]
		public void MarkupExact()
		{
			// Setup
			const string markup = "this <span>is a</span> string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'><span>is a</span></span> string", output);
		}

		[Test]
		public void MarkupLeading()
		{
			// Setup
			const string markup = "thi<span>s is</span> a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"thi<span>s </span><span background='#CCCCFF'><span>is</span> a</span> string",
				output);
		}

		[Test]
		public void MarkupOuter()
		{
			// Setup
			const string markup = "thi<span>s is a str</span>ing";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"thi<span>s </span><span background='#CCCCFF'><span>is a</span></span><span> str</span>ing",
				output);
		}

		[Test]
		public void MarkupTrailing()
		{
			// Setup
			const string markup = "this i<span>s a str</span>ing";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>i<span>s a</span></span><span> str</span>ing",
				output);
		}

		[Test]
		public void PlainBeginningOfString()
		{
			// Setup
			const string markup = "this is a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(0, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual("<span background='#CCCCFF'>this is a</span> string", output);
		}

		[Test]
		public void PlainBeginningOfString2()
		{
			// Setup
			const string markup = "this is a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(1, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual("t<span background='#CCCCFF'>his is a</span> string", output);
		}

		/// <summary>
		/// Test rendering a selection at the very end of a line.
		/// </summary>
		[Test]
		public void PlainEmptySelectionAtEndOfLine()
		{
			// Setup
			const string markup = "this";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, Int32.MaxValue);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual("this", output);
		}

		[Test]
		public void PlainEndOfString()
		{
			// Setup
			const string markup = "this is a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, markup.Length);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual("this <span background='#CCCCFF'>is a string</span>", output);
		}

		[Test]
		public void PlainEntity1()
		{
			// Setup
			const string markup = "this &#0069;s a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>&#0069;s a</span> string", output);
		}

		[Test]
		public void PlainEntity2()
		{
			// Setup
			const string markup = "this is &#0061; string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>is &#0061;</span> string", output);
		}

		[Test]
		public void PlainEntity3()
		{
			// Setup
			const string markup = "this i&#0073; a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>i&#0073; a</span> string", output);
		}

		[Test]
		public void PlainEntity4()
		{
			// Setup
			const string markup = "this i&amp; a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual(
				"this <span background='#CCCCFF'>i&amp; a</span> string", output);
		}

		[Test]
		public void PlainMiddleOfString()
		{
			// Setup
			const string markup = "this is a string";
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(5, 9);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(markup, characters);

			// Verification
			Assert.AreEqual("this <span background='#CCCCFF'>is a</span> string", output);
		}

		#endregion
	}
}
