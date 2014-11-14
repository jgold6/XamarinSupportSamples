using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Xamarin.Forms;
using Forms2Native;

namespace Forms2Native.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = Forms2Native.App.GetMainPage().ConvertPageToUIElement(this);
        }

        protected override async void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            e.Cancel = true;
           System.Diagnostics.Debug.WriteLine("Back button pressed");
            if (Forms2Native.App.NavPage.CurrentPage.GetType() == typeof(Forms2Native.MyFirstPage))
            {
                System.Diagnostics.Debug.WriteLine("Don't go back");
            }
            else
            {
                await Forms2Native.App.NavPage.PopAsync();
            }
        }
    }
}
