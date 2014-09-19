using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsGallery;
using FormsGallery.Droid;
using Android.Gms.Maps;

[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]

namespace FormsGallery.Droid
{
	public class MyMapRenderer : ViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null) {
				if (Control == null)
					SetNativeControl(new MapView());
				MapView mv = (MapView)Control;

			}
		}
	}
}

