using System;
using System.Net;
using System.IO;
using Android.App;
using Android.Widget;
using Android.OS;
using Java.IO;

namespace AndroidVideoEmbedded
{
	[Activity(Label = "AndroidVideoEmbedded", MainLauncher = true)]
	public class MainActivity : Activity
	{
		VideoView videoView;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			videoView = FindViewById<VideoView> (Resource.Id.videoView1);

			string uriPath = "android.resource://" + this.PackageName + "/" + Resource.Raw.videoviewdemo;
			play (uriPath);

			var webClient = new WebClient();
			webClient.DownloadDataCompleted += (s, e) => {
				var bytes = e.Result; // get the downloaded data
				string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
				string localFilename = "downloaded.mp4";
				string localPath = Path.Combine (documentsPath, localFilename);
				System.IO.File.WriteAllBytes (localPath, bytes); // writes to local storage 
				RunOnUiThread(() => 
					play(localPath)				
				);
			};

			var url = new Uri("http://johnnygold.com/AlexiaAndMorganDance1.mp4");

			webClient.DownloadDataAsync(url);

		}

		void play(string fullPath)
		{
			videoView.SetVideoPath(fullPath);
			videoView.Start();
		}
	}
}
	
