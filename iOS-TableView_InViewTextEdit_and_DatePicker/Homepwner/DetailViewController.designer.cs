// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Homepwner
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton assetTypeBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton changeDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel dateLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView imageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField nameField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField serialNumberField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem takePicture { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField valueField { get; set; }

		[Action ("assetTypeTapped:")]
		partial void assetTypeTapped (MonoTouch.Foundation.NSObject sender);

		[Action ("backgroundTapped:")]
		partial void backgroundTapped (MonoTouch.Foundation.NSObject sender);

		[Action ("deletePicture:")]
		partial void deletePicture (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (assetTypeBtn != null) {
				assetTypeBtn.Dispose ();
				assetTypeBtn = null;
			}

			if (changeDate != null) {
				changeDate.Dispose ();
				changeDate = null;
			}

			if (dateLabel != null) {
				dateLabel.Dispose ();
				dateLabel = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}

			if (serialNumberField != null) {
				serialNumberField.Dispose ();
				serialNumberField = null;
			}

			if (takePicture != null) {
				takePicture.Dispose ();
				takePicture = null;
			}

			if (valueField != null) {
				valueField.Dispose ();
				valueField = null;
			}
		}
	}
}
