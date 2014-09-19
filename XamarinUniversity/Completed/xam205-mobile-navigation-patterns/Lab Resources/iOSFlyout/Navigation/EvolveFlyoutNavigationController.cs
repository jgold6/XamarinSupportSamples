using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.Dialog;

// Subclass the component to keep the configuration in one place
using FlyoutNavigation;

namespace com.xamarin.university.mobilenav.ios.flyout
{
	public class EvolveFlyoutNavigationController : FlyoutNavigationController
	{
		public EvolveFlyoutNavigationController () : base ()
		{
			// Create the navigation menu
			NavigationRoot = new RootElement ("Navigation") {
				new Section () {
					new StyledStringElement ("Sessions")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.LightGray },
					new StyledStringElement ("Speakers")    { BackgroundColor = UIColor.Clear, TextColor = UIColor.LightGray },
					new StyledStringElement ("About Evolve"){ BackgroundColor = UIColor.Clear, TextColor = UIColor.LightGray },
				}
			};

			var vc1 = new UINavigationController (new SessionsViewController ());
			var vc2 = new UINavigationController (new SpeakersViewController ());
			var vc3 = new UINavigationController (new AboutViewController ());

			// Supply view controllers corresponding to menu items:
			ViewControllers = new UIViewController[] {
				vc1, vc2, vc3
			};

			NavigationTableView.BackgroundView = new UIImageView (UIImage.FromBundle ("images/Background-Party.png"));
			NavigationTableView.SeparatorColor = UIColor.DarkGray;
		}
	}
}