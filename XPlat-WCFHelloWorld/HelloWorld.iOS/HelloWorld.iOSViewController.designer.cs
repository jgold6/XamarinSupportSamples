// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace HelloWorld.iOS
{
	[Register ("HelloWorld_iOSViewController")]
	partial class HelloWorld_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnGetHello { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSayHello { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView tvGetHello { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView tvSayHello { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGetHello != null) {
				btnGetHello.Dispose ();
				btnGetHello = null;
			}

			if (tvSayHello != null) {
				tvSayHello.Dispose ();
				tvSayHello = null;
			}

			if (btnSayHello != null) {
				btnSayHello.Dispose ();
				btnSayHello = null;
			}

			if (tvGetHello != null) {
				tvGetHello.Dispose ();
				tvGetHello = null;
			}
		}
	}
}
