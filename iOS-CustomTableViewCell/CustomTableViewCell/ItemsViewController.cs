using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace CustomTableViewCell
{
	public partial class ItemsViewController : UITableViewController, IUITableViewDataSource, IUITableViewDelegate, IUIPopoverControllerDelegate
	{
		public List<string> keys = new List<string>();
		public List<string> values = new List<string>();

		public ItemsViewController() : base(UITableViewStyle.Plain)
		{
			keys.Add("Key1");
			keys.Add("Key2");
			keys.Add("Key3");
			keys.Add("Key4");
			keys.Add("Key5");

			values.Add("Value1");
			values.Add("Value2");
			values.Add("Value3");
			values.Add("Value4");
			values.Add("Value5");
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.

			// TableViewCell
			UINib nib = UINib.FromName("TableViewCell", null);
			// Register this NIB which contains the cell
			TableView.RegisterNibForCellReuse(nib, "TableViewCell");
		}

		public override int RowsInSection(UITableView tableView, int section)
		{
			return keys.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			TableViewCell cell = TableView.DequeueReusableCell("TableViewCell") as TableViewCell;

			// Configure the cell

			cell.keyLabel.Text = keys[indexPath.Row];
			cell.valueLabel.Text = values[indexPath.Row];

			return cell;
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return true;
			} else {
				return false;
			}
		}
	}
}



























