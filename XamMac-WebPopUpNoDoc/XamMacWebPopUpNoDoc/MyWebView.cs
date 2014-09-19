using System;
using MonoMac.WebKit;
using MonoMac.ObjCRuntime;

namespace XamMacWebPopUpNoDoc
{
	public class MyWebPolicyDelegate : WebPolicyDelegate
	{
		public MyWebPolicyDelegate() : base()
		{
		}

//		public override void DecidePolicyForMimeType(WebView webView, string mimeType, MonoMac.Foundation.NSUrlRequest request, WebFrame frame, MonoMac.Foundation.NSObject decisionToken)
//		{
//
//		}

		public override void DecidePolicyForNewWindow(WebView webView, MonoMac.Foundation.NSDictionary actionInformation, MonoMac.Foundation.NSUrlRequest request, string newFrameName, MonoMac.Foundation.NSObject decisionToken)
		{
			Console.WriteLine("NewWindow");
			//decisionToken.PerformSelector(new Selector("use"), null, 0.0d);
			webView.MainFrame.LoadRequest(request);
		}

//		public override void DecidePolicyForNavigation(WebView webView, MonoMac.Foundation.NSDictionary actionInformation, MonoMac.Foundation.NSUrlRequest request, WebFrame frame, MonoMac.Foundation.NSObject decisionToken)
//		{
//			Console.WriteLine("Navigation");
//			decisionToken.PerformSelector(new Selector("use"), null, 0.0d);
//
//		}
//
//		public override void UnableToImplementPolicy(WebView webView, MonoMac.Foundation.NSError error, WebFrame frame)
//		{
//
//		}
	}
}

