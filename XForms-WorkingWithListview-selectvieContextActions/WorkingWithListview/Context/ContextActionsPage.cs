using System;

using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace WorkingWithListview
{
	/// <summary>
	/// Demonstrates the new ContextActions property introduced in Xamarin.Forms 1.3
	/// </summary>
	public class ContextActionsPage : ContentPage
	{
		public static ObservableCollection<string> items;

		public ContextActionsPage ()
		{
			var listView = new MyListView ();

			ContextActionsPage.items = new ObservableCollection<string>(){"alpha", "beta", "gamma", "delta", "epsilon", "phi", "pi", "omega", "lambda", "nu", "mu", "kappa", "theta", "iota", "zulu", "nulu", "etc", "etcetc", "etcetcetc"};

			listView.ItemsSource = ContextActionsPage.items;
			listView.ItemTemplate = new DataTemplate(typeof(ContextActionsCell)); // has context actions defined

			// Using ItemTapped
			listView.ItemTapped += async (sender, e) => {
				Debug.WriteLine("Tapped: " + e.Item);
				await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
				((ListView)sender).SelectedItem = null; // de-select the row
			};

				
			Padding = new Thickness (0,20,0,0);
			Content = listView;
		}
	}

	public class MyListView : ListView
	{
		protected override void SetupContent(Cell content, int index)
		{
			base.SetupContent(content, index);
			ContextActionsCell cell = (ContextActionsCell)content;

			//
			// define context actions
			//
			if (cell.Label1.Text != "beta") {
				var moreAction = new MenuItem { Text = "More" };
				moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
				moreAction.Clicked += async (sender, e) => {
					var mi = ((MenuItem)sender);
					Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
				};

				var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
				deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
				deleteAction.Clicked += async (sender, e) => {
					var mi = ((MenuItem)sender);
					Debug.WriteLine("Delete Context Action clicked: " + mi.CommandParameter);
					ContextActionsPage.items.Remove((string)mi.CommandParameter);
				};

				//
				// add context actions to the cell
				//
				cell.ContextActions.Add (moreAction);
				cell.ContextActions.Add (deleteAction);
			}

		}
	}
}


