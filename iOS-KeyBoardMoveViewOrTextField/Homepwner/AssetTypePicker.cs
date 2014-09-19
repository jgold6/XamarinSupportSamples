using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using System.Collections.Generic;
using System.Drawing;

namespace Homepwner
{
	public class AssetTypePicker : UITableViewController, IUITableViewDelegate, IUITableViewDataSource
	{
		public BNRItem item {get; set;}
		public UIPopoverController popoverController {get; set;}
		public DetailViewController controller {get; set;}
		public HeaderCell headerCell {get; set;}

		public AssetTypePicker() : base(UITableViewStyle.Plain)
		{
			UINavigationItem n = this.NavigationItem;
			n.Title = NSBundle.MainBundle.LocalizedString("Asset Types", "AssetTypes");

			// Create a new bar button item that will send
			// addNewItem to AssetTypePicker
			UIBarButtonItem bbi = new UIBarButtonItem(UIBarButtonSystemItem.Add, addNewItem); // Use for silver challenge

			// Set this bar button item as the right item in the navigationItem // Use for silver challenge
			n.RightBarButtonItem = bbi; // Use for silver challenge
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

//			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) { // Bronze asset type picker popover for iPad
			UIImage image = UIImage.FromBundle("tvBgImage.png");
			TableView.BackgroundView = new UIImageView(image);
//			}
		}

		public void addNewItem(object sender, EventArgs e)
		{ 
			UIAlertView alert = new UIAlertView(
				NSBundle.MainBundle.LocalizedString("Create an Asset Type", "Create Asset Type"),
				NSBundle.MainBundle.LocalizedString("Please enter a new asset type", "Please Enter"),
				null, 
				NSBundle.MainBundle.LocalizedString("Cancel", "Cancel"), 
				new string[]{NSBundle.MainBundle.LocalizedString("Done", "Done")});
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			UITextField alerttextField = alert.GetTextField(0);
			alerttextField.KeyboardType = UIKeyboardType.Default;
			alerttextField.Placeholder = NSBundle.MainBundle.LocalizedString("Enter a new asset type", "Enter New");
			alert.Show(); // Use for silver challenge
			alert.Clicked += (object avSender, UIButtonEventArgs ave) => {
				if (ave.ButtonIndex == 1) {
					Console.WriteLine("Entered: {0}", alert.GetTextField(0).Text);
					BNRItemStore.addAssetType(alert.GetTextField(0).Text);
					TableView.ReloadData();
					NSIndexPath ip = NSIndexPath.FromRowSection(BNRItemStore.allAssetTypes.Count-1, 0);
					this.RowSelected(TableView, ip);
				} else {
					this.NavigationController.PopViewControllerAnimated(true);
				}
			};
		}

		public override int NumberOfSections(UITableView tableView)
		{
			return 2;
		}

		public override int RowsInSection(UITableView tableView, int section)
		{
			int rows;
			if (section == 0)
				rows = BNRItemStore.allAssetTypes.Count;
			else { // Use for gold challenge
				var assetTypeItems = getAssetTypeItems();
				rows = assetTypeItems.Count;
			}
			return rows;
		}

		//		public override string TitleForHeader(UITableView tableView, int section)
		//		{
		//			if (section == 0)
		//				return "Asset Types";
		//			else
		//				return String.Format("{0} items", item.assetType);
		//		}

		public override float GetHeightForHeader(UITableView tableView, int section)
		{
			return 28.0f;
		}

		public override UIView GetViewForHeader(UITableView tableView, int section)
		{
			headerCell = new HeaderCell();
			var views = NSBundle.MainBundle.LoadNib("HeaderCell", headerCell, null);
			headerCell = Runtime.GetNSObject(views.ValueAt(0)) as HeaderCell;

			// Bronze asset type picker popover for iPad
//			if (section == 0 && UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
//				UIButton btnAdd = new UIButton(new RectangleF(0.0f, 0.0f, 60.0f, 40.0f));
//				btnAdd.SetTitle("Add", UIControlState.Normal);
//				btnAdd.SetTitleColor(UIColor.Blue, UIControlState.Normal);
//				btnAdd.TouchUpInside += (object sender, EventArgs e) => {
//					addNewItem(sender, e);
//				};
//
//				headerCell.ContentView.Add(btnAdd);
//			}

			headerCell.BackgroundColor = UIColor.Clear;
			if (section == 0)
				headerCell.headerLabel.Text = String.Format(NSBundle.MainBundle.LocalizedString("Asset type for ", "Asset Type for") + item.itemName);
			else
				headerCell.headerLabel.Text = String.Format(NSBundle.MainBundle.LocalizedString("All ", "All") + 
					NSBundle.MainBundle.LocalizedString(((item.assetType == "" || item.assetType == null) ? "Unassigned" : item.assetType), "Asset Type") + 
					NSBundle.MainBundle.LocalizedString(" items", "Items"));
			return headerCell;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = TableView.DequeueReusableCell("UITableViewCell");
			if (cell == null) {
				cell = new UITableViewCell(UITableViewCellStyle.Default, "UITableViewCell");
			}

			if (indexPath.Section == 0) {
				var at = BNRItemStore.allAssetTypes[indexPath.Row];
				cell.TextLabel.Text = NSBundle.MainBundle.LocalizedString(at.assetType, "AssetType");

				if (at.assetType == item.assetType)
					cell.Accessory = UITableViewCellAccessory.Checkmark;
				else
					cell.Accessory = UITableViewCellAccessory.None;
			} 
			if (indexPath.Section == 1) { 
				var assetTypeItems = getAssetTypeItems();
				var at = assetTypeItems[indexPath.Row];
				cell.TextLabel.Text = at.itemName;
				cell.Accessory = UITableViewCellAccessory.None;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			}
			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Section == 0) {
				foreach (UITableViewCell c in tableView.VisibleCells)
					c.Accessory = UITableViewCellAccessory.None;

				UITableViewCell cell = tableView.CellAt(indexPath);

				if (cell != null) 
					cell.Accessory = UITableViewCellAccessory.Checkmark;

				var at = BNRItemStore.allAssetTypes[indexPath.Row];
				item.assetType = at.assetType;
				BNRItemStore.updateDBItem(item);
//				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) { // Bronze, asset type picker popover for iPad
//					controller.updateAssetType(); // Bronze
//					popoverController.Dismiss(true); // Bronze
//					popoverController = null; // Bronze
//				} else { // Bronze
					this.NavigationController.PopViewControllerAnimated(true);
//				} // Bronze
			}
		}

		public List<BNRItem> getAssetTypeItems()
		{
			List<BNRItem> assetTypeItems = new List<BNRItem>();
			var items = BNRItemStore.allItems;

			foreach (BNRItem i in items) {
				if (i.assetType == item.assetType) {
					assetTypeItems.Add(i);
				} 
			} 
			return assetTypeItems;
		}
	}
}

