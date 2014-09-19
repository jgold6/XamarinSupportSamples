using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Demo1_AppLifecycle
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		AppLifecycleViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Console.WriteLine("FinishedLaunching called, App is launched.");
        	window = new UIWindow(UIScreen.MainScreen.Bounds);
        	
        	viewController = new AppLifecycleViewController();
        	window.RootViewController = viewController;
        	
        	window.MakeKeyAndVisible();
        	
        	return true;
        }

        public override void OnActivated(UIApplication application)
        {
        	Console.WriteLine("OnActivated called, App is active.");
        }

		// Only called after app is already launched
        public override void WillEnterForeground(UIApplication application)
        {
        	Console.WriteLine("App will enter foreground");
        }

        public override void OnResignActivation(UIApplication application)
        {
        	Console.WriteLine("OnResignActivation called, App moving to inactive state.");
        }

		public override void DidEnterBackground(UIApplication application)
        {
        	Console.WriteLine("App entering background state.");
//			while (true)
//			{
//				// Don't do this! 
//			}

        }

		public override void WillTerminate(UIApplication application)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			Console.WriteLine("App will terminate");
		}
	}
}

