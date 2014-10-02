// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace iOSUICollectionViewCustomLayout
{
	[Register ("iOS_UICollectionViewCustomLayoutViewController")]
	partial class iOS_UICollectionViewCustomLayoutViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UICollectionView CollView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CollView != null) {
				CollView.Dispose ();
				CollView = null;
			}
		}
	}
}
