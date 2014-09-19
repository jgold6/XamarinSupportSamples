using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GreatQuotes
{
	public partial class QuoteListViewController : UITableViewController
	{
		public QuoteListViewController(IntPtr handle) : base(handle)
		{
		}

		void AddNewItem(object sender, EventArgs args)
		{
			var quote = new GreatQuote();
			QuoteManager.Instance.Quotes.Insert(0, quote);

			using (var indexPath = NSIndexPath.FromRowSection(0, 0)) {
				TableView.InsertRows(new [] { indexPath }, UITableViewRowAnimation.Automatic);
			}

			var editQuoteVC = (EditQuoteViewController) this.Storyboard.InstantiateViewController("EditQuote");
			editQuoteVC.SetQuote(quote);
			NavigationController.PushViewController(editQuoteVC, true);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.LeftBarButtonItem = EditButtonItem;

			var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
			NavigationItem.RightBarButtonItem = addButton;

			TableView.Source = new TableViewSource<GreatQuote>(TableView, "QuoteCell") { 
				Items = QuoteManager.Instance.Quotes,
				CanEditRowFunc = delegate { return true; },
				GetCellFunc = (t,cell) => {
					cell.TextLabel.Text = t.Quote;
					cell.DetailTextLabel.Text = t.Author;
					return cell;
				}
			};
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			TableView.ReloadData();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showDetail") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = QuoteManager.Instance.Quotes[indexPath.Row];

				((QuoteDetailViewController)segue.DestinationViewController).SetQuote(item);
			}
		}
	}
}

