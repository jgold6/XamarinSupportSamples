using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using MonoTouch.MapKit;

namespace Whereami
{
	public partial class WhereamiViewController : UIViewController
	{
		CLLocationCoordinate2D currLocation {get; set;} 
		bool firstLaunch {get; set;}
		int numOfSegs {get; set;}
//		WhereAmIMapDelegate mapDelegate;

		public WhereamiViewController() : base("WhereamiViewController", null)
		{
			firstLaunch = true;
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
//			locator = new Geolocator{ DesiredAccuracy = 50 };
//
//			locator.StartListening(5000, 1, false);
//			locator.PositionChanged += (object sender, PositionEventArgs e) => {
//				Console.WriteLine ("Position Status: {0}", e.Position.Accuracy);
//				Console.WriteLine ("Position Latitude: {0}", e.Position.Latitude);
//				Console.WriteLine ("Position Longitude: {0}", e.Position.Longitude);
//			};
//			locator.PositionError += (object sender, PositionErrorEventArgs e) => {
//				Console.WriteLine("Could not find position: {0}, {1}", e.Error, e.ToString() );
//			};

			mapView.MapType = MKMapType.Standard;
			mapView.ShowsUserLocation = true;

			//currLocation = new CLLocationCoordinate2D(20.7592, -156.4572);

			// C# style event handler - can access class instance variables
			mapView.DidUpdateUserLocation += (object sender, MKUserLocationEventArgs e) => 
			{
				Console.WriteLine(".NET Lat: {0}, Long: {1}, Alt: {2}", e.UserLocation.Coordinate.Latitude, e.UserLocation.Coordinate.Longitude, e.UserLocation.Location.Altitude);
				currLocation = e.UserLocation.Coordinate;
				if (firstLaunch) {
					mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
					firstLaunch = false;
				}
				else
					mapView.SetCenterCoordinate(currLocation, true);
			};

			mapView.DidSelectAnnotationView += (object sender, MKAnnotationViewEventArgs e) => 
			{
				var annotation = e.View.Annotation as BNRMapPoint;

				if (annotation != null) {
					Console.WriteLine(".NET DidSelectAnnotationView: {0}", annotation.Title);
				}

			};

			// Strong Delegate method. Create delegate class as nested class of ViewCOntroller
			// Override need methods in that nested delegate class
//			mapDelegate = new WhereAmIMapDelegate();
//			mapView.Delegate = mapDelegate;

			// Weak delegate method. use Export attribute with selector to override then implement method.
			// Whichever is assigned last wins and kills the other. 
//			mapView.WeakDelegate =  this;

//			textField.Delegate = new TextFieldDelegate();

			textField.EditingDidEndOnExit += (object sender, EventArgs e) => 
			{
				if (!firstLaunch) {
					BNRMapPoint mp = new BNRMapPoint(textField.Text, currLocation);
					mapView.AddAnnotation(mp);
					textField.ResignFirstResponder();
					textField.Text = "";
				}
				else {
					var locator = new Geolocator{ DesiredAccuracy = 50 };
					locator.GetPositionAsync (timeout: 10000).ContinueWith (t => {
						CLLocationCoordinate2D coord = new CLLocationCoordinate2D(t.Result.Latitude, t.Result.Longitude);
						currLocation = coord;
						MKCoordinateRegion region = MKCoordinateRegion.FromDistance(currLocation, 250, 250);
						mapView.SetRegion(region, true);
						BNRMapPoint mp = new BNRMapPoint(textField.Text, currLocation);
						mapView.AddAnnotation(mp);
						textField.ResignFirstResponder();
						textField.Text = "";
					}, TaskScheduler.FromCurrentSynchronizationContext());
				}

			};

			numOfSegs = 3;
			var textAttr = new UITextAttributes() {
				Font = UIFont.FromName("ArialMT", 17-numOfSegs)
			};
			segControl.SetTitleTextAttributes(textAttr, UIControlState.Normal);

//			UIButton addSegBtn = new UIButton(new RectangleF(150, 400, 50, 50));
//			addSegBtn.SetTitle("Add Segment", UIControlState.Normal);
//			mapView.Add(addSegBtn); 
			addSegBtn.TouchUpInside += (object sender, EventArgs e) => {
				if (numOfSegs < 10) {
					numOfSegs++;
					segControl.InsertSegment("added " + numOfSegs, numOfSegs,false);
					textAttr.Font =  UIFont.FromName("ArialMT", 17-numOfSegs);
					segControl.SetTitleTextAttributes(textAttr, UIControlState.Normal);
				} 
			};



			remSegBtn.IsAccessibilityElement = true;

			remSegBtn.TouchUpInside += (object sender, EventArgs e) => {
				if (numOfSegs > 3) {
					numOfSegs--;
					segControl.RemoveSegmentAtIndex(numOfSegs, false);
					textAttr.Font =  UIFont.FromName("ArialMT", 17-numOfSegs);
					segControl.SetTitleTextAttributes(textAttr, UIControlState.Normal);
				}
			};

			segControl.BackgroundColor = UIColor.White;
			segControl.ValueChanged += (object sender, EventArgs e) => 
			{
				switch (segControl.SelectedSegment)
				{
					case 0:
						mapView.MapType = MKMapType.Standard;
						break;
					case 1:
						mapView.MapType = MKMapType.Satellite;
						break;
					case 2:
						mapView.MapType = MKMapType.Hybrid;
						break;
					case 3:
						Console.WriteLine("SegmentedControl item 4 selected");
						break;
					case 4:
						Console.WriteLine("SegmentedControl item 5 selected");
						break;
					case 5:
						Console.WriteLine("SegmentedControl item 6 selected");
						break;
					case 6:
						Console.WriteLine("SegmentedControl item 7 selected");
						break;
					case 7:
						Console.WriteLine("SegmentedControl item 8 selected");
						break;
					case 8:
						Console.WriteLine("SegmentedControl item 9 selected");
						break;
					case 9:
						Console.WriteLine("SegmentedControl item 10 selected");
						break;
					default:
						break;

				}
			};
		}

		// Weak delegates - can access class instance variables
		[Export("mapView:didSelectAnnotationView:")]
		public void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView annotationView)
		{
				var annotation = annotationView.Annotation as BNRMapPoint;
				
				if (annotation != null) {
					Console.WriteLine("Weak DidSelectAnnotationView: {0}", annotation.Title);
				}
		}

		[Export("mapView:didUpdateUserLocation:")]
		public void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
		{
			Console.WriteLine("Weak Lat: {0}, Long: {1}, Alt: {2}", userLocation.Coordinate.Latitude, userLocation.Coordinate.Longitude, userLocation.Location.Altitude);
			currLocation = userLocation.Coordinate;
			if (firstLaunch) {
				mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
				firstLaunch = false;
			}
			else
				mapView.SetCenterCoordinate(currLocation, true);
		}

		// Strong Delegate - Requires public static class variables for currLocation and firstLaunch
//		class WhereAmIMapDelegate : MKMapViewDelegate
//		{
//			public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView annotationView)
//			{
//				var annotation = annotationView.Annotation as BNRMapPoint;
//
//				if (annotation != null) {
//					Console.WriteLine("Strong DidSelectAnnotationView: {0}", annotation.Title);
//				}
//			}
//
//			public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
//			{
//				Console.WriteLine("Strong Lat: {0}, Long: {1}, Alt: {2}", userLocation.Coordinate.Latitude, userLocation.Coordinate.Longitude, userLocation.Location.Altitude);
//				currLocation = userLocation.Coordinate;
//				if (firstLaunch) {
//					mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
//					firstLaunch = false;
//				}
//				else
//					mapView.SetCenterCoordinate(currLocation, true);
//			}
//		}
	}
}



























