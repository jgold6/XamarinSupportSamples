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

			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("keyboardWillShow:"), UIKeyboard.WillShowNotification, null);
			NSNotificationCenter.DefaultCenter.AddObserver(this, new Selector("keyboardWillHide:"), UIKeyboard.WillHideNotification, null);

			valueField.KeyboardType = UIKeyboardType.NumberPad;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			viewRect = View.Frame;
		}

		partial void backgroundTapped (MonoTouch.Foundation.NSObject sender)
		{
			this.View.EndEditing(true);
		}


		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			NSNotificationCenter.DefaultCenter.RemoveObserver(this, UIKeyboard.WillShowNotification, null);
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
		}

		[Export("keyboardWillShow:")]
		public void keyboardWillShow(NSNotification notification)
		{
			if (shouldSlideViewUp) {
				var keyRect = UIKeyboard.FrameEndFromNotification(notification);

				float keyboardHgt = keyRect.Height < keyRect.Width ? keyRect.Height : keyRect.Width; // Depending on orientation, height may be given as width, so look for the smaller of the two.
				shouldSlideViewUp = false;
				this.MoveViewUp(true, keyboardHgt);
			}
		}

		[Export("keyboardWillHide:")]
		public void keyboardWillHide(NSNotification notification) {
			this.MoveViewUp(false, 0.0f);
		}

		public void MoveViewUp(bool movedUp, float keyboardHgt) 
		{
			UIView.Animate(0.28, 0.0, UIViewAnimationOptions.CurveEaseOut, new NSAction ( delegate() {
				RectangleF rect;
				if (movedUp) {
					rect = new RectangleF(viewRect.Location.X, viewRect.Location.Y - keyboardHgt + 44.0f, viewRect.Size.Width, viewRect.Size.Height);
				}
				else {
					rect = viewRect;
				}
				View.Frame = rect;
			}), null);
			UIView.CommitAnimations();
		}
	}
}

