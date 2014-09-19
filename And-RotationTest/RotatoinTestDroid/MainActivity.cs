using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RotatoinTestDroid
{
	[Activity(Label = "RotatoinTestDroid", MainLauncher = true, Icon = "@drawable/icon")] // , ConfigurationChanges=global::Android.Content.PM.ConfigChanges.Orientation|global::Android.Content.PM.ConfigChanges.ScreenSize
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			Console.WriteLine("************************************OnCreate");
//			this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
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

		public override bool OnGenericMotionEvent(MotionEvent e)
		{
			Console.WriteLine("************************************OnGenericMotionEvent {0}", e.ToString());
			return base.OnGenericMotionEvent(e);
		}

		protected override void OnPause()
		{
			Console.WriteLine("************************************OnPause");
			base.OnPause();
		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState)
		{
			Console.WriteLine("************************************OnRestoreInstanceState {0}", savedInstanceState.ToString());
			base.OnRestoreInstanceState(savedInstanceState);
		}

		public override Java.Lang.Object OnRetainNonConfigurationInstance()
		{
			Console.WriteLine("************************************OnRetainNonConfigurationInstance");
			return base.OnRetainNonConfigurationInstance();
		}

		protected override void OnRestart()
		{
			base.OnRestart();
			Console.WriteLine("************************************OnRestart");
		}

		protected override void OnResume()
		{
			Console.WriteLine("************************************OnResume");
			switch (WindowManager.DefaultDisplay.Rotation) {
				case SurfaceOrientation.Rotation0:
					Console.WriteLine("******************************************* Rotation = Portrait" );
					break;
				case SurfaceOrientation.Rotation180:
					Console.WriteLine("******************************************* Rotation = UpsideDown" );
					break;
				case SurfaceOrientation.Rotation90:
					Console.WriteLine("******************************************* Rotation = LandScape Right" );
					break;
				case SurfaceOrientation.Rotation270:
					Console.WriteLine("******************************************* Rotation = Landscape Left" );
					break;
			}

			base.OnResume();
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			Console.WriteLine("************************************OnSaveInstanceState {0}", outState.ToString());
			base.OnSaveInstanceState(outState);
		}

		protected override void OnStart()
		{
			Console.WriteLine("************************************OnStart");
			base.OnStart();
		}

		public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);
			Console.WriteLine("****************************OnConfigurationChanged {0}", newConfig);
		}
			 
    }
}


