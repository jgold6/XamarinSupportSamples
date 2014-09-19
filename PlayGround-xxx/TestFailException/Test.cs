using NUnit.Framework;
using System;

namespace TestTest
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase()
		{
			Assert.IsTrue(true, "OK");

			//Assert.IsTrue(false, "Witch me throw an exception after the fact rather than just fail");
		}

		[Test()]
		public void TestCase2()
		{
			//Assert.IsTrue(true, "OK");

			Assert.IsTrue("x" == "x", "Witch me throw an exception after the fact rather than just fail");
		}
	}
}

