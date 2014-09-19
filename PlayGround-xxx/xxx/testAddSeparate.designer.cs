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
	[Register ("testAddSeparate")]
	partial class testAddSeparate
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnAtrributetest { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnLinkTest { get; set; }

		[Action ("testAction:")]
		partial void testAction (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLinkTest != null) {
				btnLinkTest.Dispose ();
				btnLinkTest = null;
			}

			if (btnAtrributetest != null) {
				btnAtrributetest.Dispose ();
				btnAtrributetest = null;
			}
		}
	}
}
