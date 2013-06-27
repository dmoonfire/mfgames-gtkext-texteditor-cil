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
	/// Performs a series of exhaustive tests on the selection using data generated
	/// by the CreateExhaustiveSelectionTests project.
	/// </summary>
	public class ExhaustiveSelectionTests
	{
		#region Methods

		/// <summary>
		/// Performs one of the exhaustive tests by taking the input and applying
		/// the selection to characters 3-4.
		/// </summary>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		/// <param name="input">The input.</param>
		/// <param name="desiredOutput">The output.</param>
		protected void TestExhaustive(
			int startIndex,
			int endIndex,
			string input,
			string desiredOutput)
		{
			// Setup
			var selectionRenderer = new SelectionRenderer();
			var characters = new CharacterRange(startIndex, endIndex);

			// Operation
			string output = selectionRenderer.GetSelectionMarkup(
				input, characters, "s", String.Empty);

			// Verification
			Assert.AreEqual(desiredOutput, output);
		}

		#endregion
	}
}
