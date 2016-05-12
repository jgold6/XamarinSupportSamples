// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MonitorFolderForChanges
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAddFile { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDeleteFile { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView textViewFiles { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFieldAddFile { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFieldDeleteFile { get; set; }

		[Action ("BtnAddFile_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnAddFile_TouchUpInside (UIButton sender);

		[Action ("BtnDeleteFile_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnDeleteFile_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAddFile != null) {
				btnAddFile.Dispose ();
				btnAddFile = null;
			}
			if (btnDeleteFile != null) {
				btnDeleteFile.Dispose ();
				btnDeleteFile = null;
			}
			if (textViewFiles != null) {
				textViewFiles.Dispose ();
				textViewFiles = null;
			}
			if (txtFieldAddFile != null) {
				txtFieldAddFile.Dispose ();
				txtFieldAddFile = null;
			}
			if (txtFieldDeleteFile != null) {
				txtFieldDeleteFile.Dispose ();
				txtFieldDeleteFile = null;
			}
		}
	}
}
