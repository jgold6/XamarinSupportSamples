using System;
using Xamarin.Forms;

namespace FormsSharedPlayground
{
	public class SecondPage : ContentPage
	{
		LoginPage loginPage;
		public SecondPage(LoginPage lp)
		{
			this.loginPage = lp;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing (); 
			this.Title = "Signed In";
			//loginPage.Title = "Sign in"; // Doesn't set the LoginPage title
			UpdateChildrenLayout ();
			this.ForceLayout ();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			//loginPage.Title = "Sign in"; // Doesn't set the LoginPage title
		}
	}
}

