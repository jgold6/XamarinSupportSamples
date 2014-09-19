using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace CollectionViewDemo
{
	// TODO: Step 5a: build a background view with a MapView 
	public class MapDecorationView : UICollectionReusableView
	{
		MKMapView map;

		[Export ("initWithFrame:")]
		MapDecorationView (RectangleF frame) : base (frame)
		{
			AutosizesSubviews = true;

			// create a map
			map = new MKMapView (frame);
			map.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			map.MapType = MKMapType.Hybrid;
			map.UserInteractionEnabled = false;

			// set map center and region
			double lat = 30.2652233534254;
			double lon = -97.74215460962083;
			CLLocationCoordinate2D mapCenter = new CLLocationCoordinate2D (lat, lon);
			MKCoordinateRegion mapRegion = MKCoordinateRegion.FromDistance (mapCenter, 2000, 2000);
			map.CenterCoordinate = mapCenter;
			map.Region = mapRegion;

			AddSubview (map);
		}
	}
}