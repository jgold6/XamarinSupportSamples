using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestXAMLWebViewTabbed
{
    public partial class XAMLWebViewPage 
    {
        public XAMLWebViewPage()
        {
            InitializeComponent();
            
        }
        void OnSliderValueChanged(object sender,
                                  ValueChangedEventArgs args)
        {
            var slider = (Slider)sender;
            Debug.WriteLine(slider.Value.ToString("F3"));
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            var button = (Button)sender;
            await DisplayAlert("Clicked", "Congratulations, you have clicked the button labeled " + button.Text, "Who cares.", button.Text);
        }

    }
}
