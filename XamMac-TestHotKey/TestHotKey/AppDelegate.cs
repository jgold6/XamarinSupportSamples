using System;

using Foundation;
using AppKit;

namespace TestHotKey
{
    public partial class AppDelegate : NSApplicationDelegate
    {
        MainWindowController mainWindowController;
		NSObject mEventMonitorLocal;
		NSObject mEventMonitorGlobal;

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            mainWindowController = new MainWindowController();
            mainWindowController.Window.MakeKeyAndOrderFront(this);

			mEventMonitorLocal = NSEvent.AddLocalMonitorForEventsMatchingMask(NSEventMask.KeyDown, delegate (NSEvent theEvent) {
				Console.WriteLine("Key Handled Local: {0}", theEvent.KeyCode);
				return theEvent;
			});


			mEventMonitorGlobal = NSEvent.AddGlobalMonitorForEventsMatchingMask(NSEventMask.KeyDown, delegate (NSEvent theEvent) {
				Console.WriteLine("Key Handled Global: {0}", theEvent.KeyCode);
			});

        }

		public override void WillTerminate(NSNotification notification)
		{
			NSEvent.RemoveMonitor(mEventMonitorLocal);
			NSEvent.RemoveMonitor(mEventMonitorGlobal);
		}
    }
}

