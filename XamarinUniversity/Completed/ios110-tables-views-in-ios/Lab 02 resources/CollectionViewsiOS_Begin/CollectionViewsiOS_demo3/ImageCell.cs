using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CollectionViewDemo
{
	public class ImageCell : UICollectionViewCell
	{
		UIImageView imageView;

		[Export ("initWithFrame:")]
		ImageCell (RectangleF frame) : base (frame)
		{
			// create an image view to use in the cell
			imageView = new UIImageView (new RectangleF (0, 0, 100, 100)); 
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			// populate the content view
			ContentView.AddSubview (imageView);

			// scale the content view down so that the background view is visible, effecively as a border
			ContentView.Transform = CGAffineTransform.MakeScale (0.9f, 0.9f);

			// background view displays behind content view and selected background view
			BackgroundView = new UIView{BackgroundColor = UIColor.Black};

			// selected background view displays over background view when cell is selected
			SelectedBackgroundView = new UIView{BackgroundColor = UIColor.Yellow};
		}

		internal void UpdateImage (string path)
		{
			using (var image = UIImage.FromFile(path)) {
				imageView.Image = image;
			}
		}
	}
}

