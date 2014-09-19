using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Geomoby.Async;

namespace GeoMobyTest
{
	[Activity(Label = "GeoMobyTest", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			
			button.Click += delegate
			{
				button.Text = string.Format("{0} clicks!", count++);
			};

			var ctat = new ClickThroughAsyncTask(this.ApplicationContext);
			var gnat = new GeoNamesAsyncTask(this.ApplicationContext);
			var rat = new RedeemAsyncTask(this.ApplicationContext);


		}
	}
}


