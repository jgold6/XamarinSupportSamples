using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestYouTube
{
	public partial class TestYouTubeViewController : UIViewController
	{
		YouTubeViewer webView;

		public TestYouTubeViewController() : base("TestYouTubeViewController", null)
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
			webView = new YouTubeViewer("http://www.youtube.com/v/Gw1ImiSR6Eg", new RectangleF(0, 0, 420, 315));
			this.View.AddSubview(webView);
		}

		public override void ViewWillDisappear(bool animated)
		{
			webView.LoadHtmlString("", null);
		}
	}
}

