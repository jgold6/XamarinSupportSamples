using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;

namespace XFormsUnivShared.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			MyViewController vc = new MyViewController();
			UINavigationController nc = new UINavigationController(vc);

			window.RootViewController = nc;
			window.MakeKeyAndVisible();
			
			return true;
		}
	}
}

