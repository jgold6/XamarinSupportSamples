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
			CollectionView.ContentSize = UIScreen.MainScreen.Bounds.Size;
			CollectionView.BackgroundColor = UIColor.White;

			Speakers = new Speakers ();
		}
            
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
             
			// register the ImageCell so it can be created from a DequeueReusableCell call
			CollectionView.RegisterClassForCell (typeof(ImageCell), cellId);

			CollectionView.RegisterClassForSupplementaryView (typeof(Header), UICollectionElementKindSection.Header, headerId);
		}
         
		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return Speakers.Count;
		}
           
		// ImageCell and UpdateImage are defined below
		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// get an ImageCell from the pool. DequeueReusableCell will create one if necessary
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

		public override UICollectionReusableView GetViewForSupplementaryElement (UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
		{
			// get a Header instance to use for the supplementary view
			var headerView = (Header)collectionView.DequeueReusableSupplementaryView (elementKind, headerId, indexPath);
			headerView.Text = "Evolve Speakers";
			return headerView;
		}
	
		public override void ItemHighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			UICollectionViewCell cell = collectionView.CellForItem (indexPath);

			// animate the cell to scale up when highlighted
			UIView.Animate (
				duration: 0.2, 
				animation: () => { 
					cell.ContentView.Transform = CGAffineTransform.MakeScale (1.1f, 1.1f);
					cell.BackgroundView.Transform = CGAffineTransform.MakeScale (1.4f, 1.4f);
					cell.BackgroundView.BackgroundColor = UIColor.Purple;
					cell.Layer.ZPosition = ++cellZIndex;
				}
			);
		}

		public override void ItemUnhighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// restore the cell to its original scale when unhighlighted
			UICollectionViewCell cell = collectionView.CellForItem (indexPath);
			cell.BackgroundView.BackgroundColor = UIColor.Black;
			cell.ContentView.Transform = CGAffineTransform.MakeScale (0.9f, 0.9f);
			cell.BackgroundView.Transform = CGAffineTransform.MakeScale (1.0f, 1.0f);
		}
	}          
}