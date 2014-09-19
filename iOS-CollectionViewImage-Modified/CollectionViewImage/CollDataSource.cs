using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.ObjCRuntime;

namespace CollectionViewImage
{
	#region CollDataSource
	public class CollDataSource : UICollectionViewDataSource
	{
		// Holds the images to be used
		public List<IcollCellImage> cellImages;
		// holds the UICollectionViewCell cell id, which is the same as the cell class name
		public NSString collCellID = new NSString("collCell");


		#region new
		// keep track of number of cells
		public int cellCount = 0;
		#endregion//new



		public CollDataSource ()
		{
			// Populate the list with images
			cellImages = new List<IcollCellImage> ();
			for (int i = 0; i < 50; i++) {
				cellImages.Add(new TestImage());
				cellImages.Add (new TestImage2 ());

				#region new
				// increment the cell count for adding two images
				cellCount += 2;
				// test both counts
				Console.WriteLine (cellImages.Count + " (" + cellCount + ") cells now");
				#endregion//new
			}
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var collCell = (CollCell)collectionView.DequeueReusableCell (collCellID, indexPath);
			var image = cellImages[indexPath.Row];
			collCell.Image = image.Image;
			#region new
			// store references to the collectionView and the indexPath for this cell
			collCell.indexPathForCell = indexPath;
			collCell.collViewForCell = collectionView;
			// store a reference to this data source so it can be referenced from the cell
			collCell.dataSource = this;
			#endregion//new
			return collCell;
		}
		#region new
		public void deleteCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			cellCount--; // decrement cell count
			// update collectionview
			collectionView.PerformBatchUpdates (delegate {
				// delete the cell
				collectionView.DeleteItems (new NSIndexPath[] { indexPath });
			}, null);
			// delete the corresponding cell image from cellIMages
			cellImages.RemoveAt (indexPath.Row);
			var count = cellImages.Count;
			//Get testImageName
			var testImageName = cellImages[indexPath.Row].Name;
			// test both counts
			Console.WriteLine ("Delete " + testImageName + ", " + count + " (" + GetItemsCount(collectionView,0) + ") cells now");
		}
		#endregion//new

//		public override int NumberOfSections (UICollectionView collectionView)
//		{
//			return 1;
//		}

		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return cellCount;
		}
	}

	#endregion //CollDataSource
	#region UICollectionViewDelegate


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

		
		public override bool ShouldShowMenu(UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}
		public override bool CanPerformAction (UICollectionView collectionView, MonoTouch.ObjCRuntime.Selector action, NSIndexPath indexPath, NSObject sender)
		{
			if (action.Name == "custom:") {			

				Console.WriteLine ("Action: " + action.Name);
				return true;
			}
			else
				return false;
		}
		public override void PerformAction (UICollectionView collectionView, MonoTouch.ObjCRuntime.Selector action, NSIndexPath indexPath, NSObject sender)
		{
			Console.WriteLine ("code to perform action");
		}
	
	}

	#endregion // CollViewDelegate
}

