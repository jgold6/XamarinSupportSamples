using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace CollectionViewImage
{
	public class CollDataSource : UICollectionViewDataSource
	{
		// Holds the images to be used
		List<IcollCellImage> cellImages;
		// holds the UICollectionViewCell cell id, which is the same as the cell class name
		public NSString collCellID = new NSString("collCell");

		public CollDataSource ()
		{
			// Populate the list with images
			cellImages = new List<IcollCellImage> ();
			for (int i = 0; i < 50; i++) {
				cellImages.Add(new TestImage());
				cellImages.Add (new TestImage2 ());
			}
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var collCell = (CollCell)collectionView.DequeueReusableCell (collCellID, indexPath);
			var image = cellImages[indexPath.Row];
			collCell.Image = image.Image;
			return collCell;
		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return cellImages.Count;
		}

	}
	public class CollViewDelegate : UICollectionViewDelegate
	{
		public override void ItemHighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);
			cell.ContentView.BackgroundColor = UIColor.Yellow;
		}

		public override void ItemUnhighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = collectionView.CellForItem(indexPath);
			cell.ContentView.BackgroundColor = UIColor.White;
		}
	}
}

