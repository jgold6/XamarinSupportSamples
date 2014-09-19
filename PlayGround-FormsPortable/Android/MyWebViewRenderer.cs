using System;
using Xamarin.Forms;
using FormsPlayground;
using FormsPlayground.Android;
using Xamarin.Forms.Platform.Android;
using System.Drawing;
using Android.Webkit;

[assembly: ExportRenderer (typeof (MyWebView), typeof (MyWebViewRenderer))]

namespace FormsPlayground.Android
{
	public class MyWebViewRenderer : WebRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			global::Android.Widget.Button backButton = new global::Android.Widget.Button(this.Context);
			backButton.Text = "Back";
			backButton.SetTextColor(global::Android.Graphics.Color.Blue);

			base.OnElementChanged(e);
			if (e.OldElement == null) {
				// lets get a reference to the native control
				var webView = (global::Android.Webkit.WebView)Control;
				webView.SetWebViewClient(new MyWebViewClient());
				webView.SetInitialScale(-1);

				webView.AddView(backButton);
				backButton.Click += (object sender, EventArgs evt) => {
					if(webView.CanGoBack()) webView.GoBack();
				};
					
			}
		}
    }

	public class MyWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading(global::Android.Webkit.WebView view, string url)
		{
			base.ShouldOverrideUrlLoading(view, url);
			Console.WriteLine("Current Url: {0}", url);

			return false;
		}
	}
}

