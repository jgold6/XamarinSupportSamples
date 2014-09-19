using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Globalization;

namespace SearchSample
{
    public class GuidIndexedTableViewSource : UITableViewSource
    {
        private string[] _index;

        private const string CellIdentifier = "IndexedCell";

        public List<GuidIndexedDataItem> IndexedItems {get; set;}
		// Added to hold search results
		public List<GuidIndexedDataItem> SearchResults {get; set;}
		// Added to easily keep track of  and test for search status
		public bool searching = false;

        public GuidIndexedTableViewSource()
        {
            IndexedItems = SampleData.GetData();
            _index = IndexedItems.OrderBy(x => x.T).Select(x => x.X).Distinct().ToArray();
			SearchResults = new List<GuidIndexedDataItem>();
            // Update title count
            ControllerHelpers.TitleCountUpdater(IndexedItems.Count);
        }

		// Moved from GuidSearchTableViewSource
		public void FilterContentsForSearch(string searchText)
		{
			var culture = CultureInfo.InvariantCulture;
			SearchResults = IndexedItems.OrderBy(x => x.T).Where(x => culture.CompareInfo.IndexOf(x.T, searchText, CompareOptions.IgnoreCase) >= 0).ToList();
		}

		// Added conditionals to all of the methods to return appropriate results. 
        /// <summary>
        /// Called by the TableView to determine how many sections(groups) there are.
        /// </summary>
        public override int NumberOfSections(UITableView tableView)
        {
			if (searching)
				return 1;
			else 
	            return _index.Length;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override int RowsInSection(UITableView tableView, int section)
        {
			if (searching)
				return SearchResults.Count;
			else
	            return IndexedItems.Count(x => x.X == _index[section]);
        }

        /// <summary>
        /// Sections the index titles.
        /// </summary>
        public override string[] SectionIndexTitles(UITableView tableView)
        {
			if (searching)
				return null;
			else
	            return _index;
        }

        /// <summary>
        /// Gets the header text for each section
        /// </summary>
        public override string TitleForHeader(UITableView tableView, int section)
        {
			if (searching)
				return "Search Results";
			else
	            return _index[section];
        }

        public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            // Request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            // If there are no cells to reuse, create a new one
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

			if (searching)
				cell.TextLabel.Text = SearchResults[indexPath.Row].T;//[indexPath.Row].T;
			else
            	cell.TextLabel.Text = IndexedItems.Where(x => x.X == _index[indexPath.Section]).ToList()[indexPath.Row].T;

            return cell;
        }

        public int GetItemCount()
        {
			if (searching)
				return SearchResults.Count;
			else
	            return IndexedItems.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
			if (searching) {
				new UIAlertView("Row Selected In Table", SearchResults[indexPath.Row].T, null, "OK", null).Show();
				tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
			}
			else {
				new UIAlertView("Row Selected In Table", IndexedItems.Where(x => x.X == _index[indexPath.Section]).ToList()[indexPath.Row].T, null, "OK", null).Show();
	            tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
			}
        }
    }
}