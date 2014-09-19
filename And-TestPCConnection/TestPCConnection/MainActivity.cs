using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TestPCConnection
{
	[Activity(Label = "TestPCConnection", MainLauncher = true)]
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

			if (isConnected(this.ApplicationContext)) {
				Console.WriteLine("You are connected");
			} else {
				Console.WriteLine("Not connected");
			}

		}

		public static bool isConnected(Context context) {
			var intent = context.RegisterReceiver(null, new IntentFilter("android.hardware.usb.action.USB_STATE"));
			return intent.Extras.GetBoolean("connected");
		}
	}
}


