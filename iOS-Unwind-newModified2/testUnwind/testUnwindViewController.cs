using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace testUnwind
{
	public partial class testUnwindViewController : UIViewController
	{
		UITableView table;
		public testUnwindViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
//			table = new UITableView(View.Bounds);
//			table.AutoresizingMask = UIViewAutoresizing.All;
//			CreateTableItems();
//			Add (table);
		}

//		protected void CreateTableItems ()
//		{
//			List<string> tableItems = new List<string> ();
//			tableItems.Add ("Vegetables");
//			tableItems.Add ("Fruits");
//			tableItems.Add ("Flower Buds");
//			tableItems.Add ("Legumes");
//			tableItems.Add ("Bulbs");
//			tableItems.Add ("Tubers");
//			table.Source = new testUnwindTableSource(tableItems.ToArray());
//		}


		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		[Action ("unwind:")]
		public void unwind (MonoTouch.UIKit.UIStoryboardSegue sender)
		{
			UIAlertView alert = new UIAlertView("Test","message",null,"Cancel",null);
			alert.Show();
		}

		#endregion
	}
}

