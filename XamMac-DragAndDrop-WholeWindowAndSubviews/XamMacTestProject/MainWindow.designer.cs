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
		XamMacTestProject.DottedBox dottedBox { get; set; }

		[Outlet]
		AppKit.NSTextField dropZone { get; set; }

		[Outlet]
		AppKit.NSImageView imageDropZone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dropZone != null) {
				dropZone.Dispose ();
				dropZone = null;
			}

			if (imageDropZone != null) {
				imageDropZone.Dispose ();
				imageDropZone = null;
			}

			if (dottedBox != null) {
				dottedBox.Dispose ();
				dottedBox = null;
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
