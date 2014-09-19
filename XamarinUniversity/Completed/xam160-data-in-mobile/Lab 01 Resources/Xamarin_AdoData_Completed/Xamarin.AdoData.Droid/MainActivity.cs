using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;

namespace Xamarin.AdoData.Droid
{
    [Activity(Label = "Xamarin ADO Data", MainLauncher = true)]
    public class MainActivity : ListActivity
    {
        private Adapters.StockAdapter adapter;
        private IMenuItem loadDataMenuItem;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.list_with_spinner);

            adapter = new Adapters.StockAdapter(this, Enumerable.Empty<Core.Model.Stock>());
            ListAdapter = adapter;
        }

        protected override async void OnResume()
        {
            base.OnResume();

			// TODO: Step 6a - Android - Setup the database and query
			var adoDatabase = new Core.Ado.StockDatabase();
			await adoDatabase.CreateDatabaseIfNotExistsAsync();
			await LoadStockDataAsync ();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.primary_menu, menu);
            loadDataMenuItem = menu.GetItem(0);

            return base.OnCreateOptionsMenu(menu);
        }

		protected override void OnListItemClick(Android.Widget.ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			var stock = adapter[position];

			var adb = new AlertDialog.Builder(this);
			adb.SetNegativeButton("OK", delegate {});
			adb.SetTitle("Stock Selected");
			adb.SetMessage(stock.ToString());
			adb.Show();
		}

		public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.ItemId)
            {
				case Resource.Id.action_refresh:
				    //TODO: Step 6b - Android - query database
					LoadStockDataAsync();
				    break;
            }

            return base.OnMenuItemSelected(featureId, item);
        }

		//TODO: Step 5 - Android - Integrate the ADO.Net client into your UI
		private async Task LoadStockDataAsync()
		{
		    try
		    {
		        if (loadDataMenuItem != null)
		            loadDataMenuItem.SetEnabled(false);
		       
		        var adoDatabase = new Core.Ado.StockDatabase();

		        //Generate some sample stock items
		        for (var i = 0; i < 5; i++)
		            await adoDatabase.InsertStockAsync(Core.StockHelper.GenerateStock() /* Generates a fake stock */);

		        var stocks = await adoDatabase.SelectStockAsync();

		        adapter.Stocks.AddRange(stocks);
		        adapter.NotifyDataSetChanged();
		    }
		    finally
		    {
		        if (loadDataMenuItem != null)
		            loadDataMenuItem.SetEnabled(true);
		    }
		}
    }
}