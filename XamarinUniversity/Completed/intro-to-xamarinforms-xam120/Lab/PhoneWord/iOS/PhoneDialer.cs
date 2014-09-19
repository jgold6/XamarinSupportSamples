using System;
using Xamarin.Forms;
using PhoneWord.iOS;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

[assembly: Dependency(typeof(PhoneDialer))]

namespace PhoneWord.iOS
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

