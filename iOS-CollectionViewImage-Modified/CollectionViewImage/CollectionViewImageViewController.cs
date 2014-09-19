using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.ObjCRuntime;

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

			this.UICView.CollectionViewLayout = new LineLayout (){
				//HeaderReferenceSize = new System.Drawing.SizeF (16, 10),
				//ScrollDirection = UICollectionViewScrollDirection.Horizontal
			};
			CollDataSource dataSource = new CollDataSource ();
			// UICView is a UICollectionView added in the interface bulder

			UICView.DataSource = dataSource;
			UICollectionViewDelegate cvd = new CollViewDelegate ();
			UICView.Delegate = cvd;
			// Register the cell type with iOS
			UICView.RegisterClassForCell (typeof(CollCell), dataSource.collCellID);

			#region new
			// Adds the custom menu item
			UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] { 
				new UIMenuItem ("Custom", new Selector ("custom:")) 
			};
			#endregion //new
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

