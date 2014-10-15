using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using System.Linq;

namespace TestDroidScreenShotCrash.Test
{
	[TestFixture]
    public class DroidTestFixture
    {
		AndroidApp app;


		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp
				.Android
				.ApiKey("25af8df4cf31c0afc9945504b9df704b")
				.ApkFile("TestDroidScreenShotCrash.TestDroidScreenShotCrash-Signed.apk")
				//.DeviceSerial("c0808c0070c1b21") //  c0808c0070c1b21   10.71.34.101:5555
				.StartApp();
		}

		[Test]
		public void SwipeToCaptureScreenShotTest()
		{

			app.WaitForElement(c => c.All());
			app.Back();

			// My Samsung device - needed internet permissions
			app.TapCoordinates(300,200);
			app.WaitForElement(c => c.All());
			app.EnterText("Hello Woild!");
			app.TapCoordinates(300,225);

			app.WaitForElement(c => c.All());

			// Only works from Repl command line, saves to Mac hard drive user folder
			app.Screenshot("testSnapshot");

			// Xam Adnroid Player
//			app.TapCoordinates(384, 400);
//			app.WaitForElement(c => c.All());
//			app.EnterText("Hello");
//			app.TapCoordinates(384,424);


			//app.Repl();

			//app.TapCoordinates(200, 200);
			//app.PressMenu();
			//app.Screenshot("testscreenshot");
			//app.Repl();
		}
    }
}

