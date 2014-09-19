using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;

namespace ErrorOnListener
{
	class MyLocation
	{
		private Location _currentLocation;
		private LocationManager _locationManager;
		private string _locationProvider;
		private Context _context;

		public MyLocation(Context _context) {
			this._context = _context;

			InitializeLocationManager(this._context);
		}

		private void InitializeLocationManager(Context _context)
		{
			_locationManager = _context.GetSystemService(Context.LocationService) as LocationManager;

			var criteriaForLocationService = new Criteria 
			{
				Accuracy = Accuracy.Coarse
			};
			var acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				_locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				_locationProvider = String.Empty;
			}

			_locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
		}
	
		public void OnLocationChanged (Location location)
		{
			_currentLocation = location;
			Console.WriteLine(String.Format ("Latitude = {0}, Longitude = {1}", location.Latitude, location.Longitude));
		}

		public void OnProviderDisabled(string provider) { }

		public void OnProviderEnabled(string provider) { }

		public void OnStatusChanged(string provider, Availability status, Bundle extras) { }

		public string GetLatitude()
		{
			string lat = String.Empty;
			if (_currentLocation != null)
			{
				lat = _currentLocation.Latitude.ToString ();
			}
			else if (_locationManager.GetLastKnownLocation(_locationProvider) != null)
			{
				lat = _locationManager.GetLastKnownLocation(_locationProvider).Latitude.ToString();
			}
			return lat;
		}

		public string GetLongitude()
		{
			string lon = String.Empty;
			if (_currentLocation != null)
			{
				lon = _currentLocation.Longitude.ToString ();
			}
			else if (_locationManager.GetLastKnownLocation(_locationProvider) != null)
			{
				lon = _locationManager.GetLastKnownLocation(_locationProvider).Longitude.ToString();
			}
			return lon;
		}

		public void Dispose()
		{ 
		}

		public IntPtr Handle {
			get; set;
		}
	}
}

