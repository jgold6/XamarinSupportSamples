using System;

using Xamarin.Forms;

namespace TestShadingiOSDetailPage
{
    public class App : Application
    {
		MasterDetailPage mdPage;
		Color origContentBgColor;
		Color origPageBgColor;

        public App()
        {
			mdPage = new MasterDetailPage();
			mdPage.IsPresentedChanged += async (object sender, EventArgs e) => {
				if (Device.OS == TargetPlatform.iOS) {
					if (mdPage.IsPresented) {
						var currentPage = (DetailPage)((NavigationPage)mdPage.Detail).CurrentPage;
						origPageBgColor = currentPage.BackgroundColor;
						origContentBgColor = currentPage.Content.BackgroundColor;

						currentPage.BackgroundColor = Color.Black;
						currentPage.Content.FadeTo(0.5);
						if (currentPage.Content.BackgroundColor == Color.Default) {
							currentPage.Content.BackgroundColor = Color.White;

						}
					}
					else {
						var currentPage = (DetailPage)((NavigationPage)mdPage.Detail).CurrentPage;
						currentPage.BackgroundColor = origPageBgColor;
						currentPage.Content.BackgroundColor = origContentBgColor;
						currentPage.Content.FadeTo(1.0);
					}


				}
			};
			mdPage.Master = new MasterPage(){Title = "Master Page"};
			mdPage.Detail = new NavigationPage( new DetailPage());

            // The root page of your application
			MainPage = mdPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

	public class MasterPage : ContentPage
	{
		public MasterPage() {
			Content = new TableView {
				BackgroundColor = Color.Black
			};
		}
	}

	public class DetailPage : ContentPage
	{
		public DetailPage() {
			Content = new StackLayout {
				BackgroundColor = Color.Green,
				Children = {new Label {Text = "Hi There!"}}
			};
		}
	}
}

