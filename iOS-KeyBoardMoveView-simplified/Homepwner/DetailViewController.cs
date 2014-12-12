using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace Homepwner
{
	public partial class DetailViewController : UIViewController, IUITextFieldDelegate
	{

		RectangleF viewRect;
		RectangleF keyTextFieldRect;
		RectangleF altKeyTextFieldRect;
		RectangleF textViewRect;
		float keyboardHeight;
		bool shouldSlideViewUp = false;

		public DetailViewController()
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


			// Perform any additional setup after loading the view, typically from a nib.
			altKeyTextField.EditingDidBegin += (object sender, EventArgs e) => {
				shouldSlideViewUp = true;
			};

			keyTextField.EditingDidBegin += (object sender, EventArgs e) => {
				shouldSlideViewUp = true;
			};

			textView.Started += (object sender, EventArgs e) => {
				shouldSlideViewUp = true;
			};

			nameField.ShouldReturn += textFieldReturnHandler;
			serialNumberField.ShouldReturn += textFieldReturnHandler;
			valueField.ShouldReturn += textFieldReturnHandler;
			altKeyTextField.ShouldReturn += textFieldReturnHandler;
			keyTextField.ShouldReturn += textFieldReturnHandler;
		}

		bool textFieldReturnHandler (UITextField textField)
		{
			textField.ResignFirstResponder();
			return true;
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			// Use for moving entire view
//			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("keyboardWillChangeFrameNotification:"), UIKeyboard.WillChangeFrameNotification, null);
			// Use for moving individual text fields
			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("keyboardDidChangeFrameNotification:"), UIKeyboard.DidChangeFrameNotification, null);

			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("keyboardWillHide:"), UIKeyboard.WillHideNotification, null);

			valueField.KeyboardType = UIKeyboardType.NumberPad;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			viewRect = View.Frame;
			keyTextFieldRect = keyTextField.Frame;
			altKeyTextFieldRect = altKeyTextField.Frame;
			textViewRect = textView.Frame;
		}

		partial void backgroundTapped (MonoTouch.Foundation.NSObject sender)
		{
			this.View.EndEditing(true);
		}


		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			// Use for moving entire view
//			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillChangeFrameNotification, null);
			// Use for moving individual text fields
			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.DidChangeFrameNotification, null);

			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillHideNotification, null);

			// Clear first responder
			this.View.EndEditing(true);

		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				return true;
			} else {
				return false;
			}
		}

		public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
		{
			base.DidRotate(fromInterfaceOrientation);
			this.View.EndEditing(true);
			viewRect = this.View.Frame;
			keyTextFieldRect = keyTextField.Frame;
			altKeyTextFieldRect = altKeyTextField.Frame;
			textViewRect = textView.Frame;
		}

		// Use for moving individual text fields
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			if (shouldSlideViewUp)
				this.MoveViewUp(true, keyboardHeight);
		}

		// Use for moving entire view
//		[Export("keyboardWillChangeFrameNotification:")]
//		public void WillChangeFrameNotification(NSNotification notification)
//		{
//			if (shouldSlideViewUp) {
//				var keyRect = UIKeyboard.FrameEndFromNotification(notification);
//
//				keyboardHeight = keyRect.Height < keyRect.Width ? keyRect.Height : keyRect.Width; // Depending on orientation, height may be given as width, so look for the smaller of the two.
//				this.MoveViewUp(true, keyboardHeight);
//			}
//		}

		// Use for moving individual text fields
		[Export("keyboardDidChangeFrameNotification:")]
		public void DidChangeFrameNotification(NSNotification notification)
		{
			if (shouldSlideViewUp) {
				var keyRect = UIKeyboard.FrameEndFromNotification(notification);

				keyboardHeight = keyRect.Height < keyRect.Width ? keyRect.Height : keyRect.Width; // Depending on orientation, height may be given as width, so look for the smaller of the two.
				this.MoveViewUp(true, keyboardHeight);
			}
		}

		[Export("keyboardWillHide:")]
		public void keyboardWillHide(NSNotification notification) {
			this.MoveViewUp(false, 0.0f);
			shouldSlideViewUp = false;
		}

		// To move the entire view when the keyboard appears
//		public void MoveViewUp(bool movedUp, float keyboardHgt) 
//		{
//			UIView.Animate(0.28, 0.0, UIViewAnimationOptions.CurveEaseOut, new NSAction ( delegate() {
//				RectangleF rect;
//				RectangleF rect2;
//				if (movedUp) {
//					rect = new RectangleF(viewRect.Location.X, viewRect.Location.Y - keyboardHgt, viewRect.Size.Width, viewRect.Size.Height);
//				}
//				else {
//					rect = viewRect;
//				}
//				View.Frame = rect;
//
//			}), null);
//			UIView.CommitAnimations();
//		}

		// To move the individual text fields when the keyboard appears
		public void MoveViewUp(bool movedUp, float keyboardHgt) 
		{
			double speed = movedUp ? 0.0 : 0.28;
			UIView.Animate(speed, 0.0, UIViewAnimationOptions.CurveEaseOut, new NSAction ( delegate() {
				RectangleF rect, rect2, rect3;

				if (movedUp) {
					rect = new RectangleF(keyTextFieldRect.Location.X, keyTextFieldRect.Location.Y  - keyboardHgt, keyTextFieldRect.Size.Width, keyTextFieldRect.Size.Height);
					rect2 = new RectangleF(altKeyTextFieldRect.Location.X, altKeyTextFieldRect.Location.Y  - keyboardHgt, altKeyTextFieldRect.Size.Width, altKeyTextFieldRect.Size.Height);
					rect3 = new RectangleF(textViewRect.Location.X, textViewRect.Location.Y  - keyboardHgt, textViewRect.Size.Width, textViewRect.Size.Height);
				}
				else {
					rect = keyTextFieldRect;
					rect2 = altKeyTextFieldRect;
					rect3 = textViewRect;
				}
				keyTextField.Frame = rect;
				altKeyTextField.Frame = rect2;
				textView.Frame = rect3;

			}), null);
			UIView.CommitAnimations();
		}
	}
}

