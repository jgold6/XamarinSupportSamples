using System;
using System.Drawing;
using Foundation;
using AppKit;
using ObjCRuntime;

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
	}
}

