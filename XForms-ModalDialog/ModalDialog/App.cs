using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ModalDialog
{
    public class App
    {
        public static Page GetMainPage()
        {    


			return new MyContentPage();
        }
    }

	public class MyContentPage : ContentPage
	{
		public MyContentPage()
		{
			// Dialog set up
			Label dialogLabel = new Label() {
				Text = "Popup Custom Dialog",
				TextColor = Color.Black
			};
			Entry dialogEntry = new Entry() {
				Placeholder = "Enter Text",
				TextColor = Color.Black
			};
			// Layout for dialog
			StackLayout dialog = new StackLayout() {
				Children = {dialogLabel, dialogEntry},
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				// Hide dialog
				IsVisible = false,
				BackgroundColor = Color.Silver,
				Padding = new Thickness(40)
			};


			// Page content set up
			Button btn = new Button
			{
				Text = "Click for Dialog",
			};
			Label lbl = new Label {
				Text = "Label for entry text"
			};
			// Layout for Page content
			StackLayout mainLayout = new StackLayout{
				Children = {btn, lbl},
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};


			// Absolute layout for page
			AbsoluteLayout absLayout = new AbsoluteLayout {
				Children = {mainLayout, dialog},
				Padding = new Thickness(40),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			// Position mainLayout
			AbsoluteLayout.SetLayoutFlags(mainLayout, AbsoluteLayoutFlags.XProportional);
			AbsoluteLayout.SetLayoutBounds(mainLayout, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			// Position dialog
			AbsoluteLayout.SetLayoutFlags(dialog, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(dialog, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

			Content = absLayout;


			// Handle button click to open dialog
			btn.Clicked += (object sender, EventArgs e) => {
				mainLayout.Opacity = 0.2;
				btn.IsEnabled = false;
				dialog.IsVisible = true;
			};

			// Handle Entry completed
			dialogEntry.Completed += (object sender, EventArgs e) => {
				lbl.Text = ((Entry)sender).Text;
				mainLayout.Opacity = 1.0;
				btn.IsEnabled = true;
				dialog.IsVisible = false;
			};
		}
	}
}

