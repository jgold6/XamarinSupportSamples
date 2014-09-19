using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace AMScrollingNavbar {

	[BaseType (typeof (UIViewController))]
	public partial interface AMScrollingNavbarViewController {

		[Export ("followScrollView:")]
		void FollowScrollView (UIView scrollableView);

		[Export ("showNavbar")]
		void ShowNavbar ();

		[Export ("refreshNavbar")]
		void RefreshNavbar ();
	}
}
