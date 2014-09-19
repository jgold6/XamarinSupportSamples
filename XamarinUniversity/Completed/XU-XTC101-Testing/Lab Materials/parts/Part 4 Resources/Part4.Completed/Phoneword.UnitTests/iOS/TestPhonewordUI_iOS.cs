using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Utils;
using Xamarin.UITest.iOS;
using System.Reflection;
using System.IO;

namespace Phoneword.UnitTests.iOSUI
{
	[TestFixture]
	public class TestPhonewordUIOniOS
	{
		iOSApp _app;

		[SetUp]
		public void SetUp()
		{
			_app = ConfigureApp.iOS.InstalledApp ("com.xamarin.university.phonewordxaml").StartApp();
		}

		[Test]
		public void TestTranslateNumberUserInterface ()
		{
			_app.EnterText (c => c.Class ("UITextField"), "1-855-XAMARIN");
			_app.Tap (c => c.Marked ("Translate"));

			bool hasTranslatedButton = _app.Query (c => c.Marked ("Call 1-855-9262746")).Any ();

			Assert.AreEqual (true, hasTranslatedButton, "The Call button is incorrectly labelled");
		}
	}
}

