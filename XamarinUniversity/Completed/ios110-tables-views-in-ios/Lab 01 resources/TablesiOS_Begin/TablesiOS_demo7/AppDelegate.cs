using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo {

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
		UINavigationController evolveNavigationController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			evolveNavigationController = new UINavigationController ();
			evolveNavigationController.PushViewController (new FavoritesViewController (), false);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			window.RootViewController = evolveNavigationController;
			return true;
		}
	}
}