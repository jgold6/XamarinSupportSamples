using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Globalization;

namespace SearchSample
{
    public class GuidSearchTableViewSource : UITableViewSource
    {
        private const string CellIdentifier = "IndexedCell";

		// Changed
        private List<GuidIndexedDataItem> _indexedItems;

        public GuidSearchTableViewSource(string filter, List<GuidIndexedDataItem> indexedItems)
        {
			// Changed
			UpdateData(filter, indexedItems);
        }

		public void UpdateData(string filter, List<GuidIndexedDataItem> indexedItems)
		{
			// Case and culture in-sensitive filter
			var culture = CultureInfo.InvariantCulture;
			_indexedItems = indexedItems.Where(x => culture.CompareInfo.IndexOf(x.T, filter, CompareOptions.IgnoreCase) >= 0).ToList();

			// Update title count
			ControllerHelpers.TitleCountUpdater(_indexedItems.Count);
		}

		/// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override int RowsInSection(UITableView tableView, int section)
        {
            return _indexedItems.Count;
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

            cell.TextLabel.Text = _indexedItems[indexPath.Item].T;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            new UIAlertView("Row Selected In Search", _indexedItems[indexPath.Item].T, null, "OK", null).Show();
            tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
        }
    }
}