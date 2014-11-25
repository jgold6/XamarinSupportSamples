using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System;


[assembly: ExportRenderer(typeof(ContentPage), typeof(TestTabbedSwipe.Droid.MyTabbedPageRenderer))]

namespace TestTabbedSwipe.Droid
{
	public class MyTabbedPageRenderer : PageRenderer
    {
    

		Activity m_Activity;
		private ItronGestureListener m_Listener;
		private GestureDetector m_Detector;
		MyPage tabbedPage;

		public ActionBar ActionBarItem
		{
			get
			{
				return m_ActionBarItem;
			}
		}
		private ActionBar m_ActionBarItem;

		public MyTabbedPageRenderer()
		{
			m_Activity = this.Context as Activity;
			m_ActionBarItem = m_Activity.ActionBar;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null) {
				this.Touch -= HandleTouch;
				this.Touch += HandleTouch;
			}
			if (e.NewElement == null) {
				this.Touch -= HandleTouch;
				this.Touch += HandleTouch;
			}

			if (e.NewElement != null && e.NewElement.Parent != null)
				tabbedPage = e.NewElement.Parent as MyPage;

			m_Listener = new ItronGestureListener(tabbedPage);
			m_Detector = new GestureDetector(m_Listener);
		}

		void HandleTouch (object sender, TouchEventArgs e)
		{
			m_Detector.OnTouchEvent (e.Event);
		}

	}

	public class ItronGestureListener : GestureDetector.SimpleOnGestureListener
	{
		MyPage tabbedPage;

		public ItronGestureListener(MyPage tp) : base()
		{
			this.tabbedPage = tp;
		}

		public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			Console.WriteLine ("OnFling");
			int currentPageIndex = tabbedPage.Children.IndexOf(tabbedPage.CurrentPage);
			int numberOfPages = tabbedPage.Children.Count;
			if (velocityX < 0) {
				int newIndex = currentPageIndex > 0 ? currentPageIndex -1 : currentPageIndex;
				tabbedPage.CurrentPage = tabbedPage.Children[newIndex];
			}
			else if (velocityX > 0) {
				int newIndex = currentPageIndex < numberOfPages-1 ? currentPageIndex +1 : currentPageIndex;
				tabbedPage.CurrentPage = tabbedPage.Children[newIndex];
			}
			return base.OnFling(e1, e2, velocityX, velocityY);
		}
	}
}

