using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace iOSUICollectionViewCustomLayout
{
    public class CVLayout : UICollectionViewFlowLayout
    {

		Dictionary<string, Dictionary<NSIndexPath, UICollectionViewLayoutAttributes>> layoutInfo;

		UIEdgeInsets itemInsets;
		SizeF itemSize;
		float interItemSpacingX;
		float interItemSpacingY;
		int numberOfColumns;

		public UIEdgeInsets ItemInsets { get {return itemInsets;}
			set {
				if (itemInsets.Equals(value)) return;
				itemInsets = value;
				InvalidateLayout();
			}
		}
		public SizeF ItemSize { get {return itemSize;}
			set {
				if (itemSize == value) return;
				itemSize = value;
				InvalidateLayout();
			}
		}
		public float InterItemSpacingX { get {return interItemSpacingX;}
			set {
				if (interItemSpacingX == value) return;
				interItemSpacingX = value;
				InvalidateLayout();
			}
		}
		public float InterItemSpacingY { get {return interItemSpacingY;}
			set {
				if (interItemSpacingY == value) return;
				interItemSpacingY = value;
				InvalidateLayout();
			}
		}
		public int NumberOfColumns { get {return numberOfColumns;}
			set {
				if (numberOfColumns == value) return;
				numberOfColumns = value;
				InvalidateLayout();
			}
		}


        public CVLayout()
        {
			// Set properties of layout
			itemInsets = new UIEdgeInsets(20.0f,5.0f,5.0f,0.0f); // Sets insets from edge of screen (top, left, bottom, right)
			itemSize = new SizeF(150.0f, 150.0f); 
			interItemSpacingX = 5.0f; 
			interItemSpacingY = 5.0f; 
			numberOfColumns = 2; 
			ScrollDirection = UICollectionViewScrollDirection.Vertical;
        }

		public override void PrepareLayout()
		{
			base.PrepareLayout();

			Dictionary<string, Dictionary<NSIndexPath, UICollectionViewLayoutAttributes>> newLayoutInfo = 
				new Dictionary<string, Dictionary<NSIndexPath, UICollectionViewLayoutAttributes>>();

			Dictionary<NSIndexPath, UICollectionViewLayoutAttributes> cellLayoutInfo = new Dictionary<NSIndexPath, UICollectionViewLayoutAttributes>();

			int sectionCount = CollectionView.NumberOfSections();
			NSIndexPath indexPath = NSIndexPath.FromItemSection(0,0);

			for (int section = 0; section < sectionCount; section++) {
				int itemCount = CollectionView.NumberOfItemsInSection(section);

				for (int item = 0; item < itemCount; item ++) {
					indexPath = NSIndexPath.FromItemSection(item, section);

					UICollectionViewLayoutAttributes itemAttributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);
					itemAttributes.Frame = FrameForItemAtIndexPath(indexPath); // Set the frame for each item

					cellLayoutInfo.Add(indexPath, itemAttributes);
				}
			}

			newLayoutInfo.Add(CollViewCell.MyCollViewCell, cellLayoutInfo);

			layoutInfo = newLayoutInfo;
		}

		// Set the frame for each item. Called from PrepareLayout above.
		public RectangleF FrameForItemAtIndexPath(NSIndexPath indexPath)
		{
			int row = indexPath.Row / numberOfColumns;
			int column = indexPath.Row % numberOfColumns;

			float originX = (float)Math.Floor(itemInsets.Left + (itemSize.Width + interItemSpacingX) * column);
			float originY = (float)Math.Floor(itemInsets.Top + (itemSize.Height + interItemSpacingY) * row);

			return new RectangleF(originX, originY, itemSize.Width, itemSize.Height);
		}

		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(RectangleF rect)
		{
			List<UICollectionViewLayoutAttributes> allAttributes = new List<UICollectionViewLayoutAttributes>();

			foreach (var elementsInfo in layoutInfo.Values) {
				foreach (var attributes in elementsInfo.Values) {
					if (rect.IntersectsWith(attributes.Frame)) {
						allAttributes.Add(attributes);
					}
				}
			}
			return allAttributes.ToArray();
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
		{
			Dictionary<NSIndexPath, UICollectionViewLayoutAttributes> cellLayoutInfo = null;
			layoutInfo.TryGetValue(CollViewCell.MyCollViewCell, out cellLayoutInfo);
			UICollectionViewLayoutAttributes attributes = null;
			cellLayoutInfo.TryGetValue(indexPath, out attributes);
			return attributes;
		}

		public override SizeF CollectionViewContentSize
		{
			get
			{
				int rowCount = CollectionView.NumberOfItemsInSection(0) / numberOfColumns;
				// make sure we count another row if one i sonly partially filled
				if (CollectionView.NumberOfItemsInSection(0) % numberOfColumns != 0) rowCount++;

				float height = itemInsets.Top + rowCount * itemSize.Height + (rowCount -1) * interItemSpacingY + itemInsets.Bottom;

				return new SizeF(CollectionView.Bounds.Size.Width, height);
			}
		}
    }
}

