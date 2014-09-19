using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Xamarin.AdoData.Droid.Adapters
{
    internal class StockAdapter : BaseAdapter<Core.Model.Stock>
    {
        private Activity context;
        public List<Core.Model.Stock> Stocks { get; private set; }

        public StockAdapter(Activity activity, IEnumerable<Core.Model.Stock> stocks)
        {
            context = activity;
            Stocks = new List<Core.Model.Stock>(stocks);
        }

        public override Core.Model.Stock this[int position]
        {
            get { return Stocks[position]; }
        }

        public override int Count
        {
            get { return Stocks.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var currentStockItem = this[position];

            var symbol = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var generatedId = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            symbol.Text = currentStockItem.Symbol;
            generatedId.Text = currentStockItem.Id.ToString(CultureInfo.InvariantCulture);

            return view;
        }
    }
}