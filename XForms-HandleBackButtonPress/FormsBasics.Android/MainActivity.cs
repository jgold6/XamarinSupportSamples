using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace Forms2Native
{
	/// <summary>
	/// Android app starts with Xamarin.Forms, then opens a natively rendered Page
	/// </summary>
	[Activity (Label = "Forms2Native", MainLauncher = true)]
	public class Activity1 : Xamarin.Forms.Platform.Android.AndroidActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);

			// Starts with the main Xamarin.Forms screen
			SetPage (App.GetMainPage ());
		}


 
        public override async void OnBackPressed()
        {
            System.Diagnostics.Debug.WriteLine("Back button pressed");
            if (Forms2Native.App.NavPage.CurrentPage.GetType() == typeof(Forms2Native.MyFirstPage))
            {
                System.Diagnostics.Debug.WriteLine("Don't go back");
            }
            else
            {
                await Forms2Native.App.NavPage.PopAsync();
            }
        }
	}
}


