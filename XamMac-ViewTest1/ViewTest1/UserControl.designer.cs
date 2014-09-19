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
	[Register ("UserControlController")]
	partial class UserControlController
	{
		[Outlet]
		MonoMac.AppKit.NSButton flickoutlet { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField label { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton picassaoutlet { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton smugoutlet { get; set; }

		[Action ("cancel:")]
		partial void cancel (MonoMac.Foundation.NSObject sender);

		[Action ("flickrAction:")]
		partial void flickrAction (MonoMac.Foundation.NSObject sender);

		[Action ("PicassaAction:")]
		partial void PicassaAction (MonoMac.Foundation.NSObject sender);

		[Action ("SmugAction:")]
		partial void SmugAction (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (flickoutlet != null) {
				flickoutlet.Dispose ();
				flickoutlet = null;
			}

			if (label != null) {
				label.Dispose ();
				label = null;
			}

			if (picassaoutlet != null) {
				picassaoutlet.Dispose ();
				picassaoutlet = null;
			}

			if (smugoutlet != null) {
				smugoutlet.Dispose ();
				smugoutlet = null;
			}
		}
	}

	[Register ("UserControl")]
	partial class UserControl
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
