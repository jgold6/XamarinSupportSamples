using System;
using Xamarin.Forms;
using FormsPlayground;
using FormsPlayground.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.Concurrent;
using MonoTouch.Foundation;

[assembly: ExportRenderer (typeof (MyWebView), typeof (MyWebViewRenderer))]

namespace FormsPlayground.iOS
{
	public class MyWebViewRenderer : WebViewRenderer
    {
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			UIButton backButton = new UIButton(UIButtonType.RoundedRect);
			backButton.Frame = new RectangleF(0.0f, 20.0f, UIScreen.MainScreen.Bounds.Width/3, 25.0f);
			backButton.TitleLabel.TextColor = UIColor.Blue;
			backButton.SetTitle("Back", UIControlState.Normal);

			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var webView = (UIWebView)this.NativeView;
				backButton.TouchUpInside += (object sender, EventArgs evt) => {
					if (webView.CanGoBack) webView.GoBack();
				};
				webView.Add(backButton);
				webView.ScalesPageToFit = true;
				webView.LoadFinished += (object sender2, EventArgs e2) => {
					Console.WriteLine("Load Finished {0}", webView.Request.Url.AbsoluteString);
				};

			}
		}
    }
}

