using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace CollectionViewDemo
{
	// TODO: Step 4a: uncomment code building custom, circular Collection View Layout
	public class CustomLayout : UICollectionViewLayout
	{
		int count;
		float radius;
		PointF center;

		// the item size to use when creating layout attributes
		public SizeF ItemSize { get; set; }

		public CustomLayout (int itemCount)
		{
			count = itemCount;
		}
		// set up initial geometric parameters needed for the layout
		public override void PrepareLayout ()
		{
			base.PrepareLayout ();
			
			SizeF size = CollectionView.Frame.Size;
			count = CollectionView.NumberOfItemsInSection (0);
			center = new PointF (size.Width / 2.0f, size.Height / 2.0f);
			radius = Math.Min (size.Width, size.Height) / 2.5f;	
		}
		// return the overall content size for the collection view
		public override SizeF CollectionViewContentSize {
			get {
				return CollectionView.Frame.Size;
			}
		}
		// invalidate the layout when the bounds changes, so that the layout will be recaluated for the new bounds
		// returning true results is the layout recalulating itself when the orientation changes
		public override bool ShouldInvalidateLayoutForBoundsChange (RectangleF newBounds)
		{
			return true;
		}
		// return layout attributes for a a specific item
		public override UICollectionViewLayoutAttributes LayoutAttributesForItem (NSIndexPath path)
		{
			UICollectionViewLayoutAttributes attributes = UICollectionViewLayoutAttributes.CreateForCell (path);
			attributes.Size = ItemSize;
			attributes.Center = new PointF (center.X + radius * (float)Math.Cos (2 * path.Row * Math.PI / count),
				center.Y + radius * (float)Math.Sin (2 * path.Row * Math.PI / count));
			attributes.Transform3D = CATransform3D.MakeScale (0.5f, 0.5f, 1.0f);
			return attributes;
		}

		// return layout attributes for all the items in a given rectangle
		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect (RectangleF rect)
		{
			UICollectionViewLayoutAttributes[] attributes = new UICollectionViewLayoutAttributes [count];

			for (int i = 0; i < count; i++) {
				NSIndexPath indexPath = NSIndexPath.FromItemSection (i, 0);
				attributes [i] = LayoutAttributesForItem (indexPath);
			}

			return attributes;
		}
	}
}