using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

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
            app.Print.Visible();
        }
    }
}
