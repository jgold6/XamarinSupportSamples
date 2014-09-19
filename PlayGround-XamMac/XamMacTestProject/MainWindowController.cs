using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.WebKit;
using MonoMac.CoreGraphics;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Configuration;
using System.IO;

using MonoMac.AVFoundation;
using System.Data.SqlClient;



namespace XamMacTestProject
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		NSProgressIndicator JobProgressBar;

		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MainWindowController(NSCoder coder) : base(coder)
		{
			Initialize();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController() : base("MainWindow")
		{
			Initialize();
		}
		// Shared initialization code
		void Initialize()
		{
//			NSError error = null;
//			//string path = NSBundle.MainBundle.PathForResource("Reachability.csxv",null);
//			string path = NSBundle.MainBundle.PathForResource("CentraCareBill.pdf",null);
//
//			Console.WriteLine("Path = {0}", path);

//			if (NSWorkspace.SharedWorkspace.OpenFile(path))
//				Console.WriteLine("File Opened successfully");
//			else
//				Console.WriteLine("No app to open file");


//			MonoMac.AVFoundation.AVCaptureDevice[] devices = MonoMac.AVFoundation.AVCaptureDevice.Devices;
//			foreach (MonoMac.AVFoundation.AVCaptureDevice capDev in devices) {
//
//				Console.WriteLine("Device: {0}", capDev);
//			}

		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

//			SqlConnection sqlConn;
//			string connsqlstring = string.Format("Data Source=www.sqlcourse2.com;");
//			sqlConn = new SqlConnection(connsqlstring);
//			sqlConn.Open();
//			Console.WriteLine("Database: {0}", sqlConn.Database);
//			sqlConn.Close();

			//this.Window.BackgroundColor = NSColor.Black;

			JobProgressBar = new NSProgressIndicator(new RectangleF(0, 0, 500, 20));

			//this.webView.AddSubview(JobProgressBar);
			var path = NSBundle.MainBundle.PathForResource("croctear","png"); // 
			var pattern = NSColor.FromPatternImage(new NSImage(path));
			var cgColorPattern = pattern.CGColor;

			mainView.WantsLayer = true;
			mainView.Layer.BackgroundColor = cgColorPattern;//NSColor.Black.CGColor;//new CGColor(1.0f, 0.0f, 0.0f);

			double pBarValue = 0.0d;
			btnButton.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("Button button Pressed");
				ModalWindowController mwc = new ModalWindowController();
				NSApplication.SharedApplication.RunModalForWindow(mwc.Window);
//				Task.Factory.StartNew (() => {
//					UpdateProgressBar(pBarValue += 1.0d);
//				}).ContinueWith (task  => {
//				}, TaskScheduler.FromCurrentSynchronizationContext ());

				#region - NSPasteBoard

//				//"/Users/apple/testpasteboard.txt"
//				NSArray objects = NSArray.FromNSObjects(new NSObject[]{new NSString("/path/to/file")});
//				NSPasteboard pb = NSPasteboard.GeneralPasteboard;
//				pb.ClearContents();
//				pb.DeclareTypes(new string[]{NSPasteboard.NSFilenamesType}, null);
//				pb.SetPropertyListForType(objects, NSPasteboard.NSFilenamesType);
				#endregion
			};

			// Thread process time returns negative value? 
//			for (int i = 0; i < 1000; i++) {
//				Process thisProcess = Process.GetCurrentProcess();
//				Console.WriteLine("Main Process time: {0}", thisProcess.TotalProcessorTime);
//			}
//
//			Task.Factory.StartNew (() => {
//				for (int i = 0; i < 1000; i++) {
//					Process threadProcess = Process.GetCurrentProcess();
//					Console.WriteLine("Thread Process time: {0}", threadProcess.TotalProcessorTime);
//				}
//			}).ContinueWith (task  => {
//			}, TaskScheduler.FromCurrentSynchronizationContext ());

			webView.MainFrame.LoadRequest(new NSUrlRequest(new NSUrl( "http://www.johnnygold.com")));
			webView.FinishedLoad += (object sender, WebFrameEventArgs e) => {
				string html = webView.StringByEvaluatingJavaScriptFromString("gebi('header').innerHTML");
				//Console.WriteLine("Work now? {0}", html);
			};

		}

		// Chat
		public void UpdateProgressBar(double newValue)
		{                       

			JobProgressBar = new NSProgressIndicator();
			  if (!NSThread.Current.IsMainThread)
                 {
                 using (var pool = new NSAutoreleasePool())
                 pool.BeginInvokeOnMainThread(delegate
                        // BeginInvokeOnMainThread(delegate
                    {

                        JobProgressBar.DoubleValue = newValue;
                        Console.WriteLine(" dentro del metodo");
                    });
                 }
               else
                {
                  JobProgressBar.DoubleValue = newValue;
                   Console.WriteLine("fuera del metodo");
                }
        }

		#endregion

		//strongly typed window accessor
		public new MainWindow Window
		{
			get
			{
				return (MainWindow)base.Window;
			}
		}

		public void showPrefs() 
		{
			Console.WriteLine("Preferences shown");
			ModalWindowController mwc = new ModalWindowController();
			NSApplication.SharedApplication.RunModalForWindow(mwc.Window);
		}
			
	}

	public class TestType
	{
		public string TestString {get; set;}
	}

	public class TestPBWrite : NSPasteboardReading
	{
		public override string[] GetReadableTypesForPasteboard(NSPasteboard pasteboard)
		{
			return new string[]{ NSPasteboard.NSUrlType};
		}

		public override NSPasteboardReadingOptions GetReadingOptionsForType(string type, NSPasteboard pasteboard)
		{
			var ro = NSPasteboardReadingOptions.AsString;

			return ro;

		}

		public override NSObject InitWithPasteboardPropertyList(NSObject propertyList, string type)
		{
			throw new NotImplementedException();
		}
	}
	
}

























