using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Homepwner
{
	public partial class ImageViewController : UIViewController
	{
		public UIImage image {get; set;}

		public ImageViewController() : base("ImageViewController", null)
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
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			SizeF sz = image.Size;
			scrollView.ContentSize = sz;
			scrollView.MinimumZoomScale = 0.25f;
			scrollView.MaximumZoomScale = 5f;

			scrollView.ViewForZoomingInScrollView += (UIScrollView sv) => {return imageView;};

			scrollView.ScrollRectToVisible(new RectangleF(image.Size.Width/2 - 300, image.Size.Height/2 - 300, 600,  600), true);

			imageView.Frame = new RectangleF(0, 0, sz.Width, sz.Height);
			imageView.Image = image;
		}
	}
}

