using System;
using Xamarin.Forms;
using XFormsMapViewiOSPermission;
using XFormsMapViewiOSPermission.iOS;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using UIKit;
using CoreLocation;



[assembly: ExportRenderer (typeof (MyMap), typeof (MyMapRenderer))]
namespace XFormsMapViewiOSPermission.iOS
{
    public class MyMapRenderer : MapRenderer
    {
		MKMapView mapView;
		MyMap myMap;
		MKPolyline lineOverlay;
		MKPolylineRenderer lineRenderer;

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null) {

				mapView = Control as MKMapView;

				myMap = e.NewElement as MyMap;

				mapView.OverlayRenderer = (m, o) => {
					if(lineRenderer == null) {
						lineRenderer = new MKPolylineRenderer(o as MKPolyline);
						lineRenderer.StrokeColor = UIColor.Red;
						lineRenderer.FillColor = UIColor.Red;
					}
					return lineRenderer;
				};

				lineOverlay = MKPolyline.FromCoordinates(new CLLocationCoordinate2D[] {new CLLocationCoordinate2D(37,-122), new CLLocationCoordinate2D(37,-122.001), new CLLocationCoordinate2D(37.001,-122.002)});
				mapView.AddOverlay (lineOverlay);
			}
		}
    }
}

