using System;
using MonoTouch.UIKit;

namespace TheBestAppEver
{
	public class SongsViewController : UITableViewController
	{
		SongsViewModel viewModel;
		UIProgressView progressView;

		DateTime _lastUpdated = DateTime.MinValue; // keep track of reloaddata() calls

		public SongsViewController ()
		{
			Title = "Songs";
			TableView.Source = new ViewModelDataSource<Song> {
				CellForItem = (tv,item) => {
					var cell = tv.DequeueReusableCell<SongCell>(SongCell.Key);
					cell.Song = item;
					return cell;
				},
				ViewModel = (viewModel = new SongsViewModel()),
			};

			TableView.TableHeaderView = progressView = new UIProgressView (UIProgressViewStyle.Bar) {
				Alpha = 0f
			};

			progressView.SizeToFit ();

			// Slow point
//			viewModel.ItemsChanged += (sender, e) => 
//				InvokeOnMainThread(() => {
//					Console.WriteLine("Reloading the TableView.");
//					TableView.ReloadData();
//				});

			// Better
			viewModel.ItemsChanged += (sender, e) => {
				if ((DateTime.Now - _lastUpdated).TotalSeconds >= 1) { // to speed up
					InvokeOnMainThread(() => {
						Console.WriteLine("Reloading the TableView.");
						TableView.ReloadData();
					});
					_lastUpdated = DateTime.Now;
				}
			};

			viewModel.SongsUpdated += progress => 
				InvokeOnMainThread(() => {
					Console.WriteLine("{0:P}", progress);
					progressView.Progress = progress;
					progressView.Alpha = progress >= 1f ? 0 : 1;
				});

		}

		public async override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			await viewModel.Refresh();
		}
	}
}

