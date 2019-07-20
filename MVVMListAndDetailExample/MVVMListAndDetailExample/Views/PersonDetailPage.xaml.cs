using System;
using System.Collections.Generic;
using MVVMListAndDetailExample.ViewModels;
using Xamarin.Forms;

namespace MVVMListAndDetailExample.Views
{
    public partial class PersonDetailPage : ContentPage
    {
        public static PersonViewModel BindingContextInstance { get; set; } = null;

        public PersonDetailPage(ViewModels.PersonViewModel personViewModel)
        {
            BindingContextInstance = personViewModel;
            InitializeComponent();            
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
