using System;
using MonoTouch.UIKit;

namespace GreatQuotes
{
	partial class QuoteDetailViewController : UIViewController
	{
		GreatQuote quote;

		public QuoteDetailViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetQuote(GreatQuote value)
		{
			quote = value;
			UpdateView();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			UpdateView();

			// Adjust the font size.
			float size = 32;
			Quote.Font = UIFont.FromName("Helvetica-LightOblique", size);
			while (Quote.SizeThatFits(Quote.Frame.Size).Height >= Quote.Frame.Size.Height-10) {
				Quote.Font = UIFont.FromName("Helvetica-LightOblique", --size);
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var editButton = new UIBarButtonItem(UIBarButtonSystemItem.Edit, OnEditItem);
			NavigationItem.RightBarButtonItem = editButton;

			this.Quote.AddGestureRecognizer(new UITapGestureRecognizer(quote.SayQuote));
		}

		void OnEditItem(object sender, EventArgs e)
		{
			var editQuoteVC = (EditQuoteViewController) this.Storyboard.InstantiateViewController("EditQuote");
			editQuoteVC.SetQuote(quote);
			NavigationController.PushViewController(editQuoteVC, true);
		}

		void UpdateView()
		{
			if (IsViewLoaded && quote != null) {
				Author.Text = quote.Author;
				Quote.Text = "\"" + quote.Quote + "\"";
			}
		}
	}
}
