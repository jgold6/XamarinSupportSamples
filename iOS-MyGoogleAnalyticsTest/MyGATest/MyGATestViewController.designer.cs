// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MyGATest
{
	[Register ("MyGATestViewController")]
	partial class MyGATestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton b1out { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton b2out { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton b3out { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (b1out != null) {
				b1out.Dispose ();
				b1out = null;
			}

			if (b2out != null) {
				b2out.Dispose ();
				b2out = null;
			}

			if (b3out != null) {
				b3out.Dispose ();
				b3out = null;
			}
		}
	}
}
