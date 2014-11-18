// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace TeamV
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField text { get; set; }

		[Outlet]
		MonoMac.WebKit.WebView web { get; set; }

		[Action ("AuthorizeMe:")]
		partial void AuthorizeMe (MonoMac.Foundation.NSObject sender);

		[Action ("GoWeb:")]
		partial void GoWeb (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (text != null) {
				text.Dispose ();
				text = null;
			}

			if (web != null) {
				web.Dispose ();
				web = null;
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
