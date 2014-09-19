// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace telephonytest
{
	[Register ("telephonytestViewController")]
	partial class telephonytestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton callBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel callLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (callBtn != null) {
				callBtn.Dispose ();
				callBtn = null;
			}

			if (callLabel != null) {
				callLabel.Dispose ();
				callLabel = null;
			}
		}
	}
}
