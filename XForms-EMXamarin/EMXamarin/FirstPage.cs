using System;
using Xamarin.Forms;
using System.Diagnostics;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EMXamarin {
	public class FirstPage : ContentPage {
		FirstPageModel model;

		Color[] colors;

		StackLayout boxes;
		StackLayout bottomLayout;

		int SQUARE_SIZE = 35;
		bool showingColorBoxes;

		public FirstPage () {
			model = new FirstPageModel ();
			model.AppBackgroundColorProperty = Color.Transparent;
			colors = new Color[]{ Color.Blue, Color.Red, Color.Green, Color.Yellow };

			WebView webview = new WebView {
				Source = new UrlWebViewSource {
					Url = "http://google.com",
					//Url = "https://www.youtube.com/watch?v=wM-2kf3bQK4",
					//Url = "http://youtu.be/wM-2kf3bQK4",
					//Url = "http://troygeddes.com/emintro.html",
				},
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			Button getStarted = new Button {
				Text = "Get Started!",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BackgroundColor = Color.Transparent,
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			boxes = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Center,
				Padding = 15,
				Spacing = 25,
			};

			getStarted.Clicked += async (object sender, EventArgs e) => {
				await boxes.FadeTo (0.0, 150, null);
				if (showingColorBoxes)
					AddMobileEmailButtons ();
				else
					AddColorBoxes ();
				await boxes.FadeTo (1.0, 150, null);
			};

			AddColorBoxes ();

			bottomLayout = new StackLayout {
				BackgroundColor = Color.Transparent,
				VerticalOptions = LayoutOptions.Fill,
				HorizontalOptions = LayoutOptions.Fill,
				Children = {
					getStarted,
					boxes,
				},
			};

			StackLayout stackLayout = new StackLayout {

				BackgroundColor = Color.Transparent,
				Children = {
					new Label {
						Text = "Welcome",
						Font = Font.BoldSystemFontOfSize (NamedSize.Large),
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Start
					},
					webview,
					bottomLayout,
				},
			};

			stackLayout.BindingContext = model;
			stackLayout.SetBinding (StackLayout.BackgroundColorProperty, "AppBackgroundColorProperty");

			// Accomodate iPhone status bar.
			//this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			Content = stackLayout;

			//var background = new Image { Aspect = Aspect.AspectFit };
			//background.Source = ImageSource.FromResource ("em.Images.bgBlue.jpg");
			//BackgroundImage = "Default.png";
		}

		private void AddColorBoxes () {
			boxes.Children.Clear ();
			showingColorBoxes = true;
			for (int i=0; i<colors.Length; i++) {
				Button colorButton = new Button {
					BackgroundColor = colors [i],
					BorderColor = Color.Black,
					BorderWidth = 1,
					HeightRequest = SQUARE_SIZE,
					WidthRequest = SQUARE_SIZE,
				};
				colorButton.Clicked += (object sender, EventArgs e) => {
					Debug.WriteLine ("{0} was pressed", colorButton.BackgroundColor.ToString());
					model.AppBackgroundColorProperty = ((Button)sender).BackgroundColor;
				};
				boxes.Children.Add (colorButton);
			}
		}

		private void AddMobileEmailButtons () {
			boxes.Children.Clear ();
			showingColorBoxes = false;
			Button mobileButton = new Button {
				BackgroundColor = Color.Accent,
				HeightRequest = SQUARE_SIZE,
				WidthRequest = SQUARE_SIZE,
			};

			Button emailButton = new Button {
				BackgroundColor = Color.Olive,
				HeightRequest = SQUARE_SIZE,
				WidthRequest = SQUARE_SIZE,
			};

			boxes.Children.Add (mobileButton);
			boxes.Children.Add (emailButton);

		}
	}


	public class FirstPageModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		Color _appBackgroundColorProperty;
		public Color AppBackgroundColorProperty {
			get { return _appBackgroundColorProperty; }
			set {
				if (value.Equals(_appBackgroundColorProperty)) {
					// Nothing to do - the value hasn't changed;
					return;
				}
				_appBackgroundColorProperty = value;
				OnPropertyChanged();
			}
		}

		void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			var handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}