using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestXAMLWebViewTabbed
{
	public partial class XAMLScaleAndRotation : ContentPage
    {
        public XAMLScaleAndRotation()
        {
            InitializeComponent();
			label.Scale = 4;
        }
    }

	public class MyLabel : Label {}
}
