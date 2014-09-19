using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TestYouTube
{
	public partial class FirstViewController : UIViewController
	{
		public FirstViewController() : base("FirstViewController", null)
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
			btnLoadYouTube.TouchUpInside += (object sender, EventArgs e) => {
				var ytvc = new TestYouTubeViewController();
				this.NavigationController.PushViewController(ytvc, true);
			};
		}
	}
}

