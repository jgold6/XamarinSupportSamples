using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo {
	public class SpeakersTableSource : UITableViewSource {
		static readonly string speakerCellId = "SpeakerCell";
		List<Speaker> data;
		
		public SpeakersTableSource (List<Speaker> speakers)
		{
			data = speakers;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return data.Count;
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var speaker = data [indexPath.Row];
			
			new UIAlertView ("Speaker Selected", speaker.Name, null, "OK", null).Show ();
			
			tableView.DeselectRow (indexPath, true);
		}

		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (speakerCellId);

			// TODO: Step 4e: change the UITableViewCellStyle according to the lab instructions
			// Uncomment only one of the built-in UITableViewCellStyles
			if (cell == null) {
//				cell = new UITableViewCell (UITableViewCellStyle.Default, speakerCellId);
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, speakerCellId);
//				cell = new UITableViewCell (UITableViewCellStyle.Value1, speakerCellId);
//				cell = new UITableViewCell (UITableViewCellStyle.Value2, speakerCellId);
			}
			var speaker = data [indexPath.Row];

			// ***** Built-in layout elements *****

			cell.TextLabel.Text = speaker.Name;

			// TODO: Step 4a: uncomment to set the cell's DetailTextLabel
			cell.DetailTextLabel.Text = speaker.Company;   // Comment out for UITableViewCellStyle.Default

			// TODO: Step 4b: uncomment to set the cell's ImageView
			cell.ImageView.Image = UIImage.FromBundle(speaker.HeadshotUrl);   // Comment out for UITableViewCellStyle.Value2

			// ***** Built-in cell accessories *****

			// TODO: Step 4c: change the cell's Accessory according to the lab instructions
//			cell.Accessory = UITableViewCellAccessory.Checkmark;
//			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
//			cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton; // allows you to wire up another 'tap' event
			
			return cell;
		}

		// TODO: Step 4d: uncomment to wire up action to DetailDisclosureButton 
//		public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
//		{
//			var speaker = data.ElementAt (indexPath.Row);
//			
//			new UIAlertView ("Session Accessory Tapped", speaker.Name, null, "OK"
//			                 , null).Show ();
//		}
	}
}