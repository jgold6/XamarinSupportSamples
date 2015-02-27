using System;
using Xamarin.Forms;
using XFormsMapViewiOSPermission;
using XFormsMapViewiOSPermission.Android;
using Xamarin.Forms.Maps.Android;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;


[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]
namespace XFormsMapViewiOSPermission.Android
{
    public class MyMapRenderer : MapRenderer
    {
		MapView mapView;
		GoogleMap map;
		MyMap myMap;

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null) {

				mapView = Control as MapView;
				map = mapView.Map;

				myMap = e.NewElement as MyMap;

				PolylineOptions line = new PolylineOptions();
				line.InvokeColor(global::Android.Graphics.Color.Red);
				// Add the points of the polyline
				LatLng latLng = new LatLng(37,-122);
				line.Add(latLng);
				latLng = new LatLng(37,-122.001);
				line.Add(latLng);
				latLng = new LatLng(37.001,-122.002);
				line.Add(latLng);
				// Add the polyline to the map
				map.AddPolyline(line);

			}
		}
    }
}

