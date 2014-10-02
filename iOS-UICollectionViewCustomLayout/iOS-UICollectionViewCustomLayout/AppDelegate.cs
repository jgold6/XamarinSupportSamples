using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOSUICollectionViewCustomLayout
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
		// class-level declarations
		UIWindow window;
		UICollectionViewController cvc;
		CVLayout layout;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// 2 Column Layout
			layout = new CVLayout ();
			// Instantiate collection view controller with 2 column layout
			cvc = new iOS_UICollectionViewCustomLayoutViewController (layout);

			window.RootViewController = cvc;
			window.MakeKeyAndVisible ();

			return true;
		}
    }
}

