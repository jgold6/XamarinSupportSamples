using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Modal
{
	public partial class ModalViewController : UIViewController
	{
		public ModalViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		partial void buttonClick (UIButton sender)
		{
			Console.WriteLine("Clicked");
			AppTableController tvc = new AppTableController();
			tvc.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
			this.PresentViewController(tvc, true, null);
		}

		#endregion
	}

	public class AppTableController : UITableViewController
	{

		public override int RowsInSection(UITableView tableview, int section)
		{
			return 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell("UITableViewCell");
			
			if (cell == null)
				// Create an instance of UITableViewCell, with default appearance
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle,"UITableViewCell");
			cell.TextLabel.Text = "Hello World!";
			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			this.DismissViewController(true, null);
		}
	}
}

