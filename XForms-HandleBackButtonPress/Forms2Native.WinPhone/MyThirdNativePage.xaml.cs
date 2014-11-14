using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Forms2Native.WinPhone
{
    public partial class MyThirdNativePage : PhoneApplicationPage
    {
        public MyThirdNativePage()
        {
            InitializeComponent();
            //BackKeyPress += MyThirdNativePage_BackKeyPress;
        }

        //void MyThirdNativePage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //    System.Diagnostics.Debug.WriteLine("Back button 3 pressed");
        //}

        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    //e.Cancel = true;
        //    System.Diagnostics.Debug.WriteLine("OnBackKeyPress Third Native Page pressed");
        //}
    }
}