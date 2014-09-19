using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Reflection;
using MonoTouch.ObjCRuntime;

namespace CustomTableViewCell
{
	public partial class TableViewCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName("TableViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("TableViewCell");

		public TableViewCell(IntPtr handle) : base(handle)
		{
		}

		public static TableViewCell Create()
		{
			return (TableViewCell)Nib.Instantiate(null, null)[0];
		}
	}
}

