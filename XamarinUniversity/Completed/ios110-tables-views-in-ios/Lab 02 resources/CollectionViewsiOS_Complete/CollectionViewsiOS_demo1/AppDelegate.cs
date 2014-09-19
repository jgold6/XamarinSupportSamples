using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CollectionViewDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		UICollectionViewFlowLayout layout;
	
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);


			// TODO: Step 1a: create and initialize a UICollectionViewFlowLayout
			layout = new UICollectionViewFlowLayout () {
				SectionInset = new UIEdgeInsets (20, 5, 10, 5),
				MinimumInteritemSpacing = 5,
				MinimumLineSpacing = 5,
				ItemSize = new System.Drawing.SizeF (100, 100)
			};

			// create a CollectionViewController (which is a UICollectionViewController) with a layout
			window.RootViewController = new CollectionViewController (layout);

			window.MakeKeyAndVisible ();

			return true;
		}
	}
}