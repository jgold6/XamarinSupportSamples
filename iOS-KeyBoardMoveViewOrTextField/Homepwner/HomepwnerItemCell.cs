using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Reflection;
using MonoTouch.ObjCRuntime;

namespace Homepwner
{
	public partial class HomepwnerItemCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName("HomepwnerItemCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("HomepwnerItemCell");

		public ItemsViewController controller {get; set;}
		public UITableView tableView {get; set;}

		public HomepwnerItemCell(IntPtr handle) : base(handle)
		{
		}

		public static HomepwnerItemCell Create()
		{
			return (HomepwnerItemCell)Nib.Instantiate(null, null)[0];
		}

		partial void showImage(NSObject sender)
		{
			// Get the name of this method, "showImage"
			string selector = MethodBase.GetCurrentMethod().Name;
			// selector is now "showImage:atIndexPath:"
			selector = selector + "AtIndexPath";

			NSIndexPath indexPath = tableView.IndexPathForCell(this);

			// in Obj-C used perform selector but here can only pass one argument, so just making a function to call on controller
			var type = controller.GetType();
			if (indexPath != null) {
				if (type.GetMethod(selector) != null) {
					controller.showImageAtIndexPath(sender, indexPath);
				}
			}

		}
	}
}

