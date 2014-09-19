using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	public class FavoritesViewController : UITableViewController
	{
		List<Session> model;

		public FavoritesViewController ()
		{
			model = new List<Session> {
				new Session{ Title = "Keynote 1" }, new Session{ Title = "Keynote 2" },
				new Session{ Title = "Keynote 3" }, new Session{ Title = "Keynote 4" }
			};
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			Title = "Favorites";

			// TODO: Step 7a: uncomment to create the Edit button in the Navigation Bar
			NavigationItem.RightBarButtonItem = this.EditButtonItem;

			TableView.Source = new FavoritesTableViewSource (model);
		}

		class FavoritesTableViewSource : UITableViewSource
		{
			static readonly string favoriteSessionCellId = "FavoriteSessionCell";
			List<Session> sessions;

			public FavoritesTableViewSource (List<Session> sessions)
			{
				this.sessions = sessions;
			}

			public override int RowsInSection (UITableView tableview, int section)
			{
				return sessions.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (favoriteSessionCellId);
				
				if (cell == null)
					cell = new UITableViewCell (UITableViewCellStyle.Default, favoriteSessionCellId);

				cell.TextLabel.Text = sessions [indexPath.Row].Title;
				return cell;
			}

			// TODO: Step 7b: uncomment to enable editing within the table
			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				// This method allows you to adjust the model when you edit (Delete or Insert) a row

				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					sessions.RemoveAt (indexPath.Row);
					tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Middle);
				}
				if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Setup an add button or a special row in the table
					// use tableView.InsertRows(...);
					// Adjust the model to reflect that an insert has just happened
				}
			}



			// TODO: Step 7c: uncomment to disable Row Reorder "grab bars" control in 2nd row
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Controls if a row can be moved
				// Prevents the Row Reorder "grab bars" control from appearing in the 2nd row
				if (indexPath.Row == 1) {
					return false;
				}
				return true;
			}


			// This method is called by TableView when the row is moved in editing mode.
			// This method allows you to adjust the model when you move a row
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{ 
				Session s = sessions [sourceIndexPath.Row];
				sessions.RemoveAt (sourceIndexPath.Row);
				sessions.Insert (destinationIndexPath.Row, s);
			}
		}
	}
}
