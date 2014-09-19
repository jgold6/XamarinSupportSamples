using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace EvolveLite
{
	public class SessionsViewController : UITableViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			TableView = new UITableView (Rectangle.Empty, UITableViewStyle.Grouped);

			TableView.Source = new SessionsTableSource ();
		}
		
		class SessionsTableSource : UITableViewSource
		{		
			static readonly string sessionCellId = "SessionCell";

			public override int RowsInSection (UITableView tableview, int section)
			{
				return Data.Instance.SessionsGrouped[section].Count ();
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return Data.Instance.SessionsGrouped.Count ();
			}

			public override string TitleForHeader (UITableView tableView, int section)
			{
				return Data.Instance.SessionsGrouped [section].ElementAt (0).Begins.Date.ToShortDateString ();
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var sessionGroup = Data.Instance.SessionsGrouped [indexPath.Section];
				var session = sessionGroup.ElementAt (indexPath.Row);

				new UIAlertView ("Session Selected", session.Title, null, "OK", null).Show ();

				tableView.DeselectRow (indexPath, true);
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (SessionCell) tableView.DequeueReusableCell (sessionCellId);

				var sessionGroup = Data.Instance.SessionsGrouped [indexPath.Section];
				var session = sessionGroup.ElementAt (indexPath.Row);

				if (cell == null)
					cell = new SessionCell (sessionCellId);	

				cell.Session = session;
			
				return cell;
			}
		}
	}
}