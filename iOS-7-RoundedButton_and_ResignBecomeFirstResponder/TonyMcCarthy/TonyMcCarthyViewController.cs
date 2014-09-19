using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace TonyMcCarthy
{
    public partial class TonyMcCarthyViewController : UIViewController
    {
        public TonyMcCarthyViewController(IntPtr handle) : base(handle)
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
			textField.EditingDidBegin += (object sender, EventArgs e) => {
				textField.ResignFirstResponder();
				textView.PerformSelector(new Selector("becomeFirstResponder"), null, 0.0f);
			};
			//textField.ShouldReturn = (sender) => {textField.ResignFirstResponder();return true;};
				
			var showTotals = UIButton.FromType(UIButtonType.RoundedRect);
			showTotals.SetTitle("Press Me!", UIControlState.Normal);
			showTotals.Frame = new RectangleF(50.0f, 200.0f, 100.0f, 40.0f);
			showTotals.Layer.CornerRadius = 10;
			showTotals.Layer.BorderWidth = 1;
			showTotals.Layer.BorderColor = UIColor.Blue.CGColor;
			View.AddSubview(showTotals);
        }

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			textView.ResignFirstResponder();
			textField.ResignFirstResponder();
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

