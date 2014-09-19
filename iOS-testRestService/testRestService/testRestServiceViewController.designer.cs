// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace testRestService
{
	[Register ("testRestServiceViewController")]
	partial class testRestServiceViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnClearText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSendRestRequest { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblOutput { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnSendRestRequest != null) {
				btnSendRestRequest.Dispose ();
				btnSendRestRequest = null;
			}

			if (btnClearText != null) {
				btnClearText.Dispose ();
				btnClearText = null;
			}

			if (lblOutput != null) {
				lblOutput.Dispose ();
				lblOutput = null;
			}
		}
	}
}
