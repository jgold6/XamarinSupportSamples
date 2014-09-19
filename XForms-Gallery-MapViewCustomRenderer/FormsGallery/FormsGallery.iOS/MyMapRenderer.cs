using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.MapKit;
using Xamarin.Forms;
using FormsGallery;
using FormsGallery.iOS;

[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]

namespace FormsGallery.iOS
{
	public class MyMapRenderer : ViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null) {
				if (Control == null)
					SetNativeControl(new MKMapView());
				MKMapView mv = (MKMapView)Control;

			}
		}
	}
}

