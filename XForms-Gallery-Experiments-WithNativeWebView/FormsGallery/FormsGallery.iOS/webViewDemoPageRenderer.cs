using System;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using MonoTouch.Foundation;

[assembly:ExportRenderer(typeof(FormsGallery.WebViewDemoPage), typeof(FormsGallery.webViewDemoPageRenderer))]

namespace FormsGallery
{
	public class webViewDemoPageRenderer : PageRenderer
	{
		UIWebView webView;

		protected override void OnModelSet(VisualElement model)
		{
			base.OnModelSet(model);

			var view = NativeView;

			var viewController = ViewController;

			webView = new UIWebView(new RectangleF(0.0f, 0.0f, view.Frame.Width, view.Frame.Height));
			webView.LoadRequest(new NSUrlRequest( new NSUrl("http://example.com")));
			webView.ScrollView.ContentSize = webView.Frame.Size;
			webView.ScrollView.ScrollEnabled = true;
			webView.ScalesPageToFit = true;
			view.Add(webView);
		}
	}


}

