using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace XamMacTestProject
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		MainWindowController mainWindowController;

		public AppDelegate()
		{
		}

		public override void FinishedLaunching(NSObject notification)
		{
			mainWindowController = new MainWindowController();
			mainWindowController.Window.MakeKeyAndOrderFront(this);
		}

		partial void showPrefs (MonoMac.Foundation.NSObject sender)
		{
			mainWindowController.showPrefs();
		}

		partial void showAbout (MonoMac.Foundation.NSObject sender)
		{
			Console.WriteLine("About shown");
			ModalWindowController mwc = new ModalWindowController();
			NSApplication.SharedApplication.RunModalForWindow(mwc.Window);
		}
			
	}
}

