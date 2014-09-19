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
	[Register ("HomepwnerItemCell")]
	partial class HomepwnerItemCell
	{
		[Outlet]
		public MonoTouch.UIKit.UILabel nameLabel { get; private set; }

		[Outlet]
		public MonoTouch.UIKit.UILabel serialNumberLabel { get; private set; }

		[Outlet]
		public MonoTouch.UIKit.UIImageView thumbnailView { get; private set; }

		[Outlet]
		public MonoTouch.UIKit.UILabel valueLabel { get; private set; }

		[Action ("showImage:")]
		partial void showImage (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (serialNumberLabel != null) {
				serialNumberLabel.Dispose ();
				serialNumberLabel = null;
			}

			if (thumbnailView != null) {
				thumbnailView.Dispose ();
				thumbnailView = null;
			}

			if (valueLabel != null) {
				valueLabel.Dispose ();
				valueLabel = null;
			}
		}
	}
}
