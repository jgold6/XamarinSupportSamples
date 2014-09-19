using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace AndroidVideoEmbedded
{
	[Activity(Label = "AndroidVideoEmbedded", MainLauncher = true)]
	public class MainActivity : Activity, ISurfaceHolderCallback
	{
		int count = 1;
		VideoView videoView;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			videoView = FindViewById<VideoView> (Resource.Id.videoView1);

			play ("videoviewdemo.mp4");
		}
		MediaPlayer player;

		void play(string fullPath)
		{
			ISurfaceHolder holder = videoView.Holder;
			holder.SetType (SurfaceType.PushBuffers);
			// Necesito saber cuando la superficie esta creada para poder asignar el Display al MediaPlayer
			holder.AddCallback (this);
			player = new MediaPlayer();
			Android.Content.Res.AssetFileDescriptor afd = this.Assets.OpenFd(fullPath);
			if (afd != null)
			{
				player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
				player.Prepare ();
				player.Start();
			}
		}

		public void SurfaceCreated (ISurfaceHolder holder)
		{
			Console.WriteLine ("SurfaceCreated");
			player.SetDisplay(holder);
		}

		public void SurfaceDestroyed (ISurfaceHolder holder)
		{
			Console.WriteLine ("SurfaceDestroyed");
		}

		public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine ("SurfaceChanged");
		}
	}

}


			// Get our button from the layout resource,
			// and attach an event to it
//			Button button = FindViewById<Button>(Resource.Id.myButton);
//			
//			button.Click += delegate
//			{
//				button.Text = string.Format("{0} clicks!", count++);
//			};
//
//			var videoView = FindViewById<VideoView> (Resource.Id.videoView1);
//			var uri = Android.Net.Uri.Parse("file:///android_asset/videoviewdemo.mp4");
//			videoView.SetVideoURI(uri);
//			videoView.Start();
//		}
//	}
//}


