using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GCMcase46418
{
	[BroadcastReceiver(Permission= "com.google.android.c2dm.permission.SEND")]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.RECEIVE" }, Categories = new string[] {"gcmcase46418.gcmcase46418" })]
	[IntentFilter(new string[] { "com.google.android.c2dm.intent.REGISTRATION" }, Categories = new string[] {"gcmcase46418.gcmcase46418" })]
	[IntentFilter(new string[] { "com.google.android.gcm.intent.RETRY" }, Categories = new string[] { "gcmcase46418.gcmcase46418"})]
	public class MyGCMBroadcastReceiver : BroadcastReceiver
	{
		const string TAG = "PushHandlerBroadcastReceiver";
		public override void OnReceive(Context context, Intent intent)
		{

			MyIntentService.RunIntentInService(context, intent);
			SetResult(Result.Ok, null, null);
		}
	}

	[BroadcastReceiver]
	[IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted })]
	public class MyGCMBootReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{

			MyIntentService.RunIntentInService(context, intent);
			SetResult(Result.Ok, null, null);
		}
	}

	[Service]
	public class MyIntentService : IntentService
	{
		static PowerManager.WakeLock sWakeLock;
		static object LOCK = new object();

		public static void RunIntentInService(Context context, Intent intent)
		{
			lock (LOCK)
			{
				if (sWakeLock == null)
				{
					// This is called from BroadcastReceiver, there is no init.
					var pm = PowerManager.FromContext(context);
					sWakeLock = pm.NewWakeLock(
						WakeLockFlags.Partial, "My WakeLock Tag");
				}
			}

			sWakeLock.Acquire();
			intent.SetClass(context, typeof(MyIntentService));
			context.StartService(intent);
		}

		protected override void OnHandleIntent(Intent intent)
		{
			try
			{
				Context context = this.ApplicationContext;
				string action = intent.Action;

				if (action.Equals("com.google.android.c2dm.intent.REGISTRATION"))
				{
					HandleRegistration(context, intent);
				}
				else if (action.Equals("com.google.android.c2dm.intent.RECEIVE"))
				{
					HandleMessage(context, intent);
				}
			}
			finally
			{
				lock (LOCK)
				{
					//Sanity check for null as this is a public method
					if (sWakeLock != null)
						sWakeLock.Release();
				}
			}
		}

		private void HandleRegistration(Context context, Intent intent) // possible area to debug, unclear demo
		{
			string senders = "320899005792";
			Intent intent2 = new Intent("com.google.android.c2dm.intent.REGISTER"); // changed to intent2 to avoid conflict above
			intent2.SetPackage("com.google.android.gsf");
			intent2.PutExtra("app", PendingIntent.GetBroadcast(context, 0, new Intent(), 0));
			intent2.PutExtra("sender", senders);
			context.StartService(intent2);
		}

		private void HandleMessage(Context context, Intent intent)
		{

		}
	}
}
// to unsubscribe:
// Intent intent = new Intent("com.google.android.c2dm.intent.UNREGISTER");
// intent.PutExtra("app", PendingIntent.GetBroadcast(context, 0, new Intent(), 0));
// context.StartService(intent)

// get registration returned messages:
// string registrationId = intent.GetStringExtra("registration_id");
// string error = intent.GetStringExtra("error");
// string unregistration = intent.GetStringExtra("unregistered");
