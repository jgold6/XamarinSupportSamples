// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CustomTableViewCell
{
	[Register ("TableViewCell")]
	partial class TableViewCell
	{
		[Outlet]
		public MonoTouch.UIKit.UILabel keyLabel { get; set; }

		[Outlet]
		public MonoTouch.UIKit.UILabel valueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (keyLabel != null) {
				keyLabel.Dispose ();
				keyLabel = null;
			}

			if (valueLabel != null) {
				valueLabel.Dispose ();
				valueLabel = null;
			}
		}
	}
}
