using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using System.Linq;

namespace UITestTraining
{
    [TestFixture]
    public class MyFirstAndroidTestFixture
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .ApkFile("WhatCanISpend.Android.apk")
                .StartApp();
        }

        [Test]
        public void MyFirstAndroidTest()
        {


			app.Tap(c => c.Marked("Deposit"));
			//app.Print.Visible();
			//app.Print.Query(c => c.Marked("Deposit"));


			app.WaitForElement(c => c.Class("EditText"));

			app.EnterText(c => c.Class("EditText"), "100");

			app.Tap(c => c.Marked("Add to Balance"));

			//app.Print.Query(c => c.Class("EditText"));

			var count = app.Print.Query(c => c.Marked("$100.00")).Count();

			app.Repl();
			// in Repl: app.Query(c => c.Raw("*"));
			// Repl is C# front end to Calabash. Same commands as here.
			//app.WaitForElement(c => c.Marked("Amount"));

			//app.Print.Visible();
        }
    }
}
