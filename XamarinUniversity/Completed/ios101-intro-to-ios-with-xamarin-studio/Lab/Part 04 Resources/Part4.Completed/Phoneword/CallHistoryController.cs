using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Phoneword
{
	partial class CallHistoryController : UITableViewController
	{
		public List<String> PhoneNumbers { get; set; }

		public CallHistoryController (IntPtr handle) : base (handle)
		{
			PhoneNumbers = new List<string> ();
			TableView.Source = new CallHistoryDataSource (this);
		}

		class CallHistoryDataSource : UITableViewSource
		{
			// Reuse identifier
			const string CellId = "PhoneNumberCellStyle";

			readonly CallHistoryController controller;

			public CallHistoryDataSource (CallHistoryController controller)
			{
				this.controller = controller;
			}

			// Returns the number of rows in each section of the table
			public override int RowsInSection (UITableView tableview, int section)
			{
				return controller.PhoneNumbers.Count;
			}

			// Returns a table cell for the row indicated by row property of the NSIndexPath
			// This method is called multiple times to populate each row of the table.
			// The method automatically uses cells which have scrolled off the screen or creates new ones as necessary.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CellId);
				if (cell == null)
					cell = new UITableViewCell(UITableViewCellStyle.Default, CellId);

				cell.TextLabel.Text = controller.PhoneNumbers [indexPath.Row];
				return cell;
			}
		}
	}
}	