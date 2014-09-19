using Xamarin.Forms;

namespace Phoneword
{
	public class MainPage : ContentPage
	{
		Entry phoneNumberText;
		Button translateButton;
		Button callButton;
		string translatedNumber = "";

		public MainPage()
		{
			this.Padding = new Thickness(20, Device.OnPlatform(40, 20, 20), 20, 20);

			StackLayout panel = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Spacing = 15,
			};

			panel.Children.Add(new Label {
				Text = "Enter a Phoneword:",
			});

			panel.Children.Add(phoneNumberText = new Entry {
				Text = "1-855-XAMARIN",
			});

			panel.Children.Add(translateButton = new Button {
				Text = "Translate"
			});

			panel.Children.Add(callButton = new Button {
				Text = "Call",
				IsEnabled = false,
			});

			translateButton.Clicked += OnTranslate;

			this.Content = panel;
		}

		void OnTranslate(object sender, System.EventArgs e)
		{
			translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
			if (!string.IsNullOrEmpty(translatedNumber)) {
				callButton.IsEnabled = true;
				callButton.Text = "Call " + translatedNumber;
			} else {
				callButton.IsEnabled = false;
				callButton.Text = "Call";
			}

		}
	}
}
