using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace People
{
	public partial class BubbleNavViewController : UIViewController
	{
//		UIImageView _imageView;
		UIImage _image;
		public BubbleNav _bNav;

		public BubbleNavViewController () : base ("BubbleNavViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			_image = UIImage.FromBundle ("testImage.png");
			_bNav = new BubbleNav(new RectangleF (0, 0, 75,75 ), _image);
			_bNav._imageView.Image = _image;
			View.AddSubview (_bNav);

			// Moved from BubbleNav
			UITapGestureRecognizer tapBubbleGesture = new UITapGestureRecognizer (() => {
				Console.WriteLine ("Tapped");
				_bNav.ShowSelection ();

			});
			View.AddGestureRecognizer (tapBubbleGesture);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

