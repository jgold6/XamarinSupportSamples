using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace com.xamarin.university.mobilenav.ios.flyout {

	public class Application {
		public static void Main (string[] args)
		{
			try {
				UIApplication.Main (args, null, "AppDelegate");
			} catch (Exception e) {
				Console.WriteLine (e.ToString ());
			}
		}
	}

	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		public static EvolveFlyoutNavigationController FlyoutNav;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// We create a FlyoutNavigationController to be the 'root' of our app
			FlyoutNav = new EvolveFlyoutNavigationController ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = FlyoutNav;
			return true;
		}
	}
}