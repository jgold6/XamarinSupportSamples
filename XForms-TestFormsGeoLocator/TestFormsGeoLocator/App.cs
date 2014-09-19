using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace TestFormsGeoLocator
{
	public class App
	{
		public static Page GetMainPage()
		{	
			ContentPage page = new ContentPage();

			View view;

			Map map = new Map();
			view = map;

			// Let's visit Xamarin HQ in San Francisco!
			Position position = new Position(37.79762, -122.40181);
			map.MoveToRegion(new MapSpan(position, 0.01, 0.01));
			map.Pins.Add(new Pin
			{
				Label = "Xamarin",
				Position = position
			});

			// Build the page.
			page.Content = new StackLayout
			{
				Children = 
				{
					view
				}
			};

			GetLocationFromAddress("1600 Pennsylvania Avenue, Wahington DC");

			return page;
		}

		public static async void GetLocationFromAddress(string address)
		{

			Geocoder geocoder = new Geocoder();
			var position = (await geocoder.GetPositionsForAddressAsync(address)).ToList();
			Position pos = position[0];
			Debug.WriteLine("Positions: {0}, {1}", pos.Latitude, pos.Longitude);
		}
	}
}

