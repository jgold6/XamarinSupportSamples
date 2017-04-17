using System;
using CoreGraphics;
using System.Linq;
using Foundation;
using UIKit;

namespace doneButton.iPhone
{
	public class DoneButtonViewController : UIViewController
	{
		private UITextField _txtNumbers;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
                        Console.WriteLine("ViewDidLoad Called");
			View.BackgroundColor = UIColor.White;

			Title = "Done Button Example";

			var lbl = new UILabel (new CGRect (5, 30, 200, 20));
			lbl.Text = "Enter some numbers";
			lbl.Font = UIFont.SystemFontOfSize (12f);
			View.AddSubview (lbl);

			_txtNumbers = new UITextField (new CGRect (5, 50, 200, 20));
			_txtNumbers.KeyboardType = UIKeyboardType.NumberPad;
			_txtNumbers.BorderStyle = UITextBorderStyle.RoundedRect;


			// Add Done button
			UIToolbar keyboardToolbar = new UIToolbar ();
			keyboardToolbar.SizeToFit ();
			UIBarButtonItem flexBarButton = new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace, null, null);
			UIBarButtonItem doneBarButton = new UIBarButtonItem (UIBarButtonSystemItem.Done, this, new ObjCRuntime.Selector ("endEditing:"));
			keyboardToolbar.Items = new UIBarButtonItem[]{flexBarButton, doneBarButton};
			_txtNumbers.InputAccessoryView = keyboardToolbar;


			View.AddSubview (_txtNumbers);
		}

		[Export("endEditing:")]
		void EndEditing(NSObject sender)
		{
			// Do what you need to do
			Console.WriteLine("Done pressed");
			View.EndEditing (true);
		}

	}
}

