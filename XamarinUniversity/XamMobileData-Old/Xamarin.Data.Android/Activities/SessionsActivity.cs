using System.IO;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Data.Core.Model;
using Xamarin.Data.Core.Orm;
using Xamarin.Data.Core.WebServices;

namespace Xamarin.Data.Droid.Activities
{

    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class SessionsActivity : ListActivity
    {
        Adapters.SessionsAdapter adapter;
		public List<Session> Sessions {get; private set;}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.list_with_spinner);

            adapter = new Adapters.SessionsAdapter(this, Enumerable.Empty<Session>());
            ListView.Adapter = adapter;
        }

        protected async override void OnResume()
        {
            base.OnResume();
			//TODO: Step 14 - Android - Prepare to load data
            await XamarinDataApp.DataManager.ConferenceDatabase.SetupDatabaseAsync();
			await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadLocalAsync();
            await DownloadNewDataAsync();
        }

        private async Task LoadLocalAsync()
        {
			//TODO: Step 15 - Android - Load data from database
			Sessions = await XamarinDataApp.DataManager.ConferenceDatabase.GetSessionsAsync();

            adapter.Sessions.Clear();
			adapter.Sessions.AddRange(Sessions);
			ListView.ItemClick += (sender, e) => {
				var session = Sessions[e.Position];
				Toast.MakeText(this, "Session Selected: " + session.Title, ToastLength.Long).Show();
			};
            adapter.NotifyDataSetChanged();
        }

        private async Task DownloadNewDataAsync()
        {
			//TODO: Step 16 - Android - Clear database and save new sessions
            // Download all the data
            await XamarinDataApp.DataManager.DownloadSessionXmlAsync();

            var sessions = await XamarinDataApp.DataManager.GetSessionsAsync();

            //Delete data that exists and re-import it into our database.
            await XamarinDataApp.DataManager.ConferenceDatabase.DeleteSessionsAsync();
            await XamarinDataApp.DataManager.ConferenceDatabase.SaveSessionsAsync(sessions);

            await LoadLocalAsync();
        }

    }
}