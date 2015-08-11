using System;

using Xamarin.Forms;

namespace ResxLocalizationPCLSharedCombo
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = ResxLocalizationPCLResx.AppResources.Welcome
						},
						new Label {
							XAlign = TextAlignment.Center,
							Text = ResxLocalizationPCLResx.AppResources.Text
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

