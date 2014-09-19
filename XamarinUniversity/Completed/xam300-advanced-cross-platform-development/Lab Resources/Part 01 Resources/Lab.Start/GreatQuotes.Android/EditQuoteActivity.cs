using Android.App;
using Android.OS;
using Android.Widget;
using GreatQuotes.Data;

namespace GreatQuotes
{
	[Activity(Label = "@string/edit_quote")]			
	public class EditQuoteActivity : Activity
	{
		int quoteIndex;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			quoteIndex = Intent.Extras.GetInt("quoteIndex");
			var quote = QuoteManager.Instance.Quotes[quoteIndex];

			SetContentView(Resource.Layout.EditQuote);

			TextView quoteText = FindViewById<TextView>(Resource.Id.quoteText);
			TextView authorText = FindViewById<TextView>(Resource.Id.authorText);

			quoteText.Text = quote.Quote;
			authorText.Text = quote.Author;

			quoteText.TextChanged += (sender, e) => {
				quote.Quote = quoteText.Text;
			};

			authorText.TextChanged += (sender, e) => {
				quote.Author = authorText.Text;
			};
		}

		protected override void OnPause()
		{
			base.OnPause();
			QuoteManager.Instance.Save();
		}
	}
}

