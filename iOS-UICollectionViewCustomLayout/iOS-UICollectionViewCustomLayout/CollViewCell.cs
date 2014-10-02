using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.CoreGraphics;

namespace iOSUICollectionViewCustomLayout
{
	partial class CollViewCell : UICollectionViewCell
	{
		public static readonly string MyCollViewCell = "MyCollViewCell";

		UIImageView imageView;

		public UIImage Image {
			set {
				imageView.Image = value;
			}
		}

		public CollViewCell (IntPtr handle) : base (handle)
		{
			setup();
		}

		[Export ("initWithFrame:")]
		public CollViewCell(RectangleF rect) : base(rect)
		{
			setup();
		}

		private void setup()
		{
			BackgroundView = new UIView{BackgroundColor = UIColor.Orange};

			SelectedBackgroundView = new UIView{BackgroundColor = UIColor.Green};

			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			ContentView.Layer.BorderWidth = 2.0f;
			ContentView.BackgroundColor = UIColor.White;
			ContentView.Transform = CGAffineTransform.MakeScale (0.8f, 0.8f);

			imageView = new UIImageView (UIImage.FromBundle ("placeholder.png"));
			imageView.Center = ContentView.Center;
			imageView.Transform = CGAffineTransform.MakeScale (0.7f, 0.7f);

			ContentView.AddSubview (imageView);

		}

		public override void PrepareForReuse()
		{
			base.PrepareForReuse();
			imageView.Image = null;
		}
	}
}
