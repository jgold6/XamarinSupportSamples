using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Drawing;

namespace SearchSample
{
    public class ParentViewController : UIViewController
    {
        private UISearchBar _searchBar;
        private UISearchDisplayController _searchController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "People";

            // This pushes the view below the navbar so they don't overlap.
            EdgesForExtendedLayout = UIRectEdge.None;

			// Changed from UITableViewController to UITableView
			var tableView = new UITableView(new RectangleF(0.0f, 20.0f, View.Frame.Width, View.Frame.Height));
			tableView.AutoresizingMask = UIViewAutoresizing.All;
			tableView.Source = new GuidIndexedTableViewSource();

            // This adds space at the top of the table to prevent the index headers overlapping with the search bar.
            var topInset = new UIEdgeInsets(24, 0, 0, 0);
			tableView.ContentInset = topInset;
			tableView.ScrollIndicatorInsets = topInset;

            _searchBar = new UISearchBar()
            {
                Placeholder = "Search",
                AutocorrectionType = UITextAutocorrectionType.No,
                AutocapitalizationType = UITextAutocapitalizationType.None,
            };
            _searchBar.SizeToFit();

			View.Add(tableView);
            View.Add(_searchBar);

			// Passing in this UIViewController
            _searchController = new UISearchDisplayController(_searchBar, this);

            _searchController.Delegate = new SearchDelegate();

			// To simplify a bit (I think) use the same Source. 
			// Use conditional in the Source to determine whether to display 
			// the full list or Search results instead.
			_searchController.SearchResultsSource = tableView.Source;



            //var searchTableViewSource = new GuidSearchedTableViewSource("", new List<GenericGuidIndexedItem>());
            //_searchController.SearchResultsSource = searchTableViewSource;

            //var searchDelegate = new SearchDelegate();
            //var searchTableViewSource = new GuidSearchedTableViewSource("", new List<GenericGuidIndexedItem>());
            //_searchController.Delegate = searchDelegate;
            //_searchController.SearchResultsSource = searchTableViewSource;
        }
    }

	// Although I liked the idea of the weak delegate in the last, admittedly poor, solution,
	// and it did help me achieve a working result, there is no need here as everytthing needed is in the Delegate class
    public class SearchDelegate : UISearchDisplayDelegate
    {
        public override void WillBeginSearch(UISearchDisplayController controller)
        {
			var source = controller.SearchResultsTableView.Source as GuidIndexedTableViewSource;
			source.FilterContentsForSearch("");
			source.searching = true;
			// No point as this implementation of the UISearchDisplayController obscures the Title.
			//ControllerHelpers.TitleCountUpdater(source.GetItemCount());
        }

        public override bool ShouldReloadForSearchString(UISearchDisplayController controller, string forSearchString)
        {
			var source = controller.SearchResultsTableView.Source as GuidIndexedTableViewSource;
			source.FilterContentsForSearch(forSearchString);
			//ControllerHelpers.TitleCountUpdater(source.GetItemCount());
            return true;
        }

		// Doesn't seem to be needed
//        public override void DidHideSearchResults(UISearchDisplayController controller, UITableView tableView)
//        {
//            // When search is cancelled set title count back to the original value
//            var searchContentsController = (TableViewController)controller.SearchContentsController;
//            var tvs = (GuidIndexedTableViewSource)searchContentsController.TableView.Source;
//            ControllerHelpers.TitleCountUpdater(tvs.GetItemCount());
//        }

        public override void DidEndSearch(UISearchDisplayController controller)
        {
			var source = controller.SearchResultsTableView.Source as GuidIndexedTableViewSource;
			source.searching = false;
			//ControllerHelpers.TitleCountUpdater(source.GetItemCount());
        }
    }
}