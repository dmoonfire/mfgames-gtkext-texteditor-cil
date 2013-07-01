// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace PatternBuilder
{
	/// <summary>
	/// Main entry point into the application. Builds up the various tests cases
	/// and their permutations.
	/// </summary>
	internal class Program
	{
		#region Methods

		/// <summary>
		/// Appends the built input and expected patterns to the two buffers.
		/// </summary>
		/// <param name="inputBuffer">The input buffer.</param>
		/// <param name="expectedBuffer">The expected buffer.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="index">The index.</param>
		/// <param name="s0">The s0.</param>
		/// <param name="s1">The s1.</param>
		/// <param name="a0">The a0.</param>
		/// <param name="a1">The a1.</param>
		/// <param name="b0">The b0.</param>
		/// <param name="b1">The b1.</param>
		/// <param name="c0">The c0.</param>
		/// <param name="c1">The c1.</param>
		private static void Append(
			StringBuilder inputBuffer,
			StringBuilder expectedBuffer,
			string tag,
			int index,
			int s0,
			int s1,
			int a0,
			int a1,
			int b0,
			int b1,
			int c0,
			int c1)
		{
			// Handle the tags that are in both buffers.
			AppendIfIndex(c1 == index && c0 >= 0, "</c>", inputBuffer, expectedBuffer);
			AppendIfIndex(b1 == index && b0 >= 0, "</b>", inputBuffer, expectedBuffer);
			AppendIfIndex(a1 == index && a0 >= 0, "</a>", inputBuffer, expectedBuffer);

			// Process the selection code.
			if (s0 > 0
				&& index == s0)
			{
				const int sIndex = 2;

				AppendIfIndex(c0 < sIndex && c1 > sIndex, "</c>", expectedBuffer);
				AppendIfIndex(b0 < sIndex && b1 > sIndex, "</b>", expectedBuffer);
				AppendIfIndex(a0 < sIndex && a1 > sIndex, "</a>", expectedBuffer);

				expectedBuffer.Append("<s>");

				AppendIfIndex(a0 < sIndex && a1 > sIndex, "<a>", expectedBuffer);
				AppendIfIndex(b0 < sIndex && b1 > sIndex, "<b>", expectedBuffer);
				AppendIfIndex(c0 < sIndex && c1 > sIndex, "<c>", expectedBuffer);
			}

			if (s1 < Length
				&& index == s1)
			{
				const int sIndex = 4;

				AppendIfIndex(c0 < sIndex && c1 > sIndex, "</c>", expectedBuffer);
				AppendIfIndex(b0 < sIndex && b1 > sIndex, "</b>", expectedBuffer);
				AppendIfIndex(a0 < sIndex && a1 > sIndex, "</a>", expectedBuffer);

				expectedBuffer.Append("</s>");

				AppendIfIndex(a0 < sIndex && a1 > sIndex, "<a>", expectedBuffer);
				AppendIfIndex(b0 < sIndex && b1 > sIndex, "<b>", expectedBuffer);
				AppendIfIndex(c0 < sIndex && c1 > sIndex, "<c>", expectedBuffer);
			}

			AppendIfIndex(a0 == index, "<a>", inputBuffer, expectedBuffer);
			AppendIfIndex(b0 == index, "<b>", inputBuffer, expectedBuffer);
			AppendIfIndex(c0 == index, "<c>", inputBuffer, expectedBuffer);

			// Add the remaining tags.
			inputBuffer.Append(tag);
			expectedBuffer.Append(tag);
		}

		/// <summary>
		/// Appends to the buffers if the check it true.
		/// </summary>
		/// <param name="check">if set to <c>true</c> [check].</param>
		/// <param name="tag">The tag.</param>
		/// <param name="buffers">The buffers.</param>
		private static void AppendIfIndex(
			bool check,
			string tag,
			params StringBuilder[] buffers)
		{
			if (check)
			{
				foreach (StringBuilder buffer in buffers)
				{
					buffer.Append(tag);
				}
			}
		}

		/// <summary>
		/// Writes out the final boilerplate for the writers.
		/// </summary>
		/// <param name="writers">The writers.</param>
		private static void CloseWriter(params TextWriter[] writers)
		{
			foreach (TextWriter writer in writers)
			{
				writer.WriteLine("\t}");
				writer.WriteLine("}");
			}
		}

		/// <summary>
		/// Creates a file writer and adds boilerplate in the beginning.
		/// </summary>
		/// <param name="basename">The basename.</param>
		/// <returns></returns>
		private static TextWriter CreateWriter(string basename)
		{
			// Create a text writer out of the stream.
			FileStream stream = File.Open(
				basename + ".cs", FileMode.Create, FileAccess.Write);
			var writer = new StreamWriter(stream);

			// Add the boilerplate for the beginning of the file.
			writer.WriteLine("using System;");
			writer.WriteLine("");
			writer.WriteLine("using MfGames.GtkExt.TextEditor.Buffers;");
			writer.WriteLine("using MfGames.GtkExt.TextEditor.Renderers;");
			writer.WriteLine("");
			writer.WriteLine("using NUnit.Framework;");
			writer.WriteLine("");
			writer.WriteLine("namespace MfGames.GtkExt.TextEditor.Tests");
			writer.WriteLine("{");
			writer.WriteLine("\t/// <summary>");
			writer.WriteLine(
				"\t/// Performs a series of exhaustive tests on the selection using data generated");
			writer.WriteLine("\t/// by the CreateExhaustiveSelectionTests project.");
			writer.WriteLine("\t/// </summary>");
			writer.WriteLine("\t[TestFixture]");
			writer.WriteLine(
				"\tpublic class " + basename + " : SelectionHelperExhaustiveTests");
			writer.WriteLine("\t{");

			// Return the resulting writer.
			return writer;
		}

		/// <summary>
		/// Generates a series of tests with the given inputs and writes them
		/// to the output.
		/// </summary>
		private static void GenerateTest(
			TextWriter simpleWriter,
			TextWriter attributeWriter,
			TextWriter entityWriter,
			int s0,
			int s1,
			int a0,
			int a1)
		{
			GenerateTest(
				simpleWriter, attributeWriter, entityWriter, s0, s1, a0, a1, -1, -1);
		}

		/// <summary>
		/// Generates a series of tests with the given inputs and writes them
		/// to the output.
		/// </summary>
		private static void GenerateTest(
			TextWriter simpleWriter,
			TextWriter attributeWriter,
			TextWriter entityWriter,
			int s0,
			int s1,
			int a0,
			int a1,
			int b0,
			int b1)
		{
			GenerateTest(
				simpleWriter, attributeWriter, entityWriter, s0, s1, a0, a1, b0, b1, -1, -1);
		}

		/// <summary>
		/// Generates a series of tests with the given inputs and writes them
		/// to the output.
		/// </summary>
		private static void GenerateTest(
			TextWriter simpleWriter,
			TextWriter attributeWriter,
			TextWriter entityWriter,
			int s0,
			int s1,
			int a0,
			int a1,
			int b0,
			int b1,
			int c0,
			int c1)
		{
			// Build up the string input and output.
			var buffer0 = new StringBuilder();
			var buffer1 = new StringBuilder();

			if (s0 == 0)
			{
				buffer1.Append("<s>");
			}

			Append(buffer0, buffer1, "1", 0, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "2", 1, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "3", 2, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "4", 3, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "5", 4, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "6", 5, s0, s1, a0, a1, b0, b1, c0, c1);
			Append(buffer0, buffer1, "", 6, s0, s1, a0, a1, b0, b1, c0, c1);

			if (s1 == Length)
			{
				buffer1.Append("</s>");
			}

			// Try to parse it as XML.
			var xml = new XmlDocument();
			string xml1 = "<z>" + buffer1 + "</z>";
			bool validXml;

			try
			{
				xml.Load(new StringReader(xml1));
				validXml = true;
			}
			catch (Exception)
			{
				validXml = false;
			}

			// Figure out the name of the test.
			var name = new StringBuilder();

			name.AppendFormat("_S{2}_{3}_A{0}_{1}", a0 + 1, a1, s0, s1);

			if (b0 >= 0)
			{
				name.AppendFormat("_B{0}_{1}", b0, b1);
			}

			if (c0 >= 0)
			{
				name.AppendFormat("_C{0}_{1}", c0, c1);
			}

			if (!validXml)
			{
				Console.WriteLine(
					"{2} {0} {1}",
					buffer0,
					buffer1,
					validXml
						? "Yes"
						: "NO!");
			}

			// Write out the simple pattern pattern.
			simpleWriter.WriteLine("/// <summary/>");
			simpleWriter.WriteLine("[Test]");
			simpleWriter.WriteLine("[Category(\"Simple Patterns\")]");
			simpleWriter.WriteLine(
				"public void SimplePattern{0}() {{ TestExhaustive({3}, {4}, \"{1}\", \"{2}\"); }}",
				name,
				buffer0,
				buffer1,
				s0,
				s1);

			// Write out a pattern with entities.
			string entity0 =
				buffer0.ToString()
				       .Replace("1", "&amp;")
				       .Replace("2", "&gt;")
				       .Replace("3", "&#8226;")
				       .Replace("4", "&#x2022;")
				       .Replace("5", "&bull;");

			string entity1 =
				buffer1.ToString()
				       .Replace("1", "&amp;")
				       .Replace("2", "&gt;")
				       .Replace("3", "&#8226;")
				       .Replace("4", "&#x2022;")
				       .Replace("5", "&bull;");

			entityWriter.WriteLine("/// <summary/>");
			entityWriter.WriteLine("[Test]");
			entityWriter.WriteLine("[Category(\"Entity Patterns\")]");
			entityWriter.WriteLine(
				"public void EntityPattern{0}() {{ TestExhaustive({3}, {4}, \"{1}\", \"{2}\"); }}",
				name,
				entity0,
				entity1,
				s0,
				s1);

			// Write out a pattern with attributes.
			string attr0 =
				buffer0.ToString()
				       .Replace("<a>", "<a x=\\\"0\\\">")
				       .Replace("<b>", "<b c0='n' c1='g'>")
				       .Replace("<c>", "<c i='&amp;'>");

			string attr1 =
				buffer1.ToString()
				       .Replace("<a>", "<a x=\\\"0\\\">")
				       .Replace("<b>", "<b c0='n' c1='g'>")
				       .Replace("<c>", "<c i='&amp;'>");

			attributeWriter.WriteLine("/// <summary/>");
			attributeWriter.WriteLine("[Test]");
			attributeWriter.WriteLine("[Category(\"Attribute Patterns\")]");
			attributeWriter.WriteLine(
				"public void AttributePattern{0}() {{ TestExhaustive({3}, {4}, \"{1}\", \"{2}\"); }}",
				name,
				attr0,
				attr1,
				s0,
				s1);
		}

		/// <summary>
		/// Main entry point into the generator.
		/// </summary>
		private static void Main()
		{
			// Create the output file and write to it.
			using (
				TextWriter simple24 = CreateWriter("SimpleCenterSelectionExhaustiveTests"))
			{
				using (
					TextWriter attr24 = CreateWriter("AttributeCenterSelectionExhaustiveTests")
					)
				{
					using (
						TextWriter entity24 = CreateWriter("EntityCenterSelectionExhaustiveTests")
						)
					{
						using (
							TextWriter simple04 = CreateWriter("SimpleStartSelectionExhaustiveTests")
							)
						{
							using (
								TextWriter attr04 =
									CreateWriter("AttributeStartSelectionExhaustiveTests"))
							{
								using (
									TextWriter entity04 =
										CreateWriter("EntityStartSelectionExhaustiveTests"))
								{
									using (
										TextWriter simple27 = CreateWriter(
											"SimpleEndSelectionExhaustiveTests"))
									{
										using (
											TextWriter attr27 =
												CreateWriter("AttributeEndSelectionExhaustiveTests"))
										{
											using (
												TextWriter entity27 =
													CreateWriter("EntityEndSelectionExhaustiveTests"))
											{
												{
													// Start by looping through the first level tags.
													for (int a0 = -1;
														a0 < Length;
														a0++)
													{
														for (int a1 = a0 + 1;
															a1 < Length;
															a1++)
														{
															// Generate a test that only uses a single attribute.
															GenerateTest(simple24, attr24, entity24, 2, 4, a0, a1);
															GenerateTest(simple04, attr04, entity04, 0, 4, a0, a1);
															GenerateTest(simple27, attr27, entity27, 2, Length, a0, a1);

															// If we are less than zero, we already have the empty
															// pattern and we don't need to recurse.
															if (a0 < 0)
															{
																break;
															}

															// Create tests for two tags, one inside the other.
															for (int b0 = a0;
																b0 <= a1;
																b0++)
															{
																for (int b1 = b0 + 1;
																	b1 <= a1;
																	b1++)
																{
																	// Generate the test.
																	GenerateTest(simple24, attr24, entity24, 2, 4, a0, a1, b0, b1);
																	GenerateTest(simple04, attr04, entity04, 0, 4, a0, a1, b0, b1);
																	GenerateTest(
																		simple27, attr27, entity27, 2, Length, a0, a1, b0, b1);

																	// Add a third tag on the same level as the one
																	// above it, but not overlapping with the b tags.
																	for (int c0 = b1;
																		c0 <= a1;
																		c0++)
																	{
																		for (int c1 = c0 + 1;
																			c1 <= a1;
																			c1++)
																		{
																			GenerateTest(
																				simple24, attr24, entity24, 2, 4, a0, a1, b0, b1, c0, c1);
																			GenerateTest(
																				simple04, attr04, entity04, 0, 4, a0, a1, b0, b1, c0, c1);
																			GenerateTest(
																				simple27,
																				attr27,
																				entity27,
																				2,
																				Length,
																				a0,
																				a1,
																				b0,
																				b1,
																				c0,
																				c1);
																		}
																	}
																}
															}

															// Create a test where A and B are non-overlapping tests.
															for (int b0 = a1;
																b0 < Length;
																b0++)
															{
																for (int b1 = b0 + 1;
																	b1 < Length;
																	b1++)
																{
																	// Create the non-overlapping tests.
																	GenerateTest(simple24, attr24, entity24, 2, 4, a0, a1, b0, b1);
																	GenerateTest(simple04, attr04, entity04, 0, 4, a0, a1, b0, b1);
																	GenerateTest(
																		simple27, attr27, entity27, 2, Length, a0, a1, b0, b1);
																}
															}
														}
													}
												}

												// Close all the writers.
												CloseWriter(simple24, attr24, entity24);
												CloseWriter(simple04, attr04, entity04);
												CloseWriter(simple27, attr27, entity27);
											}
										}
									}
								}
							}
						}
					}
				}
			}

			// We are done, show something to the user.
			Console.WriteLine("Press ENTER to quit.");
			Console.ReadLine();
		}

		#endregion

		#region Fields

		/// <summary>
		/// Contains the length of the string.
		/// </summary>
		private const int Length = 7;

		#endregion
	}
}
