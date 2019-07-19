using System;
using System.Collections.Generic;
using MVVMListAndDetailExample.ViewModels;
using Xamarin.Forms;

namespace MVVMListAndDetailExample.Views
{
    public partial class PersonDetailPage : ContentPage
    {
        public static PersonViewModel BindingContextDummyInstance { get; set; } = null;

        public PersonDetailPage(ViewModels.PersonViewModel personViewModel)
        {
            InitializeComponent();
            BindingContext = personViewModel;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
