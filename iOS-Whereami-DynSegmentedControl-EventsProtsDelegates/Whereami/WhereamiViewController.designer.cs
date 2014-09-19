// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Whereami
{
	[Register ("WhereamiViewController")]
	partial class WhereamiViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton addSegBtn { get; set; }

		[Outlet]
		MonoTouch.MapKit.MKMapView mapView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton remSegBtn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl segControl { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (addSegBtn != null) {
				addSegBtn.Dispose ();
				addSegBtn = null;
			}

			if (remSegBtn != null) {
				remSegBtn.Dispose ();
				remSegBtn = null;
			}

			if (mapView != null) {
				mapView.Dispose ();
				mapView = null;
			}

			if (segControl != null) {
				segControl.Dispose ();
				segControl = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}
		}
	}
}
