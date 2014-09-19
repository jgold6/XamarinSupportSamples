using Android.App;
using Android.OS;
using Android.Content;
using Android.Views;
using GreatQuotes.Data;

namespace GreatQuotes
{
	[Activity(MainLauncher = true)]
	public class QuoteListActivity : ListActivity
	{
		ListAdapter<GreatQuote> adapter;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			adapter = new ListAdapter<GreatQuote>(this) {
				DataSource = QuoteManager.Instance.Quotes,
				TextProc = t => t.Quote, 
				DetailTextProc = t => t.Author,
			};

			this.ListAdapter = adapter;
		}

		protected override void OnResume()
		{
			base.OnResume();
			adapter.Refresh();
		}

		protected override void OnListItemClick(Android.Widget.ListView l, Android.Views.View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);

			Intent detailIntent = new Intent(this, typeof(QuoteDetailActivity));
			detailIntent.PutExtra("quoteIndex", position);
			StartActivity(detailIntent);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.mainOptions, menu);

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.new_quote:
					var quote = new GreatQuote();
					QuoteManager.Instance.Quotes.Add(quote);
					Intent detailIntent = new Intent(this, typeof(EditQuoteActivity));
					detailIntent.PutExtra("quoteIndex", QuoteManager.Instance.Quotes.Count-1);
					StartActivity(detailIntent);					
					break;
			}

			return base.OnOptionsItemSelected(item);
		}
	}
}


