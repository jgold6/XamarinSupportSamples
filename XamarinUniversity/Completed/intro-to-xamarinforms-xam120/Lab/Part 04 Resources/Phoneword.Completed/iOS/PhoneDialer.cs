using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Phoneword.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace Phoneword.iOS
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
        }
    }
}
