using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Gcm;
using System.Threading;
using System.Threading.Tasks;

namespace GCMcase46418
{
	[Activity (Label = "GCMcase46418", MainLauncher = true)]
	public class MainActivity : Activity
	{

		string senderId = "320899005792";
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var textView = this.FindViewById<TextView> (Resource.Id.textView1);
			textView.Text = "Start here...";

			GoogleCloudMessaging _gcm;
			_gcm = GoogleCloudMessaging.GetInstance (this.ApplicationContext);

			string regid = "";

			Task.Factory.StartNew (() => {
				try {
					regid = _gcm.Register (senderId);
				}
				catch (Exception exc) {
					textView.Text += "Error: " + exc.ToString();
				}
			}).ContinueWith (task  => {
				// Code to get location here. Must end up with a Town and state 
				// and then search the stations array for that town and state
				// and get an index number to set for the selectedStation
				// all done in UpdateLocDisplay method
				textView.Text += "Success! Registration ID: " + regid;
			}, TaskScheduler.FromCurrentSynchronizationContext ());



		}
	}
}
////Registering
//string senders = "<Google Cloud Messaging Sender ID>";
//Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");
//intent.SetPackage("com.google.android.gsf");
//intent.PutExtra("app", PendingIntent.GetBroadcast(context, 0, new Intent(), 0));
//intent.PutExtra("sender", senders);
//context.StartService(intent);

////Unsubscribe
//Intent intent = new Intent("com.google.android.c2dm.intent.UNREGISTER");
//intent.PutExtra("app", PendingIntent.GetBroadcast(context, 0, new Intent(), 0));
//context.StartService(intent)