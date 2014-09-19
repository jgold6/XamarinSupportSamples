using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreTelephony;

namespace telephonytest
{
	public partial class telephonytestViewController : UIViewController
	{
		CTTelephonyNetworkInfo networkInfo;
		CTCallCenter callCenter;
		string carrierName;
		CTCall[] calls = new CTCall [0];

		public telephonytestViewController() : base("telephonytestViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			networkInfo = new CTTelephonyNetworkInfo ();
			callCenter = new CTCallCenter ();
			callCenter.CallEventHandler += CallEvent;
			carrierName = networkInfo.SubscriberCellularProvider == null ? null : networkInfo.SubscriberCellularProvider.CarrierName;

			// Perform any additional setup after loading the view, typically from a nib.
			// using telprompt...
			callBtn.TouchUpInside += (object sender, EventArgs e) => {
				if (UIApplication.SharedApplication.CanOpenUrl (new NSUrl ("telprompt://" + "5415055241"))) {
					UIApplication.SharedApplication.OpenUrl (new NSUrl ("telprompt://" + "5415055241"));
				} else {
					UIAlertView messageBox = new UIAlertView ("No phone", "", null, "Ok", null);
					messageBox.Show ();
				}
			};

			// Using tel instead of telprompt
//			callBtn.TouchUpInside += (object sender, EventArgs e) => {
//				if (UIApplication.SharedApplication.CanOpenUrl (new NSUrl ("tel://" + "5415055241"))) {
//					UIApplication.SharedApplication.OpenUrl (new NSUrl ("tel://" + "5415055241"));
//				} else {
//					UIAlertView messageBox = new UIAlertView ("No phone", "", null, "Ok", null);
//					messageBox.Show ();
//				}
//			};


		}

		private void CallEvent (CTCall inCTCall)
		{
			Console.WriteLine("Call event: " + inCTCall.CallState);
			InvokeOnMainThread (delegate {  
				callLabel.Text = "Call event: " + inCTCall.CallState;  
			});
		}
	}
}




























