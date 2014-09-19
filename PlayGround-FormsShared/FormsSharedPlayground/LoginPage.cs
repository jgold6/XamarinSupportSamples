using System;
using Xamarin.Forms;

namespace FormsSharedPlayground
{
	public class LoginPage : ContentPage
	{
		public LoginPage()
		{
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing (); 
			Title = "Sign in";
			Console.WriteLine(Title);
			UpdateChildrenLayout ();
			this.ForceLayout ();
		}
	}
}

