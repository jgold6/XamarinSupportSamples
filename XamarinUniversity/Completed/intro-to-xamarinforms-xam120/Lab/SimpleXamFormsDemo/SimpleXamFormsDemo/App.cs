using System;
using Xamarin.Forms;
using System.Reflection;
using System.Linq;

namespace SimpleXamFormsDemo
{
    public class App
    {
        public static Page GetMainPage()
        {    
			return new XamarinHomePage();
        }
    }

	public class XamarinHomePage : ContentPage
	{
		public XamarinHomePage()
		{
			var ws = new UrlWebViewSource();
			ws.Url = "http://www.xamarin.com";

			var webView = new WebView();
			webView.Source = ws;

			Content = webView;
		}
	}


	public class CounterPage : ContentPage
	{
		public CounterPage() : base()
		{
			var theButton = new Button() {
				Text =  "Click me!"
			};

			int counter = 0;
			theButton.Clicked += (sender, e) => {
				theButton.Text = string.Format("Clicked {0} times", ++counter);
			};

			Content = theButton;
		}
	}

	public class AbsolutePageDemo : ContentPage
	{
		public AbsolutePageDemo()
		{
			var layout = new AbsoluteLayout();
			var box = new BoxView() {
				Color = Color.Blue,
				WidthRequest = 20,
				HeightRequest = 20
			};
			layout.Children.Add (box, new Point (0,0));

			layout.Children.Add (new BoxView() {Color= Color.Green }, 
				new Rectangle(1, 0, 20, 20), AbsoluteLayoutFlags.XProportional
			);

			layout.Children.Add (new BoxView() {Color= Color.Yellow }, 
				new Rectangle(0.5, 0.5, 0.5, 0.5), AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.SizeProportional
			);

			Content = layout;
		}
	}

	public class StackLayoutDemo : ContentPage
	{
		public StackLayoutDemo()
		{
			var layout = new StackLayout();

			Assembly core = typeof(Label).GetTypeInfo().Assembly;
			TypeInfo viewType = typeof(View).GetTypeInfo();

			foreach (var controlTypes in core.DefinedTypes.Where (viewType.IsAssignableFrom)) {
				layout.Children.Add(new Label() {
					Text = controlTypes.Name,
					HorizontalOptions = LayoutOptions.Center
				});
			}

			Content = new ScrollView(){ Content = layout};
		}
	}
}

