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

		string _SENDER_ID = "320899005792";
		private GoogleCloudMessaging _gcm;

//		private NotificationHub _hub;



		protected override void OnCreate(Bundle bundle)

		{

			base.OnCreate(bundle);



			// Set our view from the "main" layout resource

			SetContentView(Resource.Layout.Main);

			_gcm = GoogleCloudMessaging.GetInstance(this.ApplicationContext);


			Task<int> i = Test();

		}



		private async Task<int> Test()

		{

			return await registerWithNotificationHubs();

		}



		private Task<int> registerWithNotificationHubs()

		{

			try

			{

				//string senders = _SENDER_ID;

				//Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");

				//intent.SetPackage("com.google.android.gsf");

				//intent.PutExtra("app", PendingIntent.GetBroadcast(this, 0, new Intent(), 0));

				//intent.PutExtra("sender", senders);

				//this.StartService(intent);



				string regid = "";
				var textView = this.FindViewById<TextView>(Resource.Id.textView1);
				Task.Factory.StartNew (() => {
					try {
						regid = _gcm.Register (_SENDER_ID);
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
//				_hub.Register(regid);



				return Task.FromResult(1);

			}

			catch (Exception ex)

			{

				string err = ex.ToString();
				var textView = this.FindViewById<TextView>(Resource.Id.textView1);
				textView.Text += "Error: " + err;
				return Task.FromResult(0); 

			}

		}

//			GoogleCloudMessaging _gcm;
//			_gcm = GoogleCloudMessaging.GetInstance (this.ApplicationContext);
//
//			string regid = "";
//
//			Task.Factory.StartNew (() => {
//				try {
//					regid = _gcm.Register (senderId);
//				}
//				catch (Exception exc) {
//					textView.Text += "Error: " + exc.ToString();
//				}
//			}).ContinueWith (task  => {
//				// Code to get location here. Must end up with a Town and state 
//				// and then search the stations array for that town and state
//				// and get an index number to set for the selectedStation
//				// all done in UpdateLocDisplay method
//				textView.Text += "Success! Registration ID: " + regid;
//			}, TaskScheduler.FromCurrentSynchronizationContext ());



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