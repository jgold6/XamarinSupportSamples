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

			// TODO: Step 1b: set size and color of the UICollectionView
			CollectionView.ContentSize = UIScreen.MainScreen.Bounds.Size;
			CollectionView.BackgroundColor = UIColor.White;

		}
            
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
             
			// TODO: Step 1c: register the ImageCell so it can be created from a DequeueReusableCell call 
			CollectionView.RegisterClassForCell (typeof(ImageCell), cellId); // Now we need a custom cell class! (step 1d)
		}
        

		// TODO: Step 1e: implement the UICollectionViewSource methods
		public override int GetItemsCount (UICollectionView collectionView, int section)
		{
			return Speakers.Count;
		}
           
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
	}          
}

