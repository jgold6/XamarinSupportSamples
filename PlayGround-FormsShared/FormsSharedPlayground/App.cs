using System;
using Xamarin.Forms;

namespace FormsSharedPlayground
{
	public class App
	{
		public static Page GetMainPage()
		{	
			LoginPage lp = new LoginPage();

			NavigationPage np = new NavigationPage(lp);

			Button btn = new Button(){
				Text = "Second Page"
			};
			btn.Clicked += (object sender, EventArgs e) => {
				lp.Title = "Sign out"; 
				np.PushAsync(new SecondPage(lp));
			};

			lp.Content = new StackLayout(){
				Children = {
					btn
				}
			};

			return np;
		}
	}
}
	