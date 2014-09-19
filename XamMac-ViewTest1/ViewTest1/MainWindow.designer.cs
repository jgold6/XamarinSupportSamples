// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace ViewTest1
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton addbtn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSPopover popover { get; set; }

		[Outlet]
		MonoMac.AppKit.NSScrollView scrolloutlet { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView simpleview { get; set; }

		[Action ("Addbutton:")]
		partial void Addbutton (MonoMac.Foundation.NSObject sender);

		[Action ("RefreshAction:")]
		partial void RefreshAction (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (addbtn != null) {
				addbtn.Dispose ();
				addbtn = null;
			}

			if (scrolloutlet != null) {
				scrolloutlet.Dispose ();
				scrolloutlet = null;
			}

			if (simpleview != null) {
				simpleview.Dispose ();
				simpleview = null;
			}

			if (popover != null) {
				popover.Dispose ();
				popover = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
