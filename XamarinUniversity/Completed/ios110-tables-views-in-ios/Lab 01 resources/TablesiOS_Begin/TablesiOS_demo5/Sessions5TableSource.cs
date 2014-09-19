using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	public class SessionsTableSource : UITableViewSource
	{		
		static readonly string sessionCellId = "SessionCell";
		List<Session> data;
		IGrouping<int, Session>[] grouping; // sub-group of speakers in each index
		
		public SessionsTableSource (List<Session> sessions)
		{
			data = sessions;
			grouping = GetSessionsGroupedByDate();
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return grouping[section].Count ();
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return grouping.Count ();
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return grouping [section].ElementAt (0).Begins.Date.ToString ("dd MMM yyyy");
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);
			
			new UIAlertView ("Session Selected", session.Title, null, "OK", null).Show ();
			
			tableView.DeselectRow (indexPath, true);
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);

			// Specifies the Default table cell style
//			var cell = tableView.DequeueReusableCell (sessionCellId);
//			if (cell == null)
//				cell = new UITableViewCell (UITableViewCellStyle.Default, sessionCellId);
//			cell.TextLabel.Text = session.Title;

			// TODO: Step 5b: uncomment to use our custom table cell for the table (delete above)
			// Specifies our custom table cell style
			var cell = (SessionCell)tableView.DequeueReusableCell (sessionCellId);	// Cast the dequeued cell to our custom type
			if (cell == null)
				cell = new SessionCell (sessionCellId);		// Create new instances of the custom type
			cell.Session = session;
			
			return cell;
		}
		
		
		// helper method
		IGrouping<int, Session>[] GetSessionsGroupedByDate ()
		{
			var sessionsGrouped = (from s in data
			                       group s by s.Begins.Day into g
			                       select g).ToArray ();
			
			return sessionsGrouped;
		}
	} 
}

