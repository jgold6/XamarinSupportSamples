using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestXAMLWebViewTabbed
{
	public partial class XAMLHslPage : ContentPage
    {
        public XAMLHslPage()
        {
            InitializeComponent();

			this.BindingContext = new HslViewModel() {Color = Color.Purple};
        }

    }
}
