using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CollectionViewDemo
{
	public class CollectionViewController : UICollectionViewController
	{
		static readonly NSString cellId = new NSString ("ImageCell");
		static readonly NSString headerId = new NSString ("Header");

		// used to keep the cell on top of other cells when scaled while highlighting
		int cellZIndex = 1;

		public Speakers Speakers { get; private set; }

		public CollectionViewController (UICollectionViewLayout layout) : base (layout)
		{
			Speakers = new Speakers ();

			CollectionView.ContentSize = UIScreen.MainScreen.Bounds.Size;
			CollectionView.BackgroundColor = UIColor.White;
		}
            
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
             
			// register the ImageCell so it can be created from a DequeueReusableCell call
			CollectionView.RegisterClassForCell (typeof(ImageCell), cellId);

			// TODO: Step 2b: uncomment to register the class for the Supplementary View
			CollectionView.RegisterClassForSupplementaryView (typeof(Header), UICollectionElementKindSection.Header, headerId);

		}
         
		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return Speakers.Count;
		}
           
		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// get an ImageCell from the pool. DequeueReusableCell will create one if necessary -- slightly different to UITableViewSource
			ImageCell imageCell = (ImageCell)collectionView.DequeueReusableCell (cellId, indexPath);

			// update the image for the speaker
			imageCell.UpdateImage (Speakers [indexPath.Row].ImageFile);
                
			return imageCell;
		}

		public override void ItemSelected (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// do something when the item is selected (eg a new ViewController)
			Console.WriteLine ("selected " + indexPath.Row);
		}

		// TODO: Step 2c: uncomment to get a header instance to use for the Supplementary View
		public override UICollectionReusableView GetViewForSupplementaryElement (UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
		{
			// get a Header instance to use for the supplementary view
			var headerView = (Header)collectionView.DequeueReusableSupplementaryView (elementKind, headerId, indexPath);
			headerView.Text = "Evolve Speakers";
			return headerView;
		}
	}          
}

