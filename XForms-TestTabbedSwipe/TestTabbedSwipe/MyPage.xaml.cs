using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace TestTabbedSwipe
{    
	public partial class MyPage : TabbedPage
    {    


        public MyPage ()
        {
            InitializeComponent ();

			this.Appearing += (object sender, EventArgs e) => {
				Debug.WriteLine("OnAppearing");
				this.CurrentPage = this.Children[1];
			};
        }


    }
}

