using System.Drawing;
using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BalancedFlowLayout {

	[BaseType (typeof (UICollectionViewLayout))]
	public partial interface NHBalancedFlowLayout {

		[Export ("preferredRowSize")]
		float PreferredRowSize { get; set; }

		[Export ("sectionInset")]
		UIEdgeInsets SectionInset { get; set; }

		[Export ("minimumLineSpacing")]
		float MinimumLineSpacing { get; set; }

		[Export ("minimumInteritemSpacing")]
		float MinimumInteritemSpacing { get; set; }

		[Export ("scrollDirection")]
		UICollectionViewScrollDirection ScrollDirection { get; set; }
	}

	[BaseType(typeof(NSObject))]
	[Model, Protocol]
	public partial interface NHBalancedFlowLayoutDelegate : IUICollectionViewDelegateFlowLayout {
		[Abstract]
		[Export ("collectionView:layout:preferredSizeForItemAtIndexPath:")]
		SizeF Layout (UICollectionView collectionView, NHBalancedFlowLayout collectionViewLayout, NSIndexPath indexPath);
	}

	[BaseType (typeof (NSObject))]
	public partial interface NHLinearPartition {

		[Static, Export ("linearPartitionForSequence:numberOfPartitions:")]
		NSObject [] LinearPartitionForSequence (NSObject [] sequence, int numberOfPartitions);
	}
}
