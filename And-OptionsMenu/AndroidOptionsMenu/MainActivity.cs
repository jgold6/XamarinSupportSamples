using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidOptionsMenu
{
	[Activity(Label = "AndroidOptionsMenu", MainLauncher = true)]
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
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			base.OnCreateOptionsMenu (menu);
			MenuInflater inflater = this.MenuInflater;
			inflater.Inflate (Resource.Menu.OptionsMenu, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			base.OnOptionsItemSelected (item);
			switch (item.ItemId)
			{
				case Resource.Id.add:
					Console.WriteLine("New Pressed");
					break;
				case Resource.Id.call:
					{
						Console.WriteLine("Call Pressed");
						Intent intent = new Intent (Intent.ActionDial);
						StartActivity (intent);
						break;
					}
				case Resource.Id.call2:
					{
						Console.WriteLine("Call1 Pressed");
						Intent intent = new Intent (Intent.ActionDial);
						StartActivity (intent);
						break;
					}
				case Resource.Id.call3:
					{
						Console.WriteLine("Call2 Pressed");
						Intent intent = new Intent (Intent.ActionDial);
						StartActivity (intent);
						break;
					}
				case Resource.Id.phone:
					Console.WriteLine("Phone Pressed");
					break;
				case Resource.Id.refresh:
					Console.WriteLine("Refresh Pressed");
					break;
				default:
					break;
			}
			return true;
		}
	}
}


