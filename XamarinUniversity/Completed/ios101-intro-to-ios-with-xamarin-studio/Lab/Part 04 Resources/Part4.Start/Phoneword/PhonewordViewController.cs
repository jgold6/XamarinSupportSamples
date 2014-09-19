using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Core;

namespace Phoneword
{
	public partial class PhonewordViewController : UIViewController
	{
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
			CallButton.Enabled = false;

			string translatedNumber = "";
			TranslateButton.TouchUpInside += (sender, e) => 
			{
				translatedNumber = PhonewordTranslator.ToNumber(PhoneNumberText.Text);
				if (translatedNumber != null) {
					CallButton.SetTitle("Call " + translatedNumber, UIControlState.Normal);
					CallButton.Enabled = true;
				}
				else {
					CallButton.SetTitle("Call", UIControlState.Normal);
					CallButton.Enabled = false;
				}
			};

			PhoneNumberText.ShouldReturn += delegate { 
				PhoneNumberText.ResignFirstResponder();
				return true;
			};

			CallButton.TouchUpInside += delegate 
			{
				var alertPrompt = new UIAlertView("Dial Number?", 
					"Do you want to call " + translatedNumber + "?",
					null, "No", "Yes");

				alertPrompt.Dismissed += (sender, e) =>  {
					NSUrl url = new NSUrl("tel:" + translatedNumber);
					UIApplication.SharedApplication.OpenUrl(url);
				};

				alertPrompt.Show();
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

		#endregion
	}
}

