using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Homepwner
{
	[Register("HeaderCell")]
	public partial class HeaderCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("HeaderCell");

		public HeaderCell(IntPtr handle) : base(handle) {}

		public HeaderCell() : base (UITableViewCellStyle.Default, Key)
		{

		}

	}
}

