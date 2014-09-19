using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SearchSample
{
    public class GuidIndexedTableViewSource : UITableViewSource
    {
        private string[] _index;

        private const string CellIdentifier = "IndexedCell";

        public List<GuidIndexedDataItem> IndexedItems { get; set; }

        public GuidIndexedTableViewSource()
        {
            IndexedItems = SampleData.GetData();
			// Added
			IndexedItems = IndexedItems.OrderBy(x => x.T).ToList();
            _index = IndexedItems.OrderBy(x => x.T).Select(x => x.X).Distinct().ToArray();

            // Update title count
            ControllerHelpers.TitleCountUpdater(IndexedItems.Count);
        }

        /// <summary>
        /// Called by the TableView to determine how many sections(groups) there are.
        /// </summary>
        public override int NumberOfSections(UITableView tableView)
        {
            return _index.Length;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override int RowsInSection(UITableView tableView, int section)
        {
            return IndexedItems.Count(x => x.X == _index[section]);
        }

        /// <summary>
        /// Sections the index titles.
        /// </summary>
        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return _index;
        }

        /// <summary>
        /// Gets the header text for each section
        /// </summary>
        public override string TitleForHeader(UITableView tableView, int section)
        {
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

            cell.TextLabel.Text = IndexedItems.Where(x => x.X == _index[indexPath.Section]).ToList()[indexPath.Row].T;

            return cell;
        }

        public int GetItemCount()
        {
            return IndexedItems.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
			// Changed - fixed wrong item being shown in AlertView
			new UIAlertView("Row Selected In Table", IndexedItems.Where(x => x.X == _index[indexPath.Section]).ToList()[indexPath.Row].T, null, "OK", null).Show();
            tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
        }
    }
}