using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;

namespace UITestTraining
{
    [TestFixture]
    public class MyFirstiOSTestFixture
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .iOS
                .AppBundleZip("WhatCanISpendiOS.app.zip")
                .StartApp();
        }

        [Test]
        public void MyFirstiOSTest()
        {
            app.Print.Visible();
        }
    }
}