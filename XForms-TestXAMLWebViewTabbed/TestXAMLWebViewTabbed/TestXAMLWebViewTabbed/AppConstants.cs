using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestXAMLWebViewTabbed
{
    static class AppConstants
    {
        public static readonly Thickness PagePadding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10);

        public static readonly Font TitleFont = Font.BoldSystemFontOfSize(Device.OnPlatform(35, 40, 50));

        public static readonly Color BackgroundColor =
            Device.OnPlatform(Color.Red, Color.White, Color.Blue);

        public static readonly Color TextColor =
            Device.OnPlatform(Color.Blue, Color.Red, Color.White);



    }
}
