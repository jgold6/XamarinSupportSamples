using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WebView {

	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {

		UIWindow window;
		UINavigationController navigationController;
		UIViewController viewController;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			viewController = new WebViewController();
			navigationController = new UINavigationController();
			window.RootViewController = navigationController;


			navigationController.PushViewController (viewController, false);
			// unnecessary, though it didn't seem to hurt. 
			// The View is added to the window when you pushed the viewController onto the navigationController. 
			//window.AddSubview (navigationController.View); 
			window.MakeKeyAndVisible ();
			return true;
		}
	}
}

