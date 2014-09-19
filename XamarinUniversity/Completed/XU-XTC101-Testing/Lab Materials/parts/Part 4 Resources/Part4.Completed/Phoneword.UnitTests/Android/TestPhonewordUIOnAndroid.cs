using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;

namespace Phoneword.UnitTests.DroidUI
{
	[TestFixture]
	public class TestPhonewordUIOnAndroid
	{
		IApp _app;

		[SetUp]
		public void SetUp()
		{
			_app = ConfigureApp.iOS.InstalledApp ("com.xamarin.university.phonewordxaml").StartApp ();
		}

		[Test]
		public void TestTranslation ()
		{
			_app.EnterText (c => c.Class ("EditText"), "1-855-XAMARIN");
			_app.Tap (c => c.Marked ("Translate"));

			bool hasTranslatedButton = _app.Query (c => c.Marked ("Call 1-855-9262746")).Any ();

			Assert.AreEqual (true, hasTranslatedButton, "The Translate button did not work");
		}
	}
}
