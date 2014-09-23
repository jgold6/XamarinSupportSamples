using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOSUIWebViewPdfiOS8
{
    public partial class iOS_UIWebViewPdfiOS8ViewController : UIViewController
    {
		UIWebView webView;

        public iOS_UIWebViewPdfiOS8ViewController(IntPtr handle) : base(handle)
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
			webView = new UIWebView();
			webView.Frame = new RectangleF (0, 0, 320, 640);
			webView.BackgroundColor = UIColor.Clear;
			webView.LoadRequest(new NSUrlRequest(new NSUrl("Help.pdf", false)));
			webView.ScalesPageToFit = true;
			View.AddSubview(webView);
        }

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
	
			var subViews = webView.Subviews;
			foreach (UIView v in subViews) {
				v.BackgroundColor = UIColor.Clear;
				Console.WriteLine("WebVIew Subview {0}",v);

				var subv = v.Subviews;
				foreach (UIView w in subv) {
					w.BackgroundColor = UIColor.Clear;
					Console.WriteLine("***WebVIew Subview {0}",w);
				}
			}
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

