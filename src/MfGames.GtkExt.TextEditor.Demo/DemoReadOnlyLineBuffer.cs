// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.Text;
using MfGames.GtkExt.TextEditor.Models;
using MfGames.GtkExt.TextEditor.Models.Buffers;

namespace GtkExtDemo.TextEditor
{
	/// <summary>
	/// Implements a read only buffer that populates data with text similiar
	/// to the "ipso lorem" text.
	/// </summary>
	public class DemoReadOnlyLineBuffer: LineBuffer
	{
		#region Properties

		/// <summary>
		/// Gets the number of lines in the buffer.
		/// </summary>
		/// <value>The line count.</value>
		public override int LineCount
		{
			get { return 1000; }
		}

		/// <summary>
		/// If set to <see langword="true"/>, the buffer is read-only and the editing
		/// commands should throw an <see cref="InvalidOperationException"/>.
		/// </summary>
		public override bool ReadOnly
		{
			get { return true; }
		}

		#endregion

		#region Methods

		public override LineBufferOperationResults DeleteLines(
			int lineIndex,
			int count)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Performs the given operation, raising any events for changing.
		/// </summary>
		/// <param name="operation">The operation.</param>
		public override LineBufferOperationResults Do(ILineBufferOperation operation)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the length of the line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>The length of the line.</returns>
		public override int GetLineLength(
			int lineIndex,
			LineContexts lineContexts)
		{
			return GenerateText(lineIndex).Length;
		}

		/// <summary>
		/// Gets the formatted line number for a given line.
		/// </summary>
		/// <param name="lineIndex">The line index in the buffer.</param>
		/// <returns>A formatted line number.</returns>
		public override string GetLineNumber(int lineIndex)
		{
			return (lineIndex + 1).ToString();
		}

		public override string GetLineText(
			int lineIndex,
			LineContexts lineContexts)
		{
			return GenerateText(lineIndex);
		}

		public override LineBufferOperationResults InsertLines(
			int lineIndex,
			int count)
		{
			throw new NotImplementedException();
		}

		public override LineBufferOperationResults InsertText(
			int lineIndex,
			int characterIndex,
			string text)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Generates random text using the line index as a seed.
		/// </summary>
		/// <param name="lineIndex">Index of the line.</param>
		/// <returns></returns>
		private static string GenerateText(int lineIndex)
		{
			// Get the random and determine how many words we'll be selecting.
			var random = new Random(lineIndex + 1);

			int start = random.Next(words.Length);
			int wordCount = random.Next(10, 50);

			// Create the text by selecting the given number of words and
			// appending them to a buffer.
			var buffer = new StringBuilder();

			for (int i = 0;
				i < wordCount;
				i++)
			{
				if (i > 0)
				{
					buffer.Append(" ");
				}

				buffer.Append(words[(i + start) % words.Length]);
			}

			// Return the resulting string.
			return buffer.ToString();
		}

		#endregion

		#region Constructors

		static DemoReadOnlyLineBuffer()
		{
			// Build up the string so it fits the formatting of the source file.
			var b = new StringBuilder();

			b.Append("lorem ipsum dolor sit amet consetetur sadipscing elitr ");
			b.Append("sed diam nonumy eirmod tempor invidunt ut labore et dolore ");
			b.Append("magna aliquyam erat sed diam voluptua at vero eos et accusam ");
			b.Append("et justo duo dolores et ea rebum stet clita kasd gubergren no ");
			b.Append("sea takimata sanctus est lorem ipsum dolor sit amet lorem ");
			b.Append("ipsum dolor sit amet consetetur sadipscing elitr sed diam ");
			b.Append("nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam ");
			b.Append("erat sed diam voluptua at vero eos et accusam et justo duo ");
			b.Append("dolores et ea rebum stet clita kasd gubergren no sea takimata ");
			b.Append("sanctus est lorem ipsum dolor sit amet lorem ipsum dolor sit ");
			b.Append("amet consetetur sadipscing elitr sed diam nonumy eirmod tempor ");
			b.Append(
				"invidunt ut labore et dolore magna aliquyam erat sed diam voluptua ");
			b.Append("at vero eos et accusam et justo duo dolores et ea rebum stet ");
			b.Append("clita kasd gubergren no sea takimata sanctus est lorem ipsum ");
			b.Append("dolor sit amet duis autem vel eum iriure dolor in hendrerit in ");
			b.Append("vulputate velit esse molestie consequat vel illum dolore eu ");
			b.Append("feugiat nulla facilisis at vero eros et accumsan et iusto ");
			b.Append("odio dignissim qui blandit praesent luptatum zzril delenit augue ");
			b.Append("duis dolore te feugait nulla facilisi lorem ipsum dolor sit ");
			b.Append("amet consectetuer adipiscing elit sed diam nonummy nibh euismod ");
			b.Append("tincidunt ut laoreet dolore magna aliquam erat volutpat ut wisi ");
			b.Append("enim ad minim veniam quis nostrud exerci tation ullamcorper ");
			b.Append("suscipit lobortis nisl ut aliquip ex ea commodo consequat duis ");
			b.Append("autem vel eum iriure dolor in hendrerit in vulputate velit esse ");
			b.Append(
				"molestie consequat vel illum dolore eu feugiat nulla facilisis at ");
			b.Append(
				"vero eros et accumsan et iusto odio dignissim qui blandit praesent ");
			b.Append(
				"luptatum zzril delenit augue duis dolore te feugait nulla facilisi ");
			b.Append(
				"nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet ");
			b.Append(
				"doming id quod mazim placerat facer possim assum lorem ipsum dolor ");
			b.Append("sit amet consectetuer adipiscing elit sed diam nonummy nibh ");
			b.Append(
				"euismod tincidunt ut laoreet dolore magna aliquam erat volutpat ut ");
			b.Append("wisi enim ad minim veniam quis nostrud exerci tation ullamcorper");

			// Split on the space and keep it in an array.
			words = b.ToString().Split(' ');
		}

		#endregion

		#region Fields

		private static readonly string[] words;

		#endregion
	}
}
