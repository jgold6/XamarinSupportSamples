using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Xamarin.Data.Core.Model;
using Xamarin.Data.iOS.UserInterface;
using Xamarin.Data.Core.Orm;
using Xamarin.Data.Core.WebServices;
using BigTed;

namespace Xamarin.Data.iOS.ViewControllers
{
    public class SessionsViewController : UITableViewController
    {
        private SessionsTableSource source;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // set the table style to Grouped (otherwise Default is by default)
            TableView = new UITableView(Rectangle.Empty, UITableViewStyle.Grouped);

            source = new SessionsTableSource(Enumerable.Empty<Session>());
            TableView.Source = source;
        }

        public async override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //TODO: Step 14 - iOS - Prepare to load data
//            await AppDelegate.DataManager.ConferenceDatabase.SetupDatabaseAsync();
//            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var showLoading = source.Sessions.Count == 0;

            if (showLoading)
                BTProgressHUD.ShowContinuousProgress("Updating", ProgressHUD.MaskType.Gradient);

            await DownloadNewDataAsync();

            if (showLoading)
                BTProgressHUD.Dismiss();
        }

        private async Task LoadLocalAsync()
        {
            //TODO: Step 15 - iOS - Load data from database
//            var sessions = await AppDelegate.DataManager.ConferenceDatabase.GetSessionsAsync();
//
//            source.Sessions.Clear();
//            source.Sessions.AddRange(sessions);
//            TableView.ReloadData();
        }

        private async Task DownloadNewDataAsync()
        {
            //TODO: Step 16 - iOS - Clear database and save new sessions
//            // Download all the data
//            await AppDelegate.DataManager.DownloadSessionXmlAsync();
//
//            var sessions = await AppDelegate.DataManager.GetSessionsAsync();
//
//            //Delete data that exists and re-import it into our database.
//            await AppDelegate.DataManager.ConferenceDatabase.DeleteSessionsAsync();
//            await AppDelegate.DataManager.ConferenceDatabase.SaveSessionsAsync(sessions);
//
//            await LoadLocalAsync();
        }

        class SessionsTableSource : UITableViewSource
        {
            private const string sessionCellId = "SessionCell";

            public List<Session> Sessions {get; private set;}

            public SessionsTableSource(IEnumerable<Session> sessions)
            {
                this.Sessions = new List<Session>(sessions);
            }

            public override int RowsInSection(UITableView tableview, int section)
            {
                return Sessions.Count();
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var session = Sessions[indexPath.Row];

                new UIAlertView("Session Selected", session.Title, null, "OK", null).Show();

                tableView.DeselectRow(indexPath, true);
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (SessionCell)tableView.DequeueReusableCell(sessionCellId);

                var session = Sessions[indexPath.Row];
                if (cell == null)
                    cell = new SessionCell(sessionCellId);

                cell.Session = session;

                return cell;
            }
        }
    }
}