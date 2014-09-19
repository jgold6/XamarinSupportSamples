using System;
using NUnit.Framework;

namespace FormsPlayGround.Droid.UnitTest
{
    [TestFixture]
    public class TestsSample
    {
        
        [SetUp]
        public void Setup()
        {
        }

        
        [TearDown]
        public void Tear()
        {
        }

        [Test]
        public void Pass()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void Fail()
        {
			string test = "Success!";
//			FormsPlayground.Android.MainActivity ma = new FormsPlayground.Android.MainActivity();
//			var ret = ma.test();
			var ret = FormsPlayground.Android.MainActivity.test();
			Assert.True(test == ret);
//			Assert.True(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive("Inconclusive");
        }
    }
}

