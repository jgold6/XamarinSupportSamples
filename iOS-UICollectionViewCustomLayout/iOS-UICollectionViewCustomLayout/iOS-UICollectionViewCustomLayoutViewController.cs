using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace iOSUICollectionViewCustomLayout
{
	public partial class iOS_UICollectionViewCustomLayoutViewController : UICollectionViewController
    {
		List<IAnimal> animals;

        public iOS_UICollectionViewCustomLayoutViewController(IntPtr handle) : base(handle)
        {
			setup();
        }

		public iOS_UICollectionViewCustomLayoutViewController(CVLayout lo) : base(lo)
		{
			setup();
		}

		private void setup()
		{
			animals = new List<IAnimal> ();
			for (int i = 0; i < 20; i++) {
				animals.Add (new Monkey ());
			}

		}

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            // Perform any additional setup after loading the view, typically from a nib.

			// Register the cell class that we are using
			CollectionView.RegisterClassForCell(typeof(CollViewCell), new NSString(CollViewCell.MyCollViewCell));
        }
		#endregion

		public override int NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}

		public override int GetItemsCount(UICollectionView collectionView, int section)
		{
			return animals.Count;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			CollViewCell myCell = (CollViewCell)collectionView.DequeueReusableCell(new NSString(CollViewCell.MyCollViewCell), indexPath);

			myCell.Image = UIImage.FromBundle("monkey.png");

			return myCell;
		}

    }
}

