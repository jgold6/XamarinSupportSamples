using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	// TODO: Step 1b: uncomment to implement SpeakersTableSource
	public class SpeakersTableSource : UITableViewSource
	{		
		static readonly string speakerCellId = "SpeakerCell";

		string[] data;

		public SpeakersTableSource (string[] speakers)
		{
			data = speakers;
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return data.Length; // only one section
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (speakerCellId);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, speakerCellId);
			cell.TextLabel.Text = data [indexPath.Row];
			return cell;
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var speaker = data [indexPath.Row];
			
			new UIAlertView ("Speaker Selected", speaker, null, "OK", null).Show ();
			
			tableView.DeselectRow (indexPath, true);
		}
	}
}

