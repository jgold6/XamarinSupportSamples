// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace Lab2.GCAndMe
{
	[Register ("Lab2_GCAndMeViewController")]
	partial class Lab2_GCAndMeViewController
	{
		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton btnGetStatus { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton btnRemoveImage { get; set; }

		[Outlet]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel lblStatus { get; set; }

		[Action ("UIButton1_TouchUpInside:")]
		[GeneratedCodeAttribute ("iOS Designer", "1.0")]
		partial void UIButton1_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnGetStatus != null) {
				btnGetStatus.Dispose ();
				btnGetStatus = null;
			}
			if (btnRemoveImage != null) {
				btnRemoveImage.Dispose ();
				btnRemoveImage = null;
			}
			if (lblStatus != null) {
				lblStatus.Dispose ();
				lblStatus = null;
			}
		}
	}
}
