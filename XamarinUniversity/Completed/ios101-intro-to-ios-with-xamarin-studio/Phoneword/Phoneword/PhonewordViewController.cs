using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Core;
using System.Collections.Generic;

namespace Phoneword
{
	public partial class PhonewordViewController : UIViewController
	{
		string phoneNumber;
		string translatedNumber;
		List<string> calledNumbers = new List<string>();

		public PhonewordViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			PhoneNumberText.ShouldReturn += delegate {
				PhoneNumberText.ResignFirstResponder();
				return true;
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			this.View.EndEditing(true);
		}

		partial void TranslateButton_TouchUpInside(UIButton sender)
		{
			phoneNumber = PhoneNumberText.Text;
			translatedNumber = PhonewordTranslator.ToNumber(phoneNumber);
//			if (translatedNumber.Length == 13)
				CallButton.Enabled = true;
//			else
//				CallButton.Enabled = false;
			CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
		}

		partial void CallButton_TouchUpInside(UIButton sender)
		{
			UIAlertView av = new UIAlertView("Call?", "Do you want to call " + translatedNumber, null, "No", "Yes", "Maybe");
			av.Dismissed += (object sender2, UIButtonEventArgs e) => {
				switch (e.ButtonIndex) {
					case 0:
						Console.WriteLine("No");
						break;
					case 1:
						Console.WriteLine("Yes");
						NSUrl url = new NSUrl("tel:"+translatedNumber);
						if (UIApplication.SharedApplication.CanOpenUrl(url)) {
							UIApplication.SharedApplication.OpenUrl(url);
						}
						calledNumbers.Add(translatedNumber);
						break;
					case 2:
						Console.WriteLine("Maybe");
						break;
					default:
						break;
				}
			};
			av.Show();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			CallHistoryController chc = segue.DestinationViewController as CallHistoryController;
			chc.PhoneNumbers = calledNumbers;
		}
		#endregion
	}
}

