using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;

namespace CollectionViewImage
{
	public class CollCell : UICollectionViewCell
	{
		UIImageView imageView;

		#region new
		// Fields to store references for cell
		public NSIndexPath indexPathForCell { get; set; }
		public UICollectionView collViewForCell { get; set;}
		public CollDataSource dataSource { get; set; }
		#endregion//new

		[Export ("initWithFrame:")]
		public CollCell (System.Drawing.RectangleF frame) : base (frame)
		{
			// sets up how the cell should look and adds a placeholder image
			BackgroundView = new UIView{BackgroundColor = UIColor.Orange};

			SelectedBackgroundView = new UIView{BackgroundColor = UIColor.Green};

//			ContentView.Bounds = new RectangleF (0, 0, 220, 220); // Added this line
			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
//			ContentView.Layer.BorderWidth = 10.0f;
			ContentView.BackgroundColor = UIColor.White;
			ContentView.Transform = CGAffineTransform.MakeScale (0.95f, 0.95f);

			imageView = new UIImageView  (UIImage.FromBundle("Images/placeholder.png"));
			imageView.Center = ContentView.Center;
			float xScale = ContentView.Bounds.Size.Width / imageView.Bounds.Size.Width; // Added
			float yScale = ContentView.Bounds.Size.Height / imageView.Bounds.Size.Height; // Added
			imageView.Transform = CGAffineTransform.MakeScale (xScale, yScale); // Modified

			ContentView.AddSubview (imageView);
		}

		public UIImage Image {
			set {
				imageView.Image = value;
			}
		}
		// Added 11/16

		[Export("custom:")]
		void Custom()
		{
//			var imageName = dataSource.cellImages [indexPathForCell.Row].Name;
//			Console.WriteLine ("delete operation " + imageName);
			#region new
			dataSource.deleteCell(collViewForCell, indexPathForCell);
			#endregion//new
		}
	}
}

