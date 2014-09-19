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

		public HomepwnerItemCell(IntPtr handle) : base(handle)
		{
		}

		public static HomepwnerItemCell Create()
		{
			return (HomepwnerItemCell)Nib.Instantiate(null, null)[0];
		}
	}
}

