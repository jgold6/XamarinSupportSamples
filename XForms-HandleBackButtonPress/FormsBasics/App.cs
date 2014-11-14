using System;
using Xamarin.Forms;

namespace Forms2Native
{
	public static class App
	{

        public static NavigationPage NavPage {get; private set;}
		public static Page GetMainPage ()
		{
            NavPage = new NavigationPage(new MyFirstPage());
			var mainNav = NavPage;

           
			return mainNav;
		}
	}

}