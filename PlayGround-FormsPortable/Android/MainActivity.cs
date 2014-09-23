using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Android.Webkit;


namespace FormsPlayground.Android
{
	[Activity(Label = "FormsPlayground.Android.Android", MainLauncher = true, Theme="@android:style/Theme.Holo.Light")]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);

			SetPage(App.GetMainPage());


		}

		public static string test()
		{

			//Xamarin.Forms.Forms.Init(, new Bundle());
			return "Success!";
		}
	}
}

