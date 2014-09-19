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
	public class BNRMapPoint : MKAnnotation
	{
		string _title;
		string _subtitle;

		public BNRMapPoint(string title, CLLocationCoordinate2D coord)
		{
			_title = title;
			Coordinate = coord;

			NSDateFormatter dateFormatter = new NSDateFormatter();
			dateFormatter.DateStyle = NSDateFormatterStyle.Medium;
			dateFormatter.TimeStyle = NSDateFormatterStyle.Short;
			_subtitle = "Created: " + dateFormatter.StringFor(NSDate.Now);
		}

		public override string Title {
			get {
				return _title;
			} 
		}

		public override string Subtitle {
			get {
				return _subtitle;
			}
		}

		public override CLLocationCoordinate2D Coordinate { get; set;}
	}
}

