using System;
using Xamarin.Forms;

namespace PhoneWord
{
	// IDialer.cs
	public interface IDialer
	{
		bool Dial(string number);
	}
		
    public class App
    {
        public static Page GetMainPage()
        {    
			return new PhoneWordPage();
            
        }
    }

	public class PhoneWordPage : ContentPage
	{
		string translatedNumber;

		public PhoneWordPage () 
		{
			var layout = new StackLayout() {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Spacing = 15,
				Padding= new Thickness(20, 40, 20, 20)
			};

			var label = new Label() {
				Text = "Enter a Phoneword:"
			};

			var entry = new Entry() {
				Text = "1-855-XAMARIN"
			};
			var btnTranslate = new Button() {
				Text = "Translate"
			};

			var btnCall = new Button() {
				Text = "Call: ",
				IsEnabled = false
			};

			layout.Children.Add(label);
			layout.Children.Add(entry);
			layout.Children.Add(btnTranslate);
			layout.Children.Add(btnCall);

			Content = layout;

			btnTranslate.Clicked += (sender, e) => {
				translatedNumber = Core.PhonewordTranslator.ToNumber(entry.Text);
				if (!string.IsNullOrEmpty(translatedNumber)) {
					btnCall.IsEnabled = true;
					btnCall.Text = "Call " + translatedNumber;
				} else {
					btnCall.IsEnabled = false;
					btnCall.Text = "Call";
				}
			};

			btnCall.Clicked += async (sender, e) => {
				if (await this.DisplayAlert(
					"Dial a Number",
					"Would you like to call " + translatedNumber + "?",
					"Yes",
					"No")) {

					var dialer = DependencyService.Get<IDialer>();
					if (dialer != null) {
						dialer.Dial(translatedNumber);
					}
				}
			};
		}
	}
}

