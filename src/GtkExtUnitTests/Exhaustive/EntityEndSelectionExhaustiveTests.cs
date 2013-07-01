// Copyright 2011-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/mfgames-gtkext-cil/license

using NUnit.Framework;

namespace MfGames.GtkExt.TextEditor.Tests
{
	/// <summary>
	/// Performs a series of exhaustive tests on the selection using data generated
	/// by the CreateExhaustiveSelectionTests project.
	/// </summary>
	[TestFixture]
	public class EntityEndSelectionExhaustiveTests: ExhaustiveSelectionTests
	{
		#region Methods

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A0_0()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;&bull;6",
				"&amp;&gt;<s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;&#x2022;&bull;6",
				"<a>&amp;</a>&gt;<s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b></a>&gt;&#8226;&#x2022;&bull;6",
				"<a><b>&amp;</b></a>&gt;<s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a><b>&gt;</b>&#8226;&#x2022;&bull;6",
				"<a>&amp;</a><b>&gt;</b><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a><b>&gt;&#8226;</b>&#x2022;&bull;6",
				"<a>&amp;</a><b>&gt;</b><s><b>&#8226;</b>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a><b>&gt;&#8226;&#x2022;</b>&bull;6",
				"<a>&amp;</a><b>&gt;</b><s><b>&#8226;&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a><b>&gt;&#8226;&#x2022;&bull;</b>6",
				"<a>&amp;</a><b>&gt;</b><s><b>&#8226;&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B1_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a><b>&gt;&#8226;&#x2022;&bull;6</b>",
				"<a>&amp;</a><b>&gt;</b><s><b>&#8226;&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;<b>&#8226;</b>&#x2022;&bull;6",
				"<a>&amp;</a>&gt;<s><b>&#8226;</b>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;<b>&#8226;&#x2022;</b>&bull;6",
				"<a>&amp;</a>&gt;<s><b>&#8226;&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;<b>&#8226;&#x2022;&bull;</b>6",
				"<a>&amp;</a>&gt;<s><b>&#8226;&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;<b>&#8226;&#x2022;&bull;6</b>",
				"<a>&amp;</a>&gt;<s><b>&#8226;&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;<b>&#x2022;</b>&bull;6",
				"<a>&amp;</a>&gt;<s>&#8226;<b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;<b>&#x2022;&bull;</b>6",
				"<a>&amp;</a>&gt;<s>&#8226;<b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;<b>&#x2022;&bull;6</b>",
				"<a>&amp;</a>&gt;<s>&#8226;<b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;&#x2022;<b>&bull;</b>6",
				"<a>&amp;</a>&gt;<s>&#8226;&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;&#x2022;<b>&bull;6</b>",
				"<a>&amp;</a>&gt;<s>&#8226;&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_1_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;</a>&gt;&#8226;&#x2022;&bull;<b>6</b>",
				"<a>&amp;</a>&gt;<s>&#8226;&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;&#x2022;&bull;6",
				"<a>&amp;&gt;</a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;</a>&#8226;&#x2022;&bull;6",
				"<a><b>&amp;</b>&gt;</a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;</c></a>&#8226;&#x2022;&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B0_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b></a>&#8226;&#x2022;&bull;6",
				"<a><b>&amp;&gt;</b></a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b></a>&#8226;&#x2022;&bull;6",
				"<a>&amp;<b>&gt;</b></a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a><b>&#8226;</b>&#x2022;&bull;6",
				"<a>&amp;&gt;</a><s><b>&#8226;</b>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a><b>&#8226;&#x2022;</b>&bull;6",
				"<a>&amp;&gt;</a><s><b>&#8226;&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a><b>&#8226;&#x2022;&bull;</b>6",
				"<a>&amp;&gt;</a><s><b>&#8226;&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a><b>&#8226;&#x2022;&bull;6</b>",
				"<a>&amp;&gt;</a><s><b>&#8226;&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;<b>&#x2022;</b>&bull;6",
				"<a>&amp;&gt;</a><s>&#8226;<b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;<b>&#x2022;&bull;</b>6",
				"<a>&amp;&gt;</a><s>&#8226;<b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;<b>&#x2022;&bull;6</b>",
				"<a>&amp;&gt;</a><s>&#8226;<b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;&#x2022;<b>&bull;</b>6",
				"<a>&amp;&gt;</a><s>&#8226;&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;&#x2022;<b>&bull;6</b>",
				"<a>&amp;&gt;</a><s>&#8226;&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_2_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;</a>&#8226;&#x2022;&bull;<b>6</b>",
				"<a>&amp;&gt;</a><s>&#8226;&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a>&#x2022;&bull;6",
				"<a>&amp;&gt;</a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;</a>&#x2022;&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;</c>&#8226;</a>&#x2022;&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;</c></a>&#x2022;&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;</c></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;</c></a>&#x2022;&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;</c></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;</a>&#x2022;&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;</c></a>&#x2022;&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;</c></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B0_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b></a>&#x2022;&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;</a>&#x2022;&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;</c></a>&#x2022;&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;</c></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b></a>&#x2022;&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b></a>&#x2022;&bull;6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a><b>&#x2022;</b>&bull;6",
				"<a>&amp;&gt;</a><s><a>&#8226;</a><b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a><b>&#x2022;&bull;</b>6",
				"<a>&amp;&gt;</a><s><a>&#8226;</a><b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a><b>&#x2022;&bull;6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;</a><b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a>&#x2022;<b>&bull;</b>6",
				"<a>&amp;&gt;</a><s><a>&#8226;</a>&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a>&#x2022;<b>&bull;6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;</a>&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_3_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;</a>&#x2022;&bull;<b>6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;</a>&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;</a>&bull;6",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;</a>&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;</c>&#8226;&#x2022;</a>&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;</c>&#x2022;</a>&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;</c>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;</c></a>&bull;6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;</c>&#x2022;</a>&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;</c>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;</c></a>&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;</c></a>&bull;6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;</a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;</c>&#x2022;</a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;</c>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;</c></a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;</c></a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;</a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B0_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b></a>&bull;6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;</a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;</c>&#x2022;</a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;</c></a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;</c></a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;</a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b></a>&bull;6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;</a>&bull;6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b></a>&bull;6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b></a>&bull;6",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;</a><b>&bull;</b>6",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;</a><b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;</a><b>&bull;6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;</a><b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_4_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;</a>&bull;<b>6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;</a>&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;&bull;</a>6",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;&bull;</a>6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;</c>&#8226;&#x2022;&bull;</a>6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;</c>&#x2022;&bull;</a>6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;</c>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;&bull;</c></a>6",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;</c>&#x2022;&bull;</a>6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;</c>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;&bull;</c></a>6",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;&bull;</c></a>6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_1_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;<c>&bull;</c></a>6",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;</c>&#x2022;&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;<c>&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b>&bull;</a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B0_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;&bull;</b></a>6",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;</c>&#x2022;&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;</c>&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;</c>&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;<c>&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b>&bull;</a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;&bull;</b></a>6",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;&bull;</a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b>&bull;</a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;&bull;</b></a>6",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b>&bull;</a>6",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b><c>&bull;</c></a>6",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;&bull;</b></a>6",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;<b>&bull;</b></a>6",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_5_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;&bull;</a><b>6</b>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;&bull;</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;&bull;6</a>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;&bull;6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;</c>&#8226;&#x2022;&bull;6</a>",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;</c>&#x2022;&bull;6</a>",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;</c>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C1_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b><c>&gt;&#8226;&#x2022;&bull;6</c></a>",
				"<a><b>&amp;</b><c>&gt;</c></a><s><a><c>&#8226;&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;</c>&#x2022;&bull;6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;</c>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;<c>&#8226;&#x2022;&bull;6</c></a>",
				"<a><b>&amp;</b>&gt;</a><s><a><c>&#8226;&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;<c>&#x2022;&bull;6</c></a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;<c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;<c>&bull;</c>6</a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;<c>&bull;6</c></a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_1_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;</b>&gt;&#8226;&#x2022;&bull;<c>6</c></a>",
				"<a><b>&amp;</b>&gt;</a><s><a>&#8226;&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;</c>&#x2022;&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b><c>&#8226;&#x2022;&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;<c>&#x2022;&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;<c>&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;<c>&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;</b>&#8226;&#x2022;&bull;<c>6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a>&#8226;&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b>&bull;6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;&bull;</b>6</a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B0_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>&amp;&gt;&#8226;&#x2022;&bull;6</b></a>",
				"<a><b>&amp;&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;</c>&#x2022;&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;</c>&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b><c>&#8226;&#x2022;&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;</c>&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;<c>&#x2022;&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;<c>&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;<c>&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;</b>&#8226;&#x2022;&bull;<c>6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b>&bull;6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;&bull;</b>6</a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B1_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;<b>&gt;&#8226;&#x2022;&bull;6</b></a>",
				"<a>&amp;<b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;&bull;6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b>&bull;6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;&bull;</b>6</a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;<b>&#8226;&#x2022;&bull;6</b></a>",
				"<a>&amp;&gt;</a><s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b>&bull;6</a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b><c>&bull;</c>6</a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b><c>&bull;6</c></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;</b>&bull;<c>6</c></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;&bull;</b>6</a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;&bull;</b><c>6</c></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;<b>&#x2022;&bull;6</b></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;<b>&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;<b>&bull;</b>6</a>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;<b>&bull;</b><c>6</c></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;<b>&bull;6</b></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;<b>&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A1_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>&amp;&gt;&#8226;&#x2022;&bull;<b>6</b></a>",
				"<a>&amp;&gt;</a><s><a>&#8226;&#x2022;&bull;<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;&#x2022;&bull;6",
				"&amp;<a>&gt;</a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b></a>&#8226;&#x2022;&bull;6",
				"&amp;<a><b>&gt;</b></a><s>&#8226;&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a><b>&#8226;</b>&#x2022;&bull;6",
				"&amp;<a>&gt;</a><s><b>&#8226;</b>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a><b>&#8226;&#x2022;</b>&bull;6",
				"&amp;<a>&gt;</a><s><b>&#8226;&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a><b>&#8226;&#x2022;&bull;</b>6",
				"&amp;<a>&gt;</a><s><b>&#8226;&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a><b>&#8226;&#x2022;&bull;6</b>",
				"&amp;<a>&gt;</a><s><b>&#8226;&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;<b>&#x2022;</b>&bull;6",
				"&amp;<a>&gt;</a><s>&#8226;<b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;<b>&#x2022;&bull;</b>6",
				"&amp;<a>&gt;</a><s>&#8226;<b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;<b>&#x2022;&bull;6</b>",
				"&amp;<a>&gt;</a><s>&#8226;<b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;&#x2022;<b>&bull;</b>6",
				"&amp;<a>&gt;</a><s>&#8226;&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;&#x2022;<b>&bull;6</b>",
				"&amp;<a>&gt;</a><s>&#8226;&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_2_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;</a>&#8226;&#x2022;&bull;<b>6</b>",
				"&amp;<a>&gt;</a><s>&#8226;&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a>&#x2022;&bull;6",
				"&amp;<a>&gt;</a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;</a>&#x2022;&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;</c></a>&#x2022;&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;</c></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b></a>&#x2022;&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b></a>&#x2022;&bull;6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a><b>&#x2022;</b>&bull;6",
				"&amp;<a>&gt;</a><s><a>&#8226;</a><b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a><b>&#x2022;&bull;</b>6",
				"&amp;<a>&gt;</a><s><a>&#8226;</a><b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a><b>&#x2022;&bull;6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;</a><b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a>&#x2022;<b>&bull;</b>6",
				"&amp;<a>&gt;</a><s><a>&#8226;</a>&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a>&#x2022;<b>&bull;6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;</a>&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_3_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;</a>&#x2022;&bull;<b>6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;</a>&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;</a>&bull;6",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;</a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;</c>&#x2022;</a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;</c></a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;</c></a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;</a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b></a>&bull;6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;</a>&bull;6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b></a>&bull;6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b></a>&bull;6",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;</a><b>&bull;</b>6",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;</a><b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;</a><b>&bull;6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;</a><b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_4_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;</a>&bull;<b>6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;</a>&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;&bull;</a>6",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;</c>&#x2022;&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;</c>&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;</c>&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;<c>&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b>&bull;</a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B1_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;&bull;</b></a>6",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;&bull;</a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b>&bull;</a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;&bull;</b></a>6",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b>&bull;</a>6",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b><c>&bull;</c></a>6",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;&bull;</b></a>6",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;<b>&bull;</b></a>6",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_5_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;&bull;</a><b>6</b>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;&bull;</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;&bull;6</a>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;</c>&#x2022;&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;</c>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;</c>&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b><c>&#8226;&#x2022;&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><c>&#8226;&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;</c>&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;<c>&#x2022;&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;<c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;<c>&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;<c>&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;</b>&#8226;&#x2022;&bull;<c>6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a>&#8226;&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b>&bull;6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;&bull;</b>6</a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B1_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a><b>&gt;&#8226;&#x2022;&bull;6</b></a>",
				"&amp;<a><b>&gt;</b></a><s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;&bull;6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b>&bull;6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;&bull;</b>6</a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;<b>&#8226;&#x2022;&bull;6</b></a>",
				"&amp;<a>&gt;</a><s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b>&bull;6</a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b><c>&bull;6</c></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;&bull;</b>6</a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;&bull;</b><c>6</c></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;<b>&#x2022;&bull;6</b></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;<b>&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;<b>&bull;</b>6</a>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;<b>&bull;</b><c>6</c></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;<b>&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;<b>&bull;6</b></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;<b>&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A2_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;<a>&gt;&#8226;&#x2022;&bull;<b>6</b></a>",
				"&amp;<a>&gt;</a><s><a>&#8226;&#x2022;&bull;<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a>&#x2022;&bull;6",
				"&amp;&gt;<s><a>&#8226;</a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b></a>&#x2022;&bull;6",
				"&amp;&gt;<s><a><b>&#8226;</b></a>&#x2022;&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a><b>&#x2022;</b>&bull;6",
				"&amp;&gt;<s><a>&#8226;</a><b>&#x2022;</b>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a><b>&#x2022;&bull;</b>6",
				"&amp;&gt;<s><a>&#8226;</a><b>&#x2022;&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a><b>&#x2022;&bull;6</b>",
				"&amp;&gt;<s><a>&#8226;</a><b>&#x2022;&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a>&#x2022;<b>&bull;</b>6",
				"&amp;&gt;<s><a>&#8226;</a>&#x2022;<b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a>&#x2022;<b>&bull;6</b>",
				"&amp;&gt;<s><a>&#8226;</a>&#x2022;<b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_3_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;</a>&#x2022;&bull;<b>6</b>",
				"&amp;&gt;<s><a>&#8226;</a>&#x2022;&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;</a>&bull;6",
				"&amp;&gt;<s><a>&#8226;&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;</a>&bull;6",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;</c></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b></a>&bull;6",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b></a>&bull;6",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;</a><b>&bull;</b>6",
				"&amp;&gt;<s><a>&#8226;&#x2022;</a><b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;</a><b>&bull;6</b>",
				"&amp;&gt;<s><a>&#8226;&#x2022;</a><b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_4_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;</a>&bull;<b>6</b>",
				"&amp;&gt;<s><a>&#8226;&#x2022;</a>&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;&bull;</a>6",
				"&amp;&gt;<s><a>&#8226;&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;&bull;</a>6",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;</c>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;<c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b>&bull;</a>6",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;&bull;</b></a>6",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b>&bull;</a>6",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b><c>&bull;</c></a>6",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;&bull;</b></a>6",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;<b>&bull;</b></a>6",
				"&amp;&gt;<s><a>&#8226;&#x2022;<b>&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_5_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;&bull;</a><b>6</b>",
				"&amp;&gt;<s><a>&#8226;&#x2022;&bull;</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;&bull;6</a>",
				"&amp;&gt;<s><a>&#8226;&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;&bull;6</a>",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a>",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;</c>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a>",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b><c>&#x2022;&bull;6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;</b><c>&#x2022;&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a>",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;<c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;<c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;</b>&#x2022;&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b>&bull;6</a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b><c>&bull;6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;&bull;</b>6</a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;&bull;</b><c>6</c></a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B2_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a><b>&#8226;&#x2022;&bull;6</b></a>",
				"&amp;&gt;<s><a><b>&#8226;&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b>&bull;6</a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b><c>&bull;6</c></a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;&bull;</b>6</a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;&bull;</b><c>6</c></a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;<b>&#x2022;&bull;6</b></a>",
				"&amp;&gt;<s><a>&#8226;<b>&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;<b>&bull;</b>6</a>",
				"&amp;&gt;<s><a>&#8226;&#x2022;<b>&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;<b>&bull;</b><c>6</c></a>",
				"&amp;&gt;<s><a>&#8226;&#x2022;<b>&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;<b>&bull;6</b></a>",
				"&amp;&gt;<s><a>&#8226;&#x2022;<b>&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A3_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;<a>&#8226;&#x2022;&bull;<b>6</b></a>",
				"&amp;&gt;<s><a>&#8226;&#x2022;&bull;<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;</a>&bull;6",
				"&amp;&gt;<s>&#8226;<a>&#x2022;</a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_4_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b></a>&bull;6",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b></a>&bull;6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_4_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;</a><b>&bull;</b>6",
				"&amp;&gt;<s>&#8226;<a>&#x2022;</a><b>&bull;</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_4_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;</a><b>&bull;6</b>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;</a><b>&bull;6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_4_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;</a>&bull;<b>6</b>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;</a>&bull;<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;&bull;</a>6",
				"&amp;&gt;<s>&#8226;<a>&#x2022;&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b>&bull;</a>6",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b><c>&bull;</c></a>6",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b><c>&bull;</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;&bull;</b></a>6",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;<b>&bull;</b></a>6",
				"&amp;&gt;<s>&#8226;<a>&#x2022;<b>&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_5_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;&bull;</a><b>6</b>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;&bull;</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;&bull;6</a>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_4()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b>&bull;6</a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b><c>&bull;</c>6</a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b><c>&bull;</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b><c>&bull;6</c></a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b><c>&bull;6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;</b>&bull;<c>6</c></a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;</b>&bull;<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;&bull;</b>6</a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;&bull;</b><c>6</c></a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B3_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a><b>&#x2022;&bull;6</b></a>",
				"&amp;&gt;<s>&#8226;<a><b>&#x2022;&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;<b>&bull;</b>6</a>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;<b>&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;<b>&bull;</b><c>6</c></a>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;<b>&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;<b>&bull;6</b></a>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;<b>&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A4_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;<a>&#x2022;&bull;<b>6</b></a>",
				"&amp;&gt;<s>&#8226;<a>&#x2022;&bull;<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a>&bull;</a>6",
				"&amp;&gt;<s>&#8226;&#x2022;<a>&bull;</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_5_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a><b>&bull;</b></a>6",
				"&amp;&gt;<s>&#8226;&#x2022;<a><b>&bull;</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_5_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a>&bull;</a><b>6</b>",
				"&amp;&gt;<s>&#8226;&#x2022;<a>&bull;</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a>&bull;6</a>",
				"&amp;&gt;<s>&#8226;&#x2022;<a>&bull;6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_6_B4_5()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a><b>&bull;</b>6</a>",
				"&amp;&gt;<s>&#8226;&#x2022;<a><b>&bull;</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a><b>&bull;</b><c>6</c></a>",
				"&amp;&gt;<s>&#8226;&#x2022;<a><b>&bull;</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_6_B4_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a><b>&bull;6</b></a>",
				"&amp;&gt;<s>&#8226;&#x2022;<a><b>&bull;6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A5_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;<a>&bull;<b>6</b></a>",
				"&amp;&gt;<s>&#8226;&#x2022;<a>&bull;<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A6_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;&bull;<a>6</a>",
				"&amp;&gt;<s>&#8226;&#x2022;&bull;<a>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Entity Patterns")]
		public void EntityPattern_S2_7_A6_6_B5_6()
		{
			TestExhaustive(
				2,
				7,
				"&amp;&gt;&#8226;&#x2022;&bull;<a><b>6</b></a>",
				"&amp;&gt;<s>&#8226;&#x2022;&bull;<a><b>6</b></a></s>");
		}

		#endregion
	}
}
