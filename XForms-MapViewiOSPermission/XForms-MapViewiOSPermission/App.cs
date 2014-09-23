using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFormsMapViewiOSPermission
{
    public class App
    {
        public static Page GetMainPage()
        {    
			return new MapPage();
        }
    }

	public class MapPage : ContentPage {
		public MapPage() {
			var map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(37,-122), Distance.FromMiles(0.3))) {
				IsShowingUser = true, // iOS asks for permission if this is set to true, but not if not set or set to false.
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			Content = stack;
		}
	}
}

