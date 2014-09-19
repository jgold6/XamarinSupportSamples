// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CAAnim
{
	[Register ("FlashViewController")]
	partial class FlashViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnShowTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblTime { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (btnShowTime != null) {
				btnShowTime.Dispose ();
				btnShowTime = null;
			}

			if (lblTime != null) {
				lblTime.Dispose ();
				lblTime = null;
			}
		}
	}
}
