using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.WebKit;
using System.Drawing;

namespace TestWebViewNewWindow
{
	public partial class MyDocument : MonoMac.AppKit.NSDocument
	{

		NSDocumentController myDocumentController;

		// Called when created from unmanaged code
		public MyDocument(IntPtr handle) : base(handle)
		{
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MyDocument(NSCoder coder) : base(coder)
		{
		}

		public override void WindowControllerDidLoadNib(NSWindowController windowController)
		{
			base.WindowControllerDidLoadNib(windowController);

			myDocumentController = new NSDocumentController();

			// Add code to here after the controller has loaded the document window
			wView.MainFrame.LoadRequest(new NSUrlRequest(new NSUrl( "http://www.xamarin.com"))); // Replace with your url


			wView.WeakUIDelegate = this;
			wView.GroupName = "MyDocument";
		}

		[Export ("webView:createWebViewWithRequest:")]
		public WebView CreateWebView(WebView sender, NSUrlRequest request)
		{
			NSError error;
			myDocumentController.OpenUntitledDocument(true, out error);
			return sender;
		}

		[Export ("webViewShow:")]
		public void WebViewShow(WebView sender)
		{
			var myDocument = myDocumentController.DocumentForWindow(sender.Window);
			myDocument.ShowWindows();
		}

		//
		// Save support:
		//    Override one of GetAsData, GetAsFileWrapper, or WriteToUrl.
		//
		// This method should store the contents of the document using the given typeName
		// on the return NSData value.
		public override NSData GetAsData(string documentType, out NSError outError)
		{
			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
			return null;
		}
		//
		// Load support:
		//    Override one of ReadFromData, ReadFromFileWrapper or ReadFromUrl
		//
		public override bool ReadFromData(NSData data, string typeName, out NSError outError)
		{
			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
			return false;
		}
		// If this returns the name of a NIB file instead of null, a NSDocumentController
		// is automatically created for you.
		public override string WindowNibName
		{ 
			get
			{
				return "MyDocument";
			}
		}
	}
}

