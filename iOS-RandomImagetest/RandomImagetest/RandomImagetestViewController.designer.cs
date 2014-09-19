// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace RandomImagetest
{
	[Register ("RandomImagetestViewController")]
	partial class RandomImagetestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (btn != null) {
				btn.Dispose ();
				btn = null;
			}
		}
	}
}
