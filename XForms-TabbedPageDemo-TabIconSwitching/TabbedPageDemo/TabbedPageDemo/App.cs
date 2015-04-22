using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using System.Diagnostics;

namespace TabbedPageDemo
{
    public class App
    {
        public static Page GetMainPage()
        {
			var tabbedPage = new TabbedPageDemoPage();

			tabbedPage.Appearing += (object sender, EventArgs e) => {
				SetIcons(tabbedPage);
			};

			tabbedPage.CurrentPageChanged += (object sender, EventArgs e) => {
				SetIcons(tabbedPage);	
			};
			return tabbedPage;
        }

		static void SetIcons(TabbedPage tabbedPage)
		{
			foreach (Page page in tabbedPage.Children) {
				if (page != tabbedPage.CurrentPage)
					page.Icon = "hollowstar.png";
			}
		}
    }
}
