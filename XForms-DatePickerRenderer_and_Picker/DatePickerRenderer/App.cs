using System;
using Xamarin.Forms;

namespace DatePickerRenderer
{
	public class App
	{
		public static Page GetMainPage()
		{	
			return new NavigationPage(new DatePickerDemoPage());
			
		}
	}
}

