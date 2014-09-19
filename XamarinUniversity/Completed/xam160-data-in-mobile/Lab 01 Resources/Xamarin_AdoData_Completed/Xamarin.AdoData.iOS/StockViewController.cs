using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace Xamarin.AdoData.iOS
{
    public class StockViewController : UITableViewController
    {
        private StocksTableSource source;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Xamarin ADO Data";

            RefreshControl = new UIRefreshControl();
            RefreshControl.ValueChanged += async (sender, e) =>
            {
                //TODO: Step 6b - iOS - query database
                await LoadStockDataAsync();
                RefreshControl.EndRefreshing();
            };

            source = new StocksTableSource(Enumerable.Empty<Core.Model.Stock>());
            TableView.Source = source;
        }

        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //TODO: Step 6a - iOS - Setup the database and query
            var adoDatabase = new Core.Ado.StockDatabase();
            await adoDatabase.CreateDatabaseIfNotExistsAsync();
			await LoadStockDataAsync();
        }

        //TODO: Step 5 - iOS - Integrate the ADO.Net client into your UI
        private async Task LoadStockDataAsync()
        { 
            var adoDatabase = new Core.Ado.StockDatabase();
        
            //Generate some sample stock items
            for (var i = 0; i < 5; i++)
                await adoDatabase.InsertStockAsync(Core.StockHelper.GenerateStock()/* Generates a fake stock */);
            
            var stocks = await adoDatabase.SelectStockAsync();
        
            source.Stocks.AddRange(stocks);
            TableView.ReloadData();
        }

        class StocksTableSource : UITableViewSource
        {
            private const string stockCellId = "StockCell";

            public readonly List<Core.Model.Stock> Stocks;

            public StocksTableSource(IEnumerable<Core.Model.Stock> stocks)
            {
                this.Stocks = new List<Core.Model.Stock>(stocks);
            }

            public override int RowsInSection(UITableView tableview, int section)
            {
                return Stocks.Count;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var stock = Stocks[indexPath.Row];

                new UIAlertView("Stock Selected", stock.Symbol, null, "OK", null).Show();

                tableView.DeselectRow(indexPath, true);
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(stockCellId) 
                    ?? new UITableViewCell(UITableViewCellStyle.Subtitle, stockCellId);

                var stock = Stocks[indexPath.Row];

                cell.TextLabel.Text = stock.Symbol;
                cell.DetailTextLabel.Text = stock.Id.ToString(CultureInfo.InvariantCulture);

                return cell;
            }
        }
    }
}