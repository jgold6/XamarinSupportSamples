// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamMacTestProject
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSButtonCell btnButton { get; set; }

		[Outlet]
		AppKit.NSTextField dropZone { get; set; }

		[Outlet]
		Foundation.NSObject imageDropZone { get; set; }

		[Outlet]
		AppKit.NSTextField label { get; set; }

		[Outlet]
		AppKit.NSView mainView { get; set; }

		[Outlet]
		AppKit.NSImageView viewToRotate { get; set; }

		[Outlet]
		WebKit.WebView webView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnButton != null) {
				btnButton.Dispose ();
				btnButton = null;
			}

			if (dropZone != null) {
				dropZone.Dispose ();
				dropZone = null;
			}

			if (label != null) {
				label.Dispose ();
				label = null;
			}

			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (viewToRotate != null) {
				viewToRotate.Dispose ();
				viewToRotate = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (imageDropZone != null) {
				imageDropZone.Dispose ();
				imageDropZone = null;
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
