using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CollectionViewImage
{
	public partial class CollectionViewImageViewController : UIViewController
	{
		//List<UICollectionViewCell> cells;
		public CollectionViewImageViewController () : base ("CollectionViewImageViewController", null)
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

			var dataSource = new CollDataSource ();
			// UICView is a UICollectionView added in the interface bulder
			UICView.DataSource = dataSource;
			// Register the cell type with iOS
			UICView.RegisterClassForCell (typeof(CollCell), dataSource.collCellID);

			
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

