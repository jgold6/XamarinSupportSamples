using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Threading;

namespace FormsPlayground
{
	public class App
	{
		static Picker monthPicker;
		static Picker yearPicker;

		public static Page GetMainPage()
		{	
		
//			return new Search();

			monthPicker = new Picker() {
				Title = DateTime.Now.ToString("MMMM")
			};
					
			yearPicker = new Picker() {
				Title = DateTime.Now.ToString("yyyy")
			};

			Task.Run(async () => {
				await Task.Delay(10000);

			}).ContinueWith(task => {
				Dictionary<int, string> months = new Dictionary<int, string>();

				for (int i = 0; i< 12; i++) {
					months.Add(DateTime.Now.AddMonths(i).Month, DateTime.Now.AddMonths(i).ToString("MMMM"));
				}

				foreach (string month in months.Values)
				{
					monthPicker.Items.Add(month);
				};

				Dictionary<int, string> years = new Dictionary<int, string>();

				for (int i = 0; i< 50; i++) {
					years.Add(DateTime.Now.AddYears(i).Year, DateTime.Now.AddYears(i).ToString("yyyy"));
				}

				foreach (string year in years.Values)
				{
					yearPicker.Items.Add(year);
				};
			}, TaskScheduler.FromCurrentSynchronizationContext ()); //, TaskScheduler.FromCurrentSynchronizationContext ()

			Debug.WriteLine("Delay");

			return new ContentPage
			{ 
				BackgroundColor = Color.White,
				Content = new StackLayout() {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Padding = new Thickness(0.0, 30.0, 0.0, 0.0),

					Children = {
						new MySearchBar() {
							Placeholder = "Search Placeholder",
						},
						new Label {
							Text = "Why not?",
							TextColor = Color.Green,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
							VerticalOptions = LayoutOptions.Center,
						},
						new MyEntry() 
						{
							Placeholder = "Enter text",
							VerticalOptions = LayoutOptions.Center,
							HorizontalOptions = LayoutOptions.CenterAndExpand,
							WidthRequest = 300.0
						},
						new MyDatePicker()
						{
							Date = DateTime.Now
						},
						monthPicker,
						yearPicker
					}
				}

			};				
		}
	}

	public partial class Search : ContentPage {

		public Search ()
		{

			MyWebView webView = new MyWebView();
			webView.Source = "http://www.example.com";
			this.Content = webView;
		}
	}

	public class MyWebView : WebView {}

	public class MyEntry : Entry {}

	public class MySearchBar : SearchBar {}

	public class MyDatePicker : DatePicker {}


}

