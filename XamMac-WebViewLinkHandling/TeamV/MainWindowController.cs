
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Web;

using System.Runtime.InteropServices;
using System.ComponentModel.Composition;
using MonoMac.WebKit;
using MonoMac.ObjCRuntime;

namespace TeamV
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		string urlToCheck="https://login.live.com/oauth20_authorize.srf?client_id=000000004007D1BE&redirect_uri=https://oauth.live.com/desktop&response_type=code&scope=wl.skydrive_update%20,%20wl.offline_access";

		#region Constructors

		// Called when created from unmanaged code
		//[Import("user32.dll", SetLastError = true)]
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[MonoMac.Foundation.Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
			web.DecidePolicyForNavigation += (object sender, WebNavigationPolicyEventArgs e) => {
				WebView.DecideUse(e.DecisionToken);
			};
			web.DecidePolicyForNewWindow += (object sender, WebNewWindowPolicyEventArgs e) => {
				web.MainFrame.LoadRequest(e.Request);
			};

		}
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}



		partial void GoWeb (NSObject sender)
		{
			try
			{
			web.MainFrameUrl= text.StringValue;
			}
			catch(Exception ex)
			{
			Console.WriteLine(ex.ToString());
			}
			
		}

		partial void AuthorizeMe (NSObject sender)
		{
		//	string url=GetBrowserURL("Firefox");
		}
	}

	public class MyWebPolicyDelegate : WebPolicyDelegate
	{
		public MyWebPolicyDelegate() : base()
		{
		}

		//  public override void DecidePolicyForMimeType(WebView webView, 
		//                                                string mimeType, 
		//                       MonoMac.Foundation.NSUrlRequest request, 
		//                                              WebFrame frame, 
		//                           MonoMac.Foundation.NSObject decisionToken)
		//  {
		//  }

//		public override void DecidePolicyForNewWindow(WebView webView, 
//			MonoMac.Foundation.NSDictionary actionInformation, 
//			MonoMac.Foundation.NSUrlRequest request, 
//			string newFrameName, 
//			MonoMac.Foundation.NSObject decisionToken)
//		{
//			webView.MainFrame.LoadRequest(request);
//		}

//		  public override void DecidePolicyForNavigation(WebView webView, 
//		                         MonoMac.Foundation.NSDictionary actionInformation, 
//		                         MonoMac.Foundation.NSUrlRequest request, 
//		                                                WebFrame frame, 
//		                             MonoMac.Foundation.NSObject decisionToken)
//		  {
//			WebView.DecideUse(decisionToken);
//		  }
		//
		//  public override void UnableToImplementPolicy(WebView webView, 
		//                            MonoMac.Foundation.NSError error, 
		//                                              WebFrame frame)
		//  {
		//  }
	}
}

