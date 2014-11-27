using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

[assembly: ExportRenderer(typeof(ContentPage), typeof(TestTabbedSwipe.iOS.MyTabbedPageRenderer))]

namespace TestTabbedSwipe.iOS
{
	public class MyTabbedPageRenderer : PageRenderer
    {
		MyPage tabbedPage;
		UISwipeGestureRecognizer swipeLeft;
			UISwipeGestureRecognizer swipeRight;

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

//			if (e.OldElement == null) {
//				this.Touch -= HandleTouch;
//				this.Touch += HandleTouch;
//			}
//			if (e.NewElement == null) {
//				this.Touch -= HandleTouch;
//				this.Touch += HandleTouch;
//			}

			if (e.NewElement != null && e.NewElement.Parent != null)
				tabbedPage = e.NewElement.Parent as MyPage;

			swipeLeft = new UISwipeGestureRecognizer(this, new MonoTouch.ObjCRuntime.Selector("swipeLeft"));
			swipeLeft.Direction = UISwipeGestureRecognizerDirection.Left;
			swipeRight = new UISwipeGestureRecognizer(this, new MonoTouch.ObjCRuntime.Selector("swipeRight"));
			swipeRight.Direction = UISwipeGestureRecognizerDirection.Right;

			this.View.AddGestureRecognizer(swipeLeft);
			this.View.AddGestureRecognizer(swipeRight);
			 
		}

		[Export("swipeLeft")]
		public void SwipeLeft()
		{
			int currentPageIndex = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
			int numberOfPages = tabbedPage.Children.Count;
			int newIndex = currentPageIndex < numberOfPages-1 ? currentPageIndex +1 : currentPageIndex;
			tabbedPage.CurrentPage = tabbedPage.Children[newIndex];
		}

		[Export("swipeRight")]
		public void SwipeRight()
		{
			int currentPageIndex = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
			int numberOfPages = tabbedPage.Children.Count;
			int newIndex = currentPageIndex > 0 ? currentPageIndex -1 : currentPageIndex;
			tabbedPage.CurrentPage = tabbedPage.Children[newIndex];
		}
    }
}

