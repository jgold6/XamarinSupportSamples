using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo {
	public class SessionsViewController : UITableViewController {
		List<Session> sessions;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView = new UITableView (Rectangle.Empty, UITableViewStyle.Plain); // Grouped or Plain
			TableView.BackgroundView = new UIImageView (UIImage.FromBundle ("images/Background"));

			sessions = PopulateSessionData ();
			TableView.Source = new SessionsTableSource (sessions);
		}

		// Adjust for overlap of first row by status bar for for iOS 7
		public override void ViewDidLayoutSubviews ()
		{
			base.ViewDidLayoutSubviews ();

			TableView.ContentInset = new UIEdgeInsets (this.TopLayoutGuide.Length, 0, 0, 0);
		}

		/// <summary>
		/// Helper method to populate our session data, 
		/// </summary>
		protected List<Session> PopulateSessionData()
		{
			return new List<Session> () {
				new Session {Title="Introduction to Mobile Development",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,9,0,0)},
				new Session {Title="Hello iOS",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,10,0,0)},
				new Session {Title="Hello Android",Speaker="Bryan Costanich", Location="Ballroom", Begins=new DateTime(2013,4,14,15,0,0)},
				new Session {Title="Cross-platform Navigation",Speaker="Bryan Costanich", Location="Ballroom",Begins=new DateTime(2013,4,15,9,0,0)},
				new Session {Title="Cross-platform Projects",Speaker="Bryan Costanich", Location="Ballroom",Begins=new DateTime(2013,4,15,9,0,0)},
				new Session {Title="Keynote (Day 1)",Speaker="Miguel de Icaza, Nat Friedman", Location="Ballroom",Begins=new DateTime(2013,4,16,9,0,0)},
				new Session {Title="Keynote (Day 2)",Speaker="Miguel de Icaza, Nat Friedman", Location="Ballroom",Begins=new DateTime(2013,4,17,9,0,0)},
			};
		}
	}
}