using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Homepwner
{
	public partial class ItemsViewController : UITableViewController, IUITableViewDataSource, IUITableViewDelegate, IUITextFieldDelegate
	{


		public ItemsViewController() : base(UITableViewStyle.Plain)
		{
			
		}
			

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.

			UINavigationItem n = this.NavigationItem;
			n.Title = NSBundle.MainBundle.LocalizedString("Homepwner", "Application Name");

			// Create a new bar button item that will send
			// addNewItem to ItemsViewController
			UIBarButtonItem bbi = new UIBarButtonItem(UIBarButtonSystemItem.Add, addNewItem);

			// Set this bar button item as the right item in the navigationItem
			n.RightBarButtonItem = bbi;
			n.LeftBarButtonItem = this.EditButtonItem;

			BNRItemStore.loadItemsFromDatabase();
			// HomepwnerItemCell
			UINib nib = UINib.FromName("HomepwnerItemCell", null);
			// Register this NIB which contains the cell
			TableView.RegisterNibForCellReuse(nib, "HomepwnerItemCell");
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.TableView.ReloadData();
		}


		public override int RowsInSection(UITableView tableView, int section)
		{
			return BNRItemStore.allItems.Count;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 63;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			BNRItem item = BNRItemStore.allItems[indexPath.Row];

			HomepwnerItemCell cell = TableView.DequeueReusableCell("HomepwnerItemCell") as HomepwnerItemCell;

			// Configure the cell
			cell.nametextField.Text = item.itemName;

			// Handle text field return key pressed
			cell.nametextField.ShouldReturn += ((textField) => {
				textField.ResignFirstResponder();
				item.itemName = textField.Text;
				BNRItemStore.updateDBItem(item);
				return true;
			});

			cell.dateField.Text = item.dateCreated.ToShortDateString();
			// Store the index to this item in the button so we can get it in the handler
			cell.dateField.Tag = indexPath.Row;
			if (cell.dateField.InputView == null) {
				cell.dateField.InputView = GetDatePickerView (cell.dateField);
			}

			return cell;
		}

		// Set up and display the date picker and handle when done picking date
		UIView GetDatePickerView (UITextField dateField)
		{

			var dpSuperView = new UIView(new RectangleF(0, 0, this.View.Frame.Width, 240));
			dpSuperView.BackgroundColor = UIColor.White;


			var dp = new UIDatePicker(new RectangleF(0,40,0,0));
			dp.Mode = UIDatePickerMode.Date;
			dpSuperView.AddSubview(dp);

			var doneButton = new UIButton(new RectangleF ((this.View.Frame.Size.Width/2) - 50, 0, 100, 50));
			doneButton.SetTitle("Done", UIControlState.Normal);
			doneButton.SetTitleColor (this.View.TintColor, UIControlState.Normal);
			dpSuperView.AddSubview(doneButton);

			BNRItem item = BNRItemStore.allItems[dateField.Tag];
			dp.Date = item.dateCreated;

			dp.ValueChanged += (sender2, e2) => {
				DateTime newDate = dp.Date;
				dateField.Text = newDate.ToLocalTime().ToShortDateString();
				item.dateCreated = newDate.ToLocalTime();
				BNRItemStore.updateDBItem(item);
			};

			doneButton.TouchUpInside += (object sender, EventArgs e) => {
				dateField.EndEditing(true);
			};

			return dpSuperView;
		}


		// Handles dragging row to new location
		public override void MoveRow(UITableView tableView, NSIndexPath fromIndexPath, NSIndexPath toIndexPath)
		{
			BNRItemStore.moveItem(fromIndexPath.Row, toIndexPath.Row);
			foreach (BNRItem i in BNRItemStore.allItems) 
				Console.WriteLine("ordering value for item {0} = {1}", BNRItemStore.allItems.IndexOf(i), i.orderingValue);
		}

		// Handles delete item
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			//base.CommitEditingStyle(tableView, editingStyle, indexPath);
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				BNRItem itemToRemove = BNRItemStore.allItems[indexPath.Row];
				BNRItemStore.RemoveItem(itemToRemove);
				NSIndexPath[] indexPaths = new NSIndexPath[] {indexPath};
				this.TableView.DeleteRows(indexPaths, UITableViewRowAnimation.Automatic);
				this.TableView.ReloadData();
			}
		}

		// Handles + button 
		void addNewItem(object sender, EventArgs e)
		{
			BNRItemStore.CreateItem();
			this.TableView.ReloadData();
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



























