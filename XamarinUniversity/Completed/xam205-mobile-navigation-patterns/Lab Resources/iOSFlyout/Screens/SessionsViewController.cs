using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.ios.flyout
{
	public class SessionsViewController : EvolveFlyoutTableViewControllerBase
	{
		List<Session> sessions;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Title = "Sessions";

			TableView = new UITableView (Rectangle.Empty, UITableViewStyle.Plain); // Grouped or Plain
			TableView.BackgroundView = new UIImageView (UIImage.FromBundle ("images/Background"));

			sessions = EvolveData.SessionData;
			TableView.Source = new SessionsTableSource (sessions, this);
		}
	}
}