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
		UINavigationController navigationController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// TODO: Step 6a: see how the NavigationController is used

			// Create a UINavigationController to be the 'root' of our app
			navigationController = new UINavigationController ();
			// Push our first table as the first view that's shown
			navigationController.PushViewController (new MenuTableViewController (), false);

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			// Set  evolveNavigationController as the 'root' view controller of our UINavigationController
			window.RootViewController = navigationController; 
			return true;
		}
	}
}