using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SearchSample
{
    public class ParentViewController : UIViewController
    {
        private UISearchBar _searchBar;
        private UISearchDisplayController _searchController;

		// Added
		private UITableViewController tableViewController;
		private UITableViewController searchTableViewController;
		public GuidIndexedTableViewSource holdIndexedSource {get; set;}
		public GuidSearchTableViewSource holdSearchSource {get; set;}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "People";

            // This pushes the view below the navbar so they don't overlap.
            EdgesForExtendedLayout = UIRectEdge.None;

			// Changed
			tableViewController = new UITableViewController();
			// Added
			holdIndexedSource = new GuidIndexedTableViewSource();
			tableViewController.TableView.Source = holdIndexedSource;

            // This adds space at the top of the table to prevent the index headers overlapping with the search bar.
            var topInset = new UIEdgeInsets(24, 0, 0, 0);
            tableViewController.TableView.ContentInset = topInset;
            tableViewController.TableView.ScrollIndicatorInsets = topInset;

            _searchBar = new UISearchBar()
            {
                Placeholder = "Search",
                AutocorrectionType = UITextAutocorrectionType.No,
                AutocapitalizationType = UITextAutocapitalizationType.None,
            };
            _searchBar.SizeToFit();

            View.Add(tableViewController.TableView);
            View.Add(_searchBar);

			// Added 
			searchTableViewController = new UITableViewController();
			_searchController = new UISearchDisplayController(_searchBar, searchTableViewController);

			// Changed
			_searchController.WeakDelegate = this;

			// Added 
			holdSearchSource = new GuidSearchTableViewSource("", new List<GuidIndexedDataItem>());
			_searchController.SearchResultsSource = holdSearchSource;
			ControllerHelpers.TitleCountUpdater(holdIndexedSource.GetItemCount());

            //var searchTableViewSource = new GuidSearchedTableViewSource("", new List<GenericGuidIndexedItem>());
            //_searchController.SearchResultsSource = searchTableViewSource;

            //var searchDelegate = new SearchDelegate();
            //var searchTableViewSource = new GuidSearchedTableViewSource("", new List<GenericGuidIndexedItem>());
            //_searchController.Delegate = searchDelegate;
            //_searchController.SearchResultsSource = searchTableViewSource;
        }

		[Export ("searchDisplayControllerWillBeginSearch:")]
		public void WillBeginSearch(UISearchDisplayController controller)
		{
			// When search begins hide original view's RH index
			holdSearchSource = new GuidSearchTableViewSource("", new List<GuidIndexedDataItem>());
			tableViewController.TableView.Source = holdSearchSource;
			tableViewController.TableView.ReloadData();
		}

		[Export ("searchDisplayController:shouldReloadTableForSearchString:")]
		public bool ShouldReloadForSearchString(UISearchDisplayController controller, string forSearchString)
		{
			//			var searchContentsController = controller.SearchContentsController as UITableViewController;
			//			var tvs = (GuidIndexedTableViewSource)searchContentsController.TableView.Source;

			//controller.SearchResultsSource = new GuidSearchedTableDataSource(forSearchString, tvs.IndexedItems);

			tableViewController.TableView.Source = holdSearchSource; // moved from above

			holdSearchSource.UpdateData(forSearchString, holdIndexedSource.IndexedItems);
			tableViewController.TableView.ReloadData();
			return true;
		}

		[Export ("searchDisplayController:willHideSearchResultsTableView:")]
		public void WillHideSearchResults(UISearchDisplayController controller, UITableView tableView)
		{
			holdSearchSource = new GuidSearchTableViewSource("", new List<GuidIndexedDataItem>());
			tableViewController.TableView.Source = holdSearchSource;
			tableViewController.TableView.ReloadData();
		}


		[Export ("searchDisplayControllerDidEndSearch:")]
		public void DidEndSearch(UISearchDisplayController controller)
		{
			tableViewController.TableView.Source = holdIndexedSource;
			// When search ends unhide original view's RH index
			tableViewController.TableView.ReloadData();
			ControllerHelpers.TitleCountUpdater(holdIndexedSource.GetItemCount());

		}
    }
}