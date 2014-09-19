using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WebView {

	public class WebViewController : UIViewController {
		
		UIWebView webView;
//		UISwipeGestureRecognizer leftSwipe; // need a gesturerecognizer for each swipe direction that you want to recognize.
//		UISwipeGestureRecognizer rightSwipe;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UISwipeGestureRecognizer leftSwipe = new UISwipeGestureRecognizer();
			leftSwipe.Direction = UISwipeGestureRecognizerDirection.Left; // sets the direction for the swipe gesture recognizer
			UISwipeGestureRecognizer rightSwipe = new UISwipeGestureRecognizer();
			rightSwipe.Direction = UISwipeGestureRecognizerDirection.Right;

			// add targets for leftSwipe and rightSwipe
			leftSwipe.AddTarget (() => {
				UIAlertView alert = new UIAlertView ("Test", "Left", null, "Ok");
				alert.Show();
				webView.EvaluateJavascript("GoBackward();");
			});
			rightSwipe.AddTarget(() => {
				UIAlertView alert = new UIAlertView ("Test", "Right", null, "Ok");
				alert.Show();
				webView.EvaluateJavascript("GoFoward();");
			});

//			View.AddGestureRecognizer (leftSwipe); // unnecessary
//			View.AddGestureRecognizer (rightSwipe); // unnecessary

			GetSupportedInterfaceOrientations ();
			Title = "Colder";
			webView = new UIWebView(View.Bounds);
			webView.ScrollView.ScrollEnabled = false; // Disable scrolling in the webview.
			webView.AddGestureRecognizer(leftSwipe); // add both gesture recognizers to the webView
			webView.AddGestureRecognizer(rightSwipe);	
			UIBarButtonItem backButton = new UIBarButtonItem ("Back", UIBarButtonItemStyle.Done, null);
			backButton.Clicked += (object sender, System.EventArgs e) => {
				webView.GoBack();
			};

			webView.ShouldStartLoad += myHanddle;

			this.NavigationItem.RightBarButtonItem = backButton;

			string fileName = "Content/index.html";
			
			string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			webView.LoadRequest (new NSUrlRequest (new NSUrl (localHtmlUrl, false)));
			webView.ScalesPageToFit = true;
			webView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			View.AddSubview (webView);
			webView.EvaluateJavascript("GoFoward();");
		}

		bool myHanddle (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType nav)
		{
			if (request.Url.ToString().Contains("www.colder")) {
				UIApplication.SharedApplication.OpenUrl (request.Url);
				return false;	
			}
			return true;
		}



		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Landscape;
		}
	}
}