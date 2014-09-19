using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    public class App
    {
        public static Page GetMainPage()
        {
 
            return new NavigationPage (new ContentPage
            {
                Content = new Label
                {
                    Text = "Hello Forms!",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                },
            });
        }
    }
}
