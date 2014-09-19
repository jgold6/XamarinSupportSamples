using Android.App;
using Android.Widget;
using Android.OS;

namespace AsyncWork
{
	[Activity(Label = "Music Player", MainLauncher = true, Icon="@drawable/icon")]
	public class MainActivity : Activity
	{
		ProgressBar _loading;
		ListView _songList;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			_loading = FindViewById <ProgressBar>(Resource.Id.loadingBar);
			_loading.Indeterminate = false;
			_loading.Visibility = Android.Views.ViewStates.Gone;

			_songList = FindViewById<ListView>(Resource.Id.songList);
		}

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.actionbar, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.refresh:
					OnRefresh();
					break;
				default:
					break;
			}

			return base.OnOptionsItemSelected(item);
		}

		async void OnRefresh()
		{
			try
			{
				_loading.Indeterminate = true;
				_loading.Visibility = Android.Views.ViewStates.Visible;

//				var songs = WebService.GetSongs();

				// TODO: Step 2 - call the async version of the service.
				var songs = await WebService.BetterGetSongsAsync();
				_songList.Adapter = new StringAdapter<Song>(songs, null, s => s.Title, s => s.Artist);
			}
			finally
			{
				_loading.Indeterminate = false;
				_loading.Visibility = Android.Views.ViewStates.Gone;
			}

		}
	}
}


