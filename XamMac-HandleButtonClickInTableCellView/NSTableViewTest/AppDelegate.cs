using AppKit;
using Foundation;

namespace NSTableViewTest
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		static readonly MainWindowController mainWindowController = new MainWindowController ();
		private MainTableViewController m_mainTableView = new MainTableViewController ();

		public AppDelegate ()
		{
		}

		public override void DidFinishLaunching (NSNotification notification)
		{
			mainWindowController.Window.MakeKeyAndOrderFront (this);
			m_mainTableView.View.Frame = mainWindowController.Window.ContentView.Bounds;
			mainWindowController.Window.ContentView.AddSubview (m_mainTableView.View);
		}

		public override void WillTerminate (NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}
