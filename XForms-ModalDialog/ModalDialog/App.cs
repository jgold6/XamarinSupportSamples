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
				Padding = new Thickness(40),
				Opacity = 0.0
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
			btn.Clicked += async (object sender, EventArgs e) => {
				await mainLayout.FadeTo(0.4, 150, Easing.Linear);
				btn.IsEnabled = false;
				dialog.IsVisible = true;
				await dialog.FadeTo(1.0, 150, Easing.Linear);
			};

			// Handle Entry completed
			dialogEntry.Completed += async (object sender, EventArgs e) => {
				await mainLayout.FadeTo(1.0, 150, Easing.Linear);
				lbl.Text = ((Entry)sender).Text;
				btn.IsEnabled = true;
				await dialog.FadeTo(0.0, 150, Easing.Linear);
				dialog.IsVisible = false;
			};
		}
	}
}

