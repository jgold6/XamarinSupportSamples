// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace XamMacTestProject
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButtonCell btnButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSView mainView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSScrollView outlineView { get; set; }

		[Outlet]
		MonoMac.WebKit.WebView webView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnButton != null) {
				btnButton.Dispose ();
				btnButton = null;
			}

			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (outlineView != null) {
				outlineView.Dispose ();
				outlineView = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
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
