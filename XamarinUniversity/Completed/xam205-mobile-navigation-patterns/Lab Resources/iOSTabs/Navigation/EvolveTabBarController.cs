using System;
using MonoTouch.UIKit;

namespace com.xamarin.university.mobilenav.ios.tabs
{
	public class EvolveTabBarController : UITabBarController
	{
		public EvolveTabBarController ()
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Create all the view controllers to be hosted in the tabs.
			var vc1 = new UINavigationController (new SessionsViewController ());
			// Customize how this controller is represented when in a tab.
			vc1.TabBarItem = new UITabBarItem ("Sessions", UIImage.FromBundle ("images/tabsession"), 0);
			var vc2 = new UINavigationController (new SpeakersViewController ());
			vc2.TabBarItem = new UITabBarItem ("Speakers", UIImage.FromBundle ("images/tabspeaker"), 1);
			var vc3 = new AboutViewController ();
			vc3.TabBarItem = new UITabBarItem ("About", UIImage.FromBundle ("images/tababout"), 2);
			var vc4 = new AboutViewController ();
			vc4.TabBarItem = new UITabBarItem ("About", UIImage.FromBundle ("images/tababout"), 3);
			var vc5 = new AboutViewController ();
			vc5.TabBarItem = new UITabBarItem ("About", UIImage.FromBundle ("images/tababout"), 4);
			var vc6 = new AboutViewController ();
			vc6.TabBarItem = new UITabBarItem ("About", UIImage.FromBundle ("images/tababout"), 5);

			// Set up the tab order.
			ViewControllers = new UIViewController[] { vc1, vc2, vc3, vc4, vc5, vc6 };
			// Select the first tab.
			SelectedIndex = 0;

			// Here is how you can add a red count badge to a tab's icon.
			vc5.TabBarItem.BadgeValue = "4";

			//CustomizableViewControllers = new UIViewController[]{ };
		}
	}
}

