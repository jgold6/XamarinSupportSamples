using System;
using MonoTouch.UIKit;

namespace GreatQuotes
{
	partial class EditQuoteViewController : UIViewController
	{
		GreatQuote quote;

		public EditQuoteViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetQuote(GreatQuote value)
		{
			quote = value;
			UpdateView();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.Author.Ended += (sender, e) => {
				quote.Author = Author.Text;
			};

			this.Quote.Ended += (sender, e) => {
				quote.Quote = this.Quote.Text;
			};

			UpdateView();
		}

		void UpdateView()
		{
			if (IsViewLoaded && quote != null) {
				this.Author.Text = quote.Author;
				this.Quote.Text = quote.Quote;
			}
		}
	}
}
