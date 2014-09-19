using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ActionSheetTest
{
    public class App
    {
        static ContentPage contentPage = null;
        public static Page GetMainPage()
        {

            Button btn = new Button
            {
                Text = "Display ActionSheet"
            };

            btn.Clicked += btn_Clicked;

            if (contentPage == null)
            {
                contentPage = new ContentPage()
                {
                    Content = btn
                };
            }
        

            return new NavigationPage(contentPage);
        }

        public static async void btn_Clicked(object sender, EventArgs e)
        {
            string x = await contentPage.DisplayActionSheet("Action Sheet", "Cancel", null, new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "Eleven", "twelve", "thirteen", "fourteen" });
            Debug.WriteLine("Selected: {0}", x);
        }
    }
}
