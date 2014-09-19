using System;
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;

namespace TestFormsGeoLocator.Android
{
	[Activity(Label = "TestFormsGeoLocator.Android.Android", MainLauncher = true)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);
			Xamarin.FormsMaps.Init(this, bundle);

			SetPage(App.GetMainPage());

			GetLocationFromAddress("1600 Pennsylvania Avenue, Wahington DC");
		}

		public async void GetLocationFromAddress(string address)
		{
			Geocoder geocoder = new Geocoder();
			var position = (await geocoder.GetPositionsForAddressAsync(address)).ToList();
			Position pos = position[0];
			Console.WriteLine("Positions: {0}, {1}", pos.Latitude, pos.Longitude);
		}
	}
}

