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
	public class SimpleEndSelectionExhaustiveTests: ExhaustiveSelectionTests
	{
		#region Methods

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A0_0()
		{
			TestExhaustive(2, 7, "123456", "12<s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1()
		{
			TestExhaustive(2, 7, "<a>1</a>23456", "<a>1</a>2<s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B0_1()
		{
			TestExhaustive(2, 7, "<a><b>1</b></a>23456", "<a><b>1</b></a>2<s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B1_2()
		{
			TestExhaustive(2, 7, "<a>1</a><b>2</b>3456", "<a>1</a><b>2</b><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B1_3()
		{
			TestExhaustive(
				2, 7, "<a>1</a><b>23</b>456", "<a>1</a><b>2</b><s><b>3</b>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B1_4()
		{
			TestExhaustive(
				2, 7, "<a>1</a><b>234</b>56", "<a>1</a><b>2</b><s><b>34</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B1_5()
		{
			TestExhaustive(
				2, 7, "<a>1</a><b>2345</b>6", "<a>1</a><b>2</b><s><b>345</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B1_6()
		{
			TestExhaustive(
				2, 7, "<a>1</a><b>23456</b>", "<a>1</a><b>2</b><s><b>3456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B2_3()
		{
			TestExhaustive(2, 7, "<a>1</a>2<b>3</b>456", "<a>1</a>2<s><b>3</b>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B2_4()
		{
			TestExhaustive(2, 7, "<a>1</a>2<b>34</b>56", "<a>1</a>2<s><b>34</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B2_5()
		{
			TestExhaustive(2, 7, "<a>1</a>2<b>345</b>6", "<a>1</a>2<s><b>345</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B2_6()
		{
			TestExhaustive(2, 7, "<a>1</a>2<b>3456</b>", "<a>1</a>2<s><b>3456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B3_4()
		{
			TestExhaustive(2, 7, "<a>1</a>23<b>4</b>56", "<a>1</a>2<s>3<b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B3_5()
		{
			TestExhaustive(2, 7, "<a>1</a>23<b>45</b>6", "<a>1</a>2<s>3<b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B3_6()
		{
			TestExhaustive(2, 7, "<a>1</a>23<b>456</b>", "<a>1</a>2<s>3<b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B4_5()
		{
			TestExhaustive(2, 7, "<a>1</a>234<b>5</b>6", "<a>1</a>2<s>34<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B4_6()
		{
			TestExhaustive(2, 7, "<a>1</a>234<b>56</b>", "<a>1</a>2<s>34<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_1_B5_6()
		{
			TestExhaustive(2, 7, "<a>1</a>2345<b>6</b>", "<a>1</a>2<s>345<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2()
		{
			TestExhaustive(2, 7, "<a>12</a>3456", "<a>12</a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B0_1()
		{
			TestExhaustive(2, 7, "<a><b>1</b>2</a>3456", "<a><b>1</b>2</a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B0_1_C1_2()
		{
			TestExhaustive(
				2, 7, "<a><b>1</b><c>2</c></a>3456", "<a><b>1</b><c>2</c></a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B0_2()
		{
			TestExhaustive(2, 7, "<a><b>12</b></a>3456", "<a><b>12</b></a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B1_2()
		{
			TestExhaustive(2, 7, "<a>1<b>2</b></a>3456", "<a>1<b>2</b></a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B2_3()
		{
			TestExhaustive(2, 7, "<a>12</a><b>3</b>456", "<a>12</a><s><b>3</b>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B2_4()
		{
			TestExhaustive(2, 7, "<a>12</a><b>34</b>56", "<a>12</a><s><b>34</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B2_5()
		{
			TestExhaustive(2, 7, "<a>12</a><b>345</b>6", "<a>12</a><s><b>345</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B2_6()
		{
			TestExhaustive(2, 7, "<a>12</a><b>3456</b>", "<a>12</a><s><b>3456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B3_4()
		{
			TestExhaustive(2, 7, "<a>12</a>3<b>4</b>56", "<a>12</a><s>3<b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B3_5()
		{
			TestExhaustive(2, 7, "<a>12</a>3<b>45</b>6", "<a>12</a><s>3<b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B3_6()
		{
			TestExhaustive(2, 7, "<a>12</a>3<b>456</b>", "<a>12</a><s>3<b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B4_5()
		{
			TestExhaustive(2, 7, "<a>12</a>34<b>5</b>6", "<a>12</a><s>34<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B4_6()
		{
			TestExhaustive(2, 7, "<a>12</a>34<b>56</b>", "<a>12</a><s>34<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_2_B5_6()
		{
			TestExhaustive(2, 7, "<a>12</a>345<b>6</b>", "<a>12</a><s>345<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3()
		{
			TestExhaustive(2, 7, "<a>123</a>456", "<a>12</a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_1()
		{
			TestExhaustive(
				2, 7, "<a><b>1</b>23</a>456", "<a><b>1</b>2</a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2</c>3</a>456",
				"<a><b>1</b><c>2</c></a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>23</c></a>456",
				"<a><b>1</b><c>2</c></a><s><a><c>3</c></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>3</c></a>456",
				"<a><b>1</b>2</a><s><a><c>3</c></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_2()
		{
			TestExhaustive(
				2, 7, "<a><b>12</b>3</a>456", "<a><b>12</b></a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>3</c></a>456",
				"<a><b>12</b></a><s><a><c>3</c></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B0_3()
		{
			TestExhaustive(
				2, 7, "<a><b>123</b></a>456", "<a><b>12</b></a><s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B1_2()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2</b>3</a>456", "<a>1<b>2</b></a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>3</c></a>456",
				"<a>1<b>2</b></a><s><a><c>3</c></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B1_3()
		{
			TestExhaustive(
				2, 7, "<a>1<b>23</b></a>456", "<a>1<b>2</b></a><s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B2_3()
		{
			TestExhaustive(
				2, 7, "<a>12<b>3</b></a>456", "<a>12</a><s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B3_4()
		{
			TestExhaustive(
				2, 7, "<a>123</a><b>4</b>56", "<a>12</a><s><a>3</a><b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B3_5()
		{
			TestExhaustive(
				2, 7, "<a>123</a><b>45</b>6", "<a>12</a><s><a>3</a><b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B3_6()
		{
			TestExhaustive(
				2, 7, "<a>123</a><b>456</b>", "<a>12</a><s><a>3</a><b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B4_5()
		{
			TestExhaustive(
				2, 7, "<a>123</a>4<b>5</b>6", "<a>12</a><s><a>3</a>4<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B4_6()
		{
			TestExhaustive(
				2, 7, "<a>123</a>4<b>56</b>", "<a>12</a><s><a>3</a>4<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_3_B5_6()
		{
			TestExhaustive(
				2, 7, "<a>123</a>45<b>6</b>", "<a>12</a><s><a>3</a>45<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4()
		{
			TestExhaustive(2, 7, "<a>1234</a>56", "<a>12</a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1()
		{
			TestExhaustive(
				2, 7, "<a><b>1</b>234</a>56", "<a><b>1</b>2</a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2</c>34</a>56",
				"<a><b>1</b><c>2</c></a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>23</c>4</a>56",
				"<a><b>1</b><c>2</c></a><s><a><c>3</c>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>234</c></a>56",
				"<a><b>1</b><c>2</c></a><s><a><c>34</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>3</c>4</a>56",
				"<a><b>1</b>2</a><s><a><c>3</c>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>34</c></a>56",
				"<a><b>1</b>2</a><s><a><c>34</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>4</c></a>56",
				"<a><b>1</b>2</a><s><a>3<c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_2()
		{
			TestExhaustive(
				2, 7, "<a><b>12</b>34</a>56", "<a><b>12</b></a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>3</c>4</a>56",
				"<a><b>12</b></a><s><a><c>3</c>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>34</c></a>56",
				"<a><b>12</b></a><s><a><c>34</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>4</c></a>56",
				"<a><b>12</b></a><s><a>3<c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_3()
		{
			TestExhaustive(
				2, 7, "<a><b>123</b>4</a>56", "<a><b>12</b></a><s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>4</c></a>56",
				"<a><b>12</b></a><s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B0_4()
		{
			TestExhaustive(
				2, 7, "<a><b>1234</b></a>56", "<a><b>12</b></a><s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_2()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2</b>34</a>56", "<a>1<b>2</b></a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>3</c>4</a>56",
				"<a>1<b>2</b></a><s><a><c>3</c>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>34</c></a>56",
				"<a>1<b>2</b></a><s><a><c>34</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>4</c></a>56",
				"<a>1<b>2</b></a><s><a>3<c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_3()
		{
			TestExhaustive(
				2, 7, "<a>1<b>23</b>4</a>56", "<a>1<b>2</b></a><s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>4</c></a>56",
				"<a>1<b>2</b></a><s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B1_4()
		{
			TestExhaustive(
				2, 7, "<a>1<b>234</b></a>56", "<a>1<b>2</b></a><s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B2_3()
		{
			TestExhaustive(
				2, 7, "<a>12<b>3</b>4</a>56", "<a>12</a><s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>4</c></a>56",
				"<a>12</a><s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B2_4()
		{
			TestExhaustive(
				2, 7, "<a>12<b>34</b></a>56", "<a>12</a><s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B3_4()
		{
			TestExhaustive(
				2, 7, "<a>123<b>4</b></a>56", "<a>12</a><s><a>3<b>4</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B4_5()
		{
			TestExhaustive(
				2, 7, "<a>1234</a><b>5</b>6", "<a>12</a><s><a>34</a><b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B4_6()
		{
			TestExhaustive(
				2, 7, "<a>1234</a><b>56</b>", "<a>12</a><s><a>34</a><b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_4_B5_6()
		{
			TestExhaustive(
				2, 7, "<a>1234</a>5<b>6</b>", "<a>12</a><s><a>34</a>5<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5()
		{
			TestExhaustive(2, 7, "<a>12345</a>6", "<a>12</a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1()
		{
			TestExhaustive(
				2, 7, "<a><b>1</b>2345</a>6", "<a><b>1</b>2</a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2</c>345</a>6",
				"<a><b>1</b><c>2</c></a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>23</c>45</a>6",
				"<a><b>1</b><c>2</c></a><s><a><c>3</c>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>234</c>5</a>6",
				"<a><b>1</b><c>2</c></a><s><a><c>34</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2345</c></a>6",
				"<a><b>1</b><c>2</c></a><s><a><c>345</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>3</c>45</a>6",
				"<a><b>1</b>2</a><s><a><c>3</c>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>34</c>5</a>6",
				"<a><b>1</b>2</a><s><a><c>34</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>345</c></a>6",
				"<a><b>1</b>2</a><s><a><c>345</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>4</c>5</a>6",
				"<a><b>1</b>2</a><s><a>3<c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>45</c></a>6",
				"<a><b>1</b>2</a><s><a>3<c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_1_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>234<c>5</c></a>6",
				"<a><b>1</b>2</a><s><a>34<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2()
		{
			TestExhaustive(
				2, 7, "<a><b>12</b>345</a>6", "<a><b>12</b></a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>3</c>45</a>6",
				"<a><b>12</b></a><s><a><c>3</c>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>34</c>5</a>6",
				"<a><b>12</b></a><s><a><c>34</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>345</c></a>6",
				"<a><b>12</b></a><s><a><c>345</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>4</c>5</a>6",
				"<a><b>12</b></a><s><a>3<c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>45</c></a>6",
				"<a><b>12</b></a><s><a>3<c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>34<c>5</c></a>6",
				"<a><b>12</b></a><s><a>34<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_3()
		{
			TestExhaustive(
				2, 7, "<a><b>123</b>45</a>6", "<a><b>12</b></a><s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>4</c>5</a>6",
				"<a><b>12</b></a><s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>45</c></a>6",
				"<a><b>12</b></a><s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b>4<c>5</c></a>6",
				"<a><b>12</b></a><s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_4()
		{
			TestExhaustive(
				2, 7, "<a><b>1234</b>5</a>6", "<a><b>12</b></a><s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1234</b><c>5</c></a>6",
				"<a><b>12</b></a><s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B0_5()
		{
			TestExhaustive(
				2, 7, "<a><b>12345</b></a>6", "<a><b>12</b></a><s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2</b>345</a>6", "<a>1<b>2</b></a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>3</c>45</a>6",
				"<a>1<b>2</b></a><s><a><c>3</c>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>34</c>5</a>6",
				"<a>1<b>2</b></a><s><a><c>34</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>345</c></a>6",
				"<a>1<b>2</b></a><s><a><c>345</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>4</c>5</a>6",
				"<a>1<b>2</b></a><s><a>3<c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>45</c></a>6",
				"<a>1<b>2</b></a><s><a>3<c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>34<c>5</c></a>6",
				"<a>1<b>2</b></a><s><a>34<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_3()
		{
			TestExhaustive(
				2, 7, "<a>1<b>23</b>45</a>6", "<a>1<b>2</b></a><s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>4</c>5</a>6",
				"<a>1<b>2</b></a><s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>45</c></a>6",
				"<a>1<b>2</b></a><s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b>4<c>5</c></a>6",
				"<a>1<b>2</b></a><s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_4()
		{
			TestExhaustive(
				2, 7, "<a>1<b>234</b>5</a>6", "<a>1<b>2</b></a><s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>234</b><c>5</c></a>6",
				"<a>1<b>2</b></a><s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B1_5()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2345</b></a>6", "<a>1<b>2</b></a><s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_3()
		{
			TestExhaustive(
				2, 7, "<a>12<b>3</b>45</a>6", "<a>12</a><s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>4</c>5</a>6",
				"<a>12</a><s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>45</c></a>6",
				"<a>12</a><s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b>4<c>5</c></a>6",
				"<a>12</a><s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_4()
		{
			TestExhaustive(
				2, 7, "<a>12<b>34</b>5</a>6", "<a>12</a><s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>34</b><c>5</c></a>6",
				"<a>12</a><s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B2_5()
		{
			TestExhaustive(
				2, 7, "<a>12<b>345</b></a>6", "<a>12</a><s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B3_4()
		{
			TestExhaustive(
				2, 7, "<a>123<b>4</b>5</a>6", "<a>12</a><s><a>3<b>4</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>123<b>4</b><c>5</c></a>6",
				"<a>12</a><s><a>3<b>4</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B3_5()
		{
			TestExhaustive(
				2, 7, "<a>123<b>45</b></a>6", "<a>12</a><s><a>3<b>45</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B4_5()
		{
			TestExhaustive(
				2, 7, "<a>1234<b>5</b></a>6", "<a>12</a><s><a>34<b>5</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_5_B5_6()
		{
			TestExhaustive(
				2, 7, "<a>12345</a><b>6</b>", "<a>12</a><s><a>345</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6()
		{
			TestExhaustive(2, 7, "<a>123456</a>", "<a>12</a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1()
		{
			TestExhaustive(
				2, 7, "<a><b>1</b>23456</a>", "<a><b>1</b>2</a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C1_2()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2</c>3456</a>",
				"<a><b>1</b><c>2</c></a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C1_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>23</c>456</a>",
				"<a><b>1</b><c>2</c></a><s><a><c>3</c>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C1_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>234</c>56</a>",
				"<a><b>1</b><c>2</c></a><s><a><c>34</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C1_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>2345</c>6</a>",
				"<a><b>1</b><c>2</c></a><s><a><c>345</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C1_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b><c>23456</c></a>",
				"<a><b>1</b><c>2</c></a><s><a><c>3456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>3</c>456</a>",
				"<a><b>1</b>2</a><s><a><c>3</c>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>34</c>56</a>",
				"<a><b>1</b>2</a><s><a><c>34</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>345</c>6</a>",
				"<a><b>1</b>2</a><s><a><c>345</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2<c>3456</c></a>",
				"<a><b>1</b>2</a><s><a><c>3456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>4</c>56</a>",
				"<a><b>1</b>2</a><s><a>3<c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>45</c>6</a>",
				"<a><b>1</b>2</a><s><a>3<c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>23<c>456</c></a>",
				"<a><b>1</b>2</a><s><a>3<c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>234<c>5</c>6</a>",
				"<a><b>1</b>2</a><s><a>34<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>234<c>56</c></a>",
				"<a><b>1</b>2</a><s><a>34<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_1_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1</b>2345<c>6</c></a>",
				"<a><b>1</b>2</a><s><a>345<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2()
		{
			TestExhaustive(
				2, 7, "<a><b>12</b>3456</a>", "<a><b>12</b></a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>3</c>456</a>",
				"<a><b>12</b></a><s><a><c>3</c>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>34</c>56</a>",
				"<a><b>12</b></a><s><a><c>34</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>345</c>6</a>",
				"<a><b>12</b></a><s><a><c>345</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b><c>3456</c></a>",
				"<a><b>12</b></a><s><a><c>3456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>4</c>56</a>",
				"<a><b>12</b></a><s><a>3<c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>45</c>6</a>",
				"<a><b>12</b></a><s><a>3<c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>3<c>456</c></a>",
				"<a><b>12</b></a><s><a>3<c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>34<c>5</c>6</a>",
				"<a><b>12</b></a><s><a>34<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>34<c>56</c></a>",
				"<a><b>12</b></a><s><a>34<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12</b>345<c>6</c></a>",
				"<a><b>12</b></a><s><a>345<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3()
		{
			TestExhaustive(
				2, 7, "<a><b>123</b>456</a>", "<a><b>12</b></a><s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>4</c>56</a>",
				"<a><b>12</b></a><s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>45</c>6</a>",
				"<a><b>12</b></a><s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b><c>456</c></a>",
				"<a><b>12</b></a><s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b>4<c>5</c>6</a>",
				"<a><b>12</b></a><s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b>4<c>56</c></a>",
				"<a><b>12</b></a><s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>123</b>45<c>6</c></a>",
				"<a><b>12</b></a><s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_4()
		{
			TestExhaustive(
				2, 7, "<a><b>1234</b>56</a>", "<a><b>12</b></a><s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1234</b><c>5</c>6</a>",
				"<a><b>12</b></a><s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1234</b><c>56</c></a>",
				"<a><b>12</b></a><s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>1234</b>5<c>6</c></a>",
				"<a><b>12</b></a><s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_5()
		{
			TestExhaustive(
				2, 7, "<a><b>12345</b>6</a>", "<a><b>12</b></a><s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a><b>12345</b><c>6</c></a>",
				"<a><b>12</b></a><s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B0_6()
		{
			TestExhaustive(
				2, 7, "<a><b>123456</b></a>", "<a><b>12</b></a><s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2</b>3456</a>", "<a>1<b>2</b></a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>3</c>456</a>",
				"<a>1<b>2</b></a><s><a><c>3</c>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>34</c>56</a>",
				"<a>1<b>2</b></a><s><a><c>34</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>345</c>6</a>",
				"<a>1<b>2</b></a><s><a><c>345</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b><c>3456</c></a>",
				"<a>1<b>2</b></a><s><a><c>3456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>4</c>56</a>",
				"<a>1<b>2</b></a><s><a>3<c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>45</c>6</a>",
				"<a>1<b>2</b></a><s><a>3<c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>3<c>456</c></a>",
				"<a>1<b>2</b></a><s><a>3<c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>34<c>5</c>6</a>",
				"<a>1<b>2</b></a><s><a>34<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>34<c>56</c></a>",
				"<a>1<b>2</b></a><s><a>34<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2</b>345<c>6</c></a>",
				"<a>1<b>2</b></a><s><a>345<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3()
		{
			TestExhaustive(
				2, 7, "<a>1<b>23</b>456</a>", "<a>1<b>2</b></a><s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>4</c>56</a>",
				"<a>1<b>2</b></a><s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>45</c>6</a>",
				"<a>1<b>2</b></a><s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b><c>456</c></a>",
				"<a>1<b>2</b></a><s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b>4<c>5</c>6</a>",
				"<a>1<b>2</b></a><s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b>4<c>56</c></a>",
				"<a>1<b>2</b></a><s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>23</b>45<c>6</c></a>",
				"<a>1<b>2</b></a><s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_4()
		{
			TestExhaustive(
				2, 7, "<a>1<b>234</b>56</a>", "<a>1<b>2</b></a><s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>234</b><c>5</c>6</a>",
				"<a>1<b>2</b></a><s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>234</b><c>56</c></a>",
				"<a>1<b>2</b></a><s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>234</b>5<c>6</c></a>",
				"<a>1<b>2</b></a><s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_5()
		{
			TestExhaustive(
				2, 7, "<a>1<b>2345</b>6</a>", "<a>1<b>2</b></a><s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1<b>2345</b><c>6</c></a>",
				"<a>1<b>2</b></a><s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B1_6()
		{
			TestExhaustive(
				2, 7, "<a>1<b>23456</b></a>", "<a>1<b>2</b></a><s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3()
		{
			TestExhaustive(
				2, 7, "<a>12<b>3</b>456</a>", "<a>12</a><s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>4</c>56</a>",
				"<a>12</a><s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>45</c>6</a>",
				"<a>12</a><s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b><c>456</c></a>",
				"<a>12</a><s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b>4<c>5</c>6</a>",
				"<a>12</a><s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b>4<c>56</c></a>",
				"<a>12</a><s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>3</b>45<c>6</c></a>",
				"<a>12</a><s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_4()
		{
			TestExhaustive(
				2, 7, "<a>12<b>34</b>56</a>", "<a>12</a><s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>34</b><c>5</c>6</a>",
				"<a>12</a><s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>34</b><c>56</c></a>",
				"<a>12</a><s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>34</b>5<c>6</c></a>",
				"<a>12</a><s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_5()
		{
			TestExhaustive(
				2, 7, "<a>12<b>345</b>6</a>", "<a>12</a><s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>12<b>345</b><c>6</c></a>",
				"<a>12</a><s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B2_6()
		{
			TestExhaustive(
				2, 7, "<a>12<b>3456</b></a>", "<a>12</a><s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_4()
		{
			TestExhaustive(
				2, 7, "<a>123<b>4</b>56</a>", "<a>12</a><s><a>3<b>4</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"<a>123<b>4</b><c>5</c>6</a>",
				"<a>12</a><s><a>3<b>4</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>123<b>4</b><c>56</c></a>",
				"<a>12</a><s><a>3<b>4</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>123<b>4</b>5<c>6</c></a>",
				"<a>12</a><s><a>3<b>4</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_5()
		{
			TestExhaustive(
				2, 7, "<a>123<b>45</b>6</a>", "<a>12</a><s><a>3<b>45</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>123<b>45</b><c>6</c></a>",
				"<a>12</a><s><a>3<b>45</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B3_6()
		{
			TestExhaustive(
				2, 7, "<a>123<b>456</b></a>", "<a>12</a><s><a>3<b>456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B4_5()
		{
			TestExhaustive(
				2, 7, "<a>1234<b>5</b>6</a>", "<a>12</a><s><a>34<b>5</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"<a>1234<b>5</b><c>6</c></a>",
				"<a>12</a><s><a>34<b>5</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B4_6()
		{
			TestExhaustive(
				2, 7, "<a>1234<b>56</b></a>", "<a>12</a><s><a>34<b>56</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A1_6_B5_6()
		{
			TestExhaustive(
				2, 7, "<a>12345<b>6</b></a>", "<a>12</a><s><a>345<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2()
		{
			TestExhaustive(2, 7, "1<a>2</a>3456", "1<a>2</a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B1_2()
		{
			TestExhaustive(2, 7, "1<a><b>2</b></a>3456", "1<a><b>2</b></a><s>3456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B2_3()
		{
			TestExhaustive(2, 7, "1<a>2</a><b>3</b>456", "1<a>2</a><s><b>3</b>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B2_4()
		{
			TestExhaustive(2, 7, "1<a>2</a><b>34</b>56", "1<a>2</a><s><b>34</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B2_5()
		{
			TestExhaustive(2, 7, "1<a>2</a><b>345</b>6", "1<a>2</a><s><b>345</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B2_6()
		{
			TestExhaustive(2, 7, "1<a>2</a><b>3456</b>", "1<a>2</a><s><b>3456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B3_4()
		{
			TestExhaustive(2, 7, "1<a>2</a>3<b>4</b>56", "1<a>2</a><s>3<b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B3_5()
		{
			TestExhaustive(2, 7, "1<a>2</a>3<b>45</b>6", "1<a>2</a><s>3<b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B3_6()
		{
			TestExhaustive(2, 7, "1<a>2</a>3<b>456</b>", "1<a>2</a><s>3<b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B4_5()
		{
			TestExhaustive(2, 7, "1<a>2</a>34<b>5</b>6", "1<a>2</a><s>34<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B4_6()
		{
			TestExhaustive(2, 7, "1<a>2</a>34<b>56</b>", "1<a>2</a><s>34<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_2_B5_6()
		{
			TestExhaustive(2, 7, "1<a>2</a>345<b>6</b>", "1<a>2</a><s>345<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3()
		{
			TestExhaustive(2, 7, "1<a>23</a>456", "1<a>2</a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B1_2()
		{
			TestExhaustive(
				2, 7, "1<a><b>2</b>3</a>456", "1<a><b>2</b></a><s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>3</c></a>456",
				"1<a><b>2</b></a><s><a><c>3</c></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B1_3()
		{
			TestExhaustive(
				2, 7, "1<a><b>23</b></a>456", "1<a><b>2</b></a><s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B2_3()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>3</b></a>456", "1<a>2</a><s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B3_4()
		{
			TestExhaustive(
				2, 7, "1<a>23</a><b>4</b>56", "1<a>2</a><s><a>3</a><b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B3_5()
		{
			TestExhaustive(
				2, 7, "1<a>23</a><b>45</b>6", "1<a>2</a><s><a>3</a><b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B3_6()
		{
			TestExhaustive(
				2, 7, "1<a>23</a><b>456</b>", "1<a>2</a><s><a>3</a><b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B4_5()
		{
			TestExhaustive(
				2, 7, "1<a>23</a>4<b>5</b>6", "1<a>2</a><s><a>3</a>4<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B4_6()
		{
			TestExhaustive(
				2, 7, "1<a>23</a>4<b>56</b>", "1<a>2</a><s><a>3</a>4<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_3_B5_6()
		{
			TestExhaustive(
				2, 7, "1<a>23</a>45<b>6</b>", "1<a>2</a><s><a>3</a>45<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4()
		{
			TestExhaustive(2, 7, "1<a>234</a>56", "1<a>2</a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_2()
		{
			TestExhaustive(
				2, 7, "1<a><b>2</b>34</a>56", "1<a><b>2</b></a><s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>3</c>4</a>56",
				"1<a><b>2</b></a><s><a><c>3</c>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>34</c></a>56",
				"1<a><b>2</b></a><s><a><c>34</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>4</c></a>56",
				"1<a><b>2</b></a><s><a>3<c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_3()
		{
			TestExhaustive(
				2, 7, "1<a><b>23</b>4</a>56", "1<a><b>2</b></a><s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>4</c></a>56",
				"1<a><b>2</b></a><s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B1_4()
		{
			TestExhaustive(
				2, 7, "1<a><b>234</b></a>56", "1<a><b>2</b></a><s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B2_3()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>3</b>4</a>56", "1<a>2</a><s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>4</c></a>56",
				"1<a>2</a><s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B2_4()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>34</b></a>56", "1<a>2</a><s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B3_4()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>4</b></a>56", "1<a>2</a><s><a>3<b>4</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B4_5()
		{
			TestExhaustive(
				2, 7, "1<a>234</a><b>5</b>6", "1<a>2</a><s><a>34</a><b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B4_6()
		{
			TestExhaustive(
				2, 7, "1<a>234</a><b>56</b>", "1<a>2</a><s><a>34</a><b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_4_B5_6()
		{
			TestExhaustive(
				2, 7, "1<a>234</a>5<b>6</b>", "1<a>2</a><s><a>34</a>5<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5()
		{
			TestExhaustive(2, 7, "1<a>2345</a>6", "1<a>2</a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2()
		{
			TestExhaustive(
				2, 7, "1<a><b>2</b>345</a>6", "1<a><b>2</b></a><s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>3</c>45</a>6",
				"1<a><b>2</b></a><s><a><c>3</c>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>34</c>5</a>6",
				"1<a><b>2</b></a><s><a><c>34</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>345</c></a>6",
				"1<a><b>2</b></a><s><a><c>345</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>4</c>5</a>6",
				"1<a><b>2</b></a><s><a>3<c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>45</c></a>6",
				"1<a><b>2</b></a><s><a>3<c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>34<c>5</c></a>6",
				"1<a><b>2</b></a><s><a>34<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_3()
		{
			TestExhaustive(
				2, 7, "1<a><b>23</b>45</a>6", "1<a><b>2</b></a><s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>4</c>5</a>6",
				"1<a><b>2</b></a><s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>45</c></a>6",
				"1<a><b>2</b></a><s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b>4<c>5</c></a>6",
				"1<a><b>2</b></a><s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_4()
		{
			TestExhaustive(
				2, 7, "1<a><b>234</b>5</a>6", "1<a><b>2</b></a><s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>234</b><c>5</c></a>6",
				"1<a><b>2</b></a><s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B1_5()
		{
			TestExhaustive(
				2, 7, "1<a><b>2345</b></a>6", "1<a><b>2</b></a><s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_3()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>3</b>45</a>6", "1<a>2</a><s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>4</c>5</a>6",
				"1<a>2</a><s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>45</c></a>6",
				"1<a>2</a><s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b>4<c>5</c></a>6",
				"1<a>2</a><s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_4()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>34</b>5</a>6", "1<a>2</a><s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>34</b><c>5</c></a>6",
				"1<a>2</a><s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B2_5()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>345</b></a>6", "1<a>2</a><s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B3_4()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>4</b>5</a>6", "1<a>2</a><s><a>3<b>4</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>23<b>4</b><c>5</c></a>6",
				"1<a>2</a><s><a>3<b>4</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B3_5()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>45</b></a>6", "1<a>2</a><s><a>3<b>45</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B4_5()
		{
			TestExhaustive(
				2, 7, "1<a>234<b>5</b></a>6", "1<a>2</a><s><a>34<b>5</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_5_B5_6()
		{
			TestExhaustive(
				2, 7, "1<a>2345</a><b>6</b>", "1<a>2</a><s><a>345</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6()
		{
			TestExhaustive(2, 7, "1<a>23456</a>", "1<a>2</a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2()
		{
			TestExhaustive(
				2, 7, "1<a><b>2</b>3456</a>", "1<a><b>2</b></a><s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C2_3()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>3</c>456</a>",
				"1<a><b>2</b></a><s><a><c>3</c>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C2_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>34</c>56</a>",
				"1<a><b>2</b></a><s><a><c>34</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C2_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>345</c>6</a>",
				"1<a><b>2</b></a><s><a><c>345</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C2_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b><c>3456</c></a>",
				"1<a><b>2</b></a><s><a><c>3456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>4</c>56</a>",
				"1<a><b>2</b></a><s><a>3<c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>45</c>6</a>",
				"1<a><b>2</b></a><s><a>3<c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>3<c>456</c></a>",
				"1<a><b>2</b></a><s><a>3<c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>34<c>5</c>6</a>",
				"1<a><b>2</b></a><s><a>34<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>34<c>56</c></a>",
				"1<a><b>2</b></a><s><a>34<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_2_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2</b>345<c>6</c></a>",
				"1<a><b>2</b></a><s><a>345<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3()
		{
			TestExhaustive(
				2, 7, "1<a><b>23</b>456</a>", "1<a><b>2</b></a><s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>4</c>56</a>",
				"1<a><b>2</b></a><s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>45</c>6</a>",
				"1<a><b>2</b></a><s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b><c>456</c></a>",
				"1<a><b>2</b></a><s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b>4<c>5</c>6</a>",
				"1<a><b>2</b></a><s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b>4<c>56</c></a>",
				"1<a><b>2</b></a><s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>23</b>45<c>6</c></a>",
				"1<a><b>2</b></a><s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_4()
		{
			TestExhaustive(
				2, 7, "1<a><b>234</b>56</a>", "1<a><b>2</b></a><s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>234</b><c>5</c>6</a>",
				"1<a><b>2</b></a><s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>234</b><c>56</c></a>",
				"1<a><b>2</b></a><s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>234</b>5<c>6</c></a>",
				"1<a><b>2</b></a><s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_5()
		{
			TestExhaustive(
				2, 7, "1<a><b>2345</b>6</a>", "1<a><b>2</b></a><s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a><b>2345</b><c>6</c></a>",
				"1<a><b>2</b></a><s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B1_6()
		{
			TestExhaustive(
				2, 7, "1<a><b>23456</b></a>", "1<a><b>2</b></a><s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>3</b>456</a>", "1<a>2</a><s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C3_4()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>4</c>56</a>",
				"1<a>2</a><s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C3_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>45</c>6</a>",
				"1<a>2</a><s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C3_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b><c>456</c></a>",
				"1<a>2</a><s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b>4<c>5</c>6</a>",
				"1<a>2</a><s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b>4<c>56</c></a>",
				"1<a>2</a><s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_3_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>3</b>45<c>6</c></a>",
				"1<a>2</a><s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_4()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>34</b>56</a>", "1<a>2</a><s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>34</b><c>5</c>6</a>",
				"1<a>2</a><s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>34</b><c>56</c></a>",
				"1<a>2</a><s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>34</b>5<c>6</c></a>",
				"1<a>2</a><s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_5()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>345</b>6</a>", "1<a>2</a><s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>2<b>345</b><c>6</c></a>",
				"1<a>2</a><s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B2_6()
		{
			TestExhaustive(
				2, 7, "1<a>2<b>3456</b></a>", "1<a>2</a><s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_4()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>4</b>56</a>", "1<a>2</a><s><a>3<b>4</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_4_C4_5()
		{
			TestExhaustive(
				2,
				7,
				"1<a>23<b>4</b><c>5</c>6</a>",
				"1<a>2</a><s><a>3<b>4</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_4_C4_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>23<b>4</b><c>56</c></a>",
				"1<a>2</a><s><a>3<b>4</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_4_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>23<b>4</b>5<c>6</c></a>",
				"1<a>2</a><s><a>3<b>4</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_5()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>45</b>6</a>", "1<a>2</a><s><a>3<b>45</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>23<b>45</b><c>6</c></a>",
				"1<a>2</a><s><a>3<b>45</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B3_6()
		{
			TestExhaustive(
				2, 7, "1<a>23<b>456</b></a>", "1<a>2</a><s><a>3<b>456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B4_5()
		{
			TestExhaustive(
				2, 7, "1<a>234<b>5</b>6</a>", "1<a>2</a><s><a>34<b>5</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B4_5_C5_6()
		{
			TestExhaustive(
				2,
				7,
				"1<a>234<b>5</b><c>6</c></a>",
				"1<a>2</a><s><a>34<b>5</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B4_6()
		{
			TestExhaustive(
				2, 7, "1<a>234<b>56</b></a>", "1<a>2</a><s><a>34<b>56</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A2_6_B5_6()
		{
			TestExhaustive(
				2, 7, "1<a>2345<b>6</b></a>", "1<a>2</a><s><a>345<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3()
		{
			TestExhaustive(2, 7, "12<a>3</a>456", "12<s><a>3</a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B2_3()
		{
			TestExhaustive(2, 7, "12<a><b>3</b></a>456", "12<s><a><b>3</b></a>456</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B3_4()
		{
			TestExhaustive(2, 7, "12<a>3</a><b>4</b>56", "12<s><a>3</a><b>4</b>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B3_5()
		{
			TestExhaustive(2, 7, "12<a>3</a><b>45</b>6", "12<s><a>3</a><b>45</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B3_6()
		{
			TestExhaustive(2, 7, "12<a>3</a><b>456</b>", "12<s><a>3</a><b>456</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B4_5()
		{
			TestExhaustive(2, 7, "12<a>3</a>4<b>5</b>6", "12<s><a>3</a>4<b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B4_6()
		{
			TestExhaustive(2, 7, "12<a>3</a>4<b>56</b>", "12<s><a>3</a>4<b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_3_B5_6()
		{
			TestExhaustive(2, 7, "12<a>3</a>45<b>6</b>", "12<s><a>3</a>45<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4()
		{
			TestExhaustive(2, 7, "12<a>34</a>56", "12<s><a>34</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B2_3()
		{
			TestExhaustive(2, 7, "12<a><b>3</b>4</a>56", "12<s><a><b>3</b>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B2_3_C3_4()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>4</c></a>56", "12<s><a><b>3</b><c>4</c></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B2_4()
		{
			TestExhaustive(2, 7, "12<a><b>34</b></a>56", "12<s><a><b>34</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B3_4()
		{
			TestExhaustive(2, 7, "12<a>3<b>4</b></a>56", "12<s><a>3<b>4</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B4_5()
		{
			TestExhaustive(2, 7, "12<a>34</a><b>5</b>6", "12<s><a>34</a><b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B4_6()
		{
			TestExhaustive(2, 7, "12<a>34</a><b>56</b>", "12<s><a>34</a><b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_4_B5_6()
		{
			TestExhaustive(2, 7, "12<a>34</a>5<b>6</b>", "12<s><a>34</a>5<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5()
		{
			TestExhaustive(2, 7, "12<a>345</a>6", "12<s><a>345</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_3()
		{
			TestExhaustive(2, 7, "12<a><b>3</b>45</a>6", "12<s><a><b>3</b>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_3_C3_4()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>4</c>5</a>6", "12<s><a><b>3</b><c>4</c>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_3_C3_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>45</c></a>6", "12<s><a><b>3</b><c>45</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_3_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b>4<c>5</c></a>6", "12<s><a><b>3</b>4<c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_4()
		{
			TestExhaustive(2, 7, "12<a><b>34</b>5</a>6", "12<s><a><b>34</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_4_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>34</b><c>5</c></a>6", "12<s><a><b>34</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B2_5()
		{
			TestExhaustive(2, 7, "12<a><b>345</b></a>6", "12<s><a><b>345</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B3_4()
		{
			TestExhaustive(2, 7, "12<a>3<b>4</b>5</a>6", "12<s><a>3<b>4</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B3_4_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a>3<b>4</b><c>5</c></a>6", "12<s><a>3<b>4</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B3_5()
		{
			TestExhaustive(2, 7, "12<a>3<b>45</b></a>6", "12<s><a>3<b>45</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B4_5()
		{
			TestExhaustive(2, 7, "12<a>34<b>5</b></a>6", "12<s><a>34<b>5</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_5_B5_6()
		{
			TestExhaustive(2, 7, "12<a>345</a><b>6</b>", "12<s><a>345</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6()
		{
			TestExhaustive(2, 7, "12<a>3456</a>", "12<s><a>3456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3()
		{
			TestExhaustive(2, 7, "12<a><b>3</b>456</a>", "12<s><a><b>3</b>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C3_4()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>4</c>56</a>", "12<s><a><b>3</b><c>4</c>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C3_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>45</c>6</a>", "12<s><a><b>3</b><c>45</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C3_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b><c>456</c></a>", "12<s><a><b>3</b><c>456</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b>4<c>5</c>6</a>", "12<s><a><b>3</b>4<c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C4_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b>4<c>56</c></a>", "12<s><a><b>3</b>4<c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_3_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>3</b>45<c>6</c></a>", "12<s><a><b>3</b>45<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_4()
		{
			TestExhaustive(2, 7, "12<a><b>34</b>56</a>", "12<s><a><b>34</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_4_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a><b>34</b><c>5</c>6</a>", "12<s><a><b>34</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_4_C4_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>34</b><c>56</c></a>", "12<s><a><b>34</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_4_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>34</b>5<c>6</c></a>", "12<s><a><b>34</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_5()
		{
			TestExhaustive(2, 7, "12<a><b>345</b>6</a>", "12<s><a><b>345</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_5_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a><b>345</b><c>6</c></a>", "12<s><a><b>345</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B2_6()
		{
			TestExhaustive(2, 7, "12<a><b>3456</b></a>", "12<s><a><b>3456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_4()
		{
			TestExhaustive(2, 7, "12<a>3<b>4</b>56</a>", "12<s><a>3<b>4</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_4_C4_5()
		{
			TestExhaustive(
				2, 7, "12<a>3<b>4</b><c>5</c>6</a>", "12<s><a>3<b>4</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_4_C4_6()
		{
			TestExhaustive(
				2, 7, "12<a>3<b>4</b><c>56</c></a>", "12<s><a>3<b>4</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_4_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a>3<b>4</b>5<c>6</c></a>", "12<s><a>3<b>4</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_5()
		{
			TestExhaustive(2, 7, "12<a>3<b>45</b>6</a>", "12<s><a>3<b>45</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_5_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a>3<b>45</b><c>6</c></a>", "12<s><a>3<b>45</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B3_6()
		{
			TestExhaustive(2, 7, "12<a>3<b>456</b></a>", "12<s><a>3<b>456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B4_5()
		{
			TestExhaustive(2, 7, "12<a>34<b>5</b>6</a>", "12<s><a>34<b>5</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B4_5_C5_6()
		{
			TestExhaustive(
				2, 7, "12<a>34<b>5</b><c>6</c></a>", "12<s><a>34<b>5</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B4_6()
		{
			TestExhaustive(2, 7, "12<a>34<b>56</b></a>", "12<s><a>34<b>56</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A3_6_B5_6()
		{
			TestExhaustive(2, 7, "12<a>345<b>6</b></a>", "12<s><a>345<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_4()
		{
			TestExhaustive(2, 7, "123<a>4</a>56", "12<s>3<a>4</a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_4_B3_4()
		{
			TestExhaustive(2, 7, "123<a><b>4</b></a>56", "12<s>3<a><b>4</b></a>56</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_4_B4_5()
		{
			TestExhaustive(2, 7, "123<a>4</a><b>5</b>6", "12<s>3<a>4</a><b>5</b>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_4_B4_6()
		{
			TestExhaustive(2, 7, "123<a>4</a><b>56</b>", "12<s>3<a>4</a><b>56</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_4_B5_6()
		{
			TestExhaustive(2, 7, "123<a>4</a>5<b>6</b>", "12<s>3<a>4</a>5<b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5()
		{
			TestExhaustive(2, 7, "123<a>45</a>6", "12<s>3<a>45</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5_B3_4()
		{
			TestExhaustive(2, 7, "123<a><b>4</b>5</a>6", "12<s>3<a><b>4</b>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5_B3_4_C4_5()
		{
			TestExhaustive(
				2, 7, "123<a><b>4</b><c>5</c></a>6", "12<s>3<a><b>4</b><c>5</c></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5_B3_5()
		{
			TestExhaustive(2, 7, "123<a><b>45</b></a>6", "12<s>3<a><b>45</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5_B4_5()
		{
			TestExhaustive(2, 7, "123<a>4<b>5</b></a>6", "12<s>3<a>4<b>5</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_5_B5_6()
		{
			TestExhaustive(2, 7, "123<a>45</a><b>6</b>", "12<s>3<a>45</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6()
		{
			TestExhaustive(2, 7, "123<a>456</a>", "12<s>3<a>456</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_4()
		{
			TestExhaustive(2, 7, "123<a><b>4</b>56</a>", "12<s>3<a><b>4</b>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_4_C4_5()
		{
			TestExhaustive(
				2, 7, "123<a><b>4</b><c>5</c>6</a>", "12<s>3<a><b>4</b><c>5</c>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_4_C4_6()
		{
			TestExhaustive(
				2, 7, "123<a><b>4</b><c>56</c></a>", "12<s>3<a><b>4</b><c>56</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_4_C5_6()
		{
			TestExhaustive(
				2, 7, "123<a><b>4</b>5<c>6</c></a>", "12<s>3<a><b>4</b>5<c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_5()
		{
			TestExhaustive(2, 7, "123<a><b>45</b>6</a>", "12<s>3<a><b>45</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_5_C5_6()
		{
			TestExhaustive(
				2, 7, "123<a><b>45</b><c>6</c></a>", "12<s>3<a><b>45</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B3_6()
		{
			TestExhaustive(2, 7, "123<a><b>456</b></a>", "12<s>3<a><b>456</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B4_5()
		{
			TestExhaustive(2, 7, "123<a>4<b>5</b>6</a>", "12<s>3<a>4<b>5</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B4_5_C5_6()
		{
			TestExhaustive(
				2, 7, "123<a>4<b>5</b><c>6</c></a>", "12<s>3<a>4<b>5</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B4_6()
		{
			TestExhaustive(2, 7, "123<a>4<b>56</b></a>", "12<s>3<a>4<b>56</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A4_6_B5_6()
		{
			TestExhaustive(2, 7, "123<a>45<b>6</b></a>", "12<s>3<a>45<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_5()
		{
			TestExhaustive(2, 7, "1234<a>5</a>6", "12<s>34<a>5</a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_5_B4_5()
		{
			TestExhaustive(2, 7, "1234<a><b>5</b></a>6", "12<s>34<a><b>5</b></a>6</s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_5_B5_6()
		{
			TestExhaustive(2, 7, "1234<a>5</a><b>6</b>", "12<s>34<a>5</a><b>6</b></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_6()
		{
			TestExhaustive(2, 7, "1234<a>56</a>", "12<s>34<a>56</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_6_B4_5()
		{
			TestExhaustive(2, 7, "1234<a><b>5</b>6</a>", "12<s>34<a><b>5</b>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_6_B4_5_C5_6()
		{
			TestExhaustive(
				2, 7, "1234<a><b>5</b><c>6</c></a>", "12<s>34<a><b>5</b><c>6</c></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_6_B4_6()
		{
			TestExhaustive(2, 7, "1234<a><b>56</b></a>", "12<s>34<a><b>56</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A5_6_B5_6()
		{
			TestExhaustive(2, 7, "1234<a>5<b>6</b></a>", "12<s>34<a>5<b>6</b></a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A6_6()
		{
			TestExhaustive(2, 7, "12345<a>6</a>", "12<s>345<a>6</a></s>");
		}

		/// <summary/>
		[Test]
		[Category("Simple Patterns")]
		public void SimplePattern_S2_7_A6_6_B5_6()
		{
			TestExhaustive(2, 7, "12345<a><b>6</b></a>", "12<s>345<a><b>6</b></a></s>");
		}

		#endregion
	}
}
