
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Runtime.InteropServices;
using MonoMac;
using MonoMac.ObjCRuntime;

namespace Hello_Mac
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		protected int numberOfTimesClicked = 0;
		[DllImport(Constants.FoundationLibrary)]
		public static extern IntPtr NSHomeDirectory();

		public static string ContainerDirectory {
			get {
				return ((NSString)Runtime.GetNSObject(NSHomeDirectory())).ToString ();
			}
		}
		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
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

			ClickMeButton.Activated += (object sender, EventArgs e) => {
				numberOfTimesClicked++;
				OutputLabel.StringValue = ContainerDirectory;

			};
		}

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
	}
}

