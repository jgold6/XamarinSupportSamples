using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;

namespace ErrorOnListener
{
	[Activity (Label = "ErrorOnListener", MainLauncher = true)]
	public class MainActivity : Activity, ILocationListener
	{
		TextView LatLong;
		LocationManager _locMgr;
		Activity context;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			context = this;
			_locMgr = GetSystemService (Context.LocationService) as LocationManager;


			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			LatLong = FindViewById<TextView> (Resource.Id.txtLatLong);
//
//			Wait (2000);
//			string result = "Latitude: " + _loc.GetLatitude () + ", Longitude: " + _loc.GetLongitude();
//
//			LatLong.Text = result;
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			var locationCriteria = new Criteria();

			locationCriteria.Accuracy = Accuracy.NoRequirement;
			locationCriteria.PowerRequirement = Power.NoRequirement;

			string locationProvider = _locMgr.GetBestProvider(locationCriteria, true);

			_locMgr.RequestLocationUpdates (locationProvider, 2000, 1, this);
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			_locMgr.RemoveUpdates (this);
		}

		public void OnLocationChanged (Location location)
		{
			LatLong = FindViewById<TextView> (Resource.Id.txtLatLong);

			LatLong.Text = String.Format ("Latitude = {0}, Longitude = {1}", location.Latitude, location.Longitude);
		}
		public void OnProviderDisabled(string provider) { }

		public void OnProviderEnabled(string provider) { }

		public void OnStatusChanged(string provider, Availability status, Bundle extras) { }
	}
}


