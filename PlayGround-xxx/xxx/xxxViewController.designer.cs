// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace xxx
{
	[Register ("xxxViewController")]
	partial class xxxViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextView aboutUsTextView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIProgressView progBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (aboutUsTextView != null) {
				aboutUsTextView.Dispose ();
				aboutUsTextView = null;
			}

			if (btn != null) {
				btn.Dispose ();
				btn = null;
			}

			if (progBar != null) {
				progBar.Dispose ();
				progBar = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}
		}
	}
}
