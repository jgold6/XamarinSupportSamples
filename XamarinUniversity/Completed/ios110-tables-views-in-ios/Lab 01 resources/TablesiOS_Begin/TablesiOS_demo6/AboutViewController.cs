using System;
using System.Drawing; // for RectangleF
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TablesDemo {
	/// <summary>
	/// For demo purposes only. This screen is not part of the course material
	/// </summary>
	public class AboutViewController : UIViewController {
		public AboutViewController ()
		{
		}
		UIWebView aboutHtml;
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			
			string aboutPageUrl = NSBundle.MainBundle.BundlePath + "/about.html";
			
			aboutHtml = new UIWebView ();
			aboutHtml.LoadRequest (new NSUrlRequest (new NSUrl (aboutPageUrl, false)));
			aboutHtml.Frame = new RectangleF (0, 0, View.Frame.Width, View.Frame.Height);
			View.Add (aboutHtml);
		}
	}
}

