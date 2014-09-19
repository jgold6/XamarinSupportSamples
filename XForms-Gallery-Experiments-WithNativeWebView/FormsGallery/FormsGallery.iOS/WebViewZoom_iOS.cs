using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using FormsGallery.iOS;
using MonoTouch.UIKit;

[assembly: Dependency(typeof(WebViewZoom_iOS))]

namespace FormsGallery.iOS
{
	public class WebViewZoom_iOS : UIWebView, IWebZoom
	{
		public WebViewZoom_iOS() {}

		public void WebZoom()
		{

		}
	}
}

