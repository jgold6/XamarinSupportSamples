using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Lab2.GCAndMe
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		GCAndMeViewController viewController;

		public override void FinishedLaunching(UIApplication application)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);
			viewController = new GCAndMeViewController();
			window.RootViewController = viewController;
			window.MakeKeyAndVisible();
		}
	}
}

