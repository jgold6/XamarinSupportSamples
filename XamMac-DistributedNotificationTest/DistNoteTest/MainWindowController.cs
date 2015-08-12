
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using ObjCRuntime;
using System.Threading.Tasks;

namespace DistNoteTest
{
    public partial class MainWindowController : AppKit.NSWindowController
    {
		public static string notificationName = "sweetspot.fetch.event";
		private static NSString NSNotificationName = new NSString(notificationName);
		private static string handleNotificationName = "handleNotification:";
		private static Selector handleNotificationSelector = new Selector (handleNotificationName);
//		private static NotificationSpy spy;

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

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			Console.WriteLine ("Listening for Local Notifications");
			StartListeningForLocalNotifications ();

			Console.WriteLine ("Listening for Distributed Notifications");
			StartListeningForDistributedNotifications();


			Task.Run(()=>{
				while (true) {
					System.Threading.Thread.Sleep(2000);
					var distMsg = "Local Notification: " + Guid.NewGuid ().ToString ();
					Console.WriteLine ("Sending: " + distMsg);
					SendLocalNotification (distMsg);

					System.Threading.Thread.Sleep(2000);
					var localMsg = "Distributed Notification: " + Guid.NewGuid().ToString();
					Console.WriteLine ("Sending: " + localMsg);
					SendDistributedNotification (localMsg);
				}
			});

		}

		public static void StartListeningForDistributedNotifications()
		{
			var center = getDistributedNotificationCenter ();
			var subscriber = new Subscriber ();

			// The sample Objective-C is working, where notificationHandler: is a method that takes a NSNotification* 
			// trying to make similar observation work in Xamarin without luck
			//[[NSDistributedNotificationCenter defaultCenter] addObserver:self
			//	selector:@selector(notificationHandler:)
			//	name:@"sweetspot.fetch.event" object:nil ];

			// the following includes many different AddObserver combinations based on incomplete documentation here:
			// http://macapi.xamarin.com/?link=T%3aMonoMac.Foundation.NSDistributedNotificationCenter%2fM

			// listen using DeliveryImmediately behavior
			center.AddObserver(subscriber, handleNotificationSelector, notificationName, null, NSNotificationSuspensionBehavior.DeliverImmediately);


			// listen with null anObject
			//			center.AddObserver(subscriber, handleNotificationSelector, notificationName, null);
			//
			//			// listen with NSString, and empty NSString fromObject
			//			center.AddObserver(subscriber, handleNotificationSelector, notificationName, new NSString());
			//
			//			// listen with NSString, delegate and null fromObject
			//			center.AddObserver (NSNotificationName, subscriber.HandleNotification, null);
			//
			//			// listen with NSString, delegate and empty NSString fromObject
			//			center.AddObserver (NSNotificationName, subscriber.HandleNotification, new NSString());
		}

		public static void StartListeningForLocalNotifications()
		{
			var center = getLocalNotificationCenter ();
			var subscriber = new Subscriber ();
			center.AddObserver(subscriber, handleNotificationSelector, new NSString(notificationName), null);
		}

		public static void SendDistributedNotification(string payload)
		{
			var center = getDistributedNotificationCenter ();

			//center.PostNotificationName(notificationName, payload, null, true);

			center.PostNotificationName(notificationName, new NSString(payload));
		}

		public static void SendLocalNotification(string payload)
		{
			var center = getLocalNotificationCenter ();
			center.PostNotificationName (notificationName, new NSString(payload));
		}

		private static NSDistributedNotificationCenter getDistributedNotificationCenter()
		{
			return (NSDistributedNotificationCenter)NSDistributedNotificationCenter.DefaultCenter;
		}

		private static NSNotificationCenter getLocalNotificationCenter()
		{
			return NSNotificationCenter.DefaultCenter as NSNotificationCenter;
		}
    }

//	public class NotificationSpy : NSObject
//	{
//		public bool g_spying = false;
//
//		public void StartSpying()
//		{
//			if (!g_spying) {
//				NSNotificationCenter center = NSNotificationCenter.DefaultCenter;
//				center.AddObserver(this, new Selector("observeDefaultCenterStuff:"), MainWindowController.notificationName, null);
//
//				center = NSWorkspace.SharedWorkspace.NotificationCenter;
//				center.AddObserver(this, new Selector("observeWorkspaceStuff:"), MainWindowController.notificationName, null);
//
//				var distCenter = (NSDistributedNotificationCenter)NSDistributedNotificationCenter.DefaultCenter;
////				distCenter.PerformSelector(new Selector("notificationCenterForType:"), NSDistributedNotificationCenter.NSLocalNotificationCenterType, 0.0);
//				distCenter.AddObserver(this, new Selector("observeDistributedStuff:"), MainWindowController.notificationName, null);
//
//				g_spying = true;
//			}
//		}
//
//		public void StopSpying()
//		{
//			if (g_spying) {
//				NSNotificationCenter center = NSNotificationCenter.DefaultCenter;
//				center.RemoveObserver(this);
//
//				center = NSWorkspace.SharedWorkspace.NotificationCenter;
//				center.RemoveObserver(this);
//
//				var distCenter = NSDistributedNotificationCenter.DefaultCenter as NSDistributedNotificationCenter;
//				distCenter.PerformSelector(new Selector("notificationCenterForType:"), NSDistributedNotificationCenter.NSLocalNotificationCenterType, 0.0);
//				distCenter.RemoveObserver(this);
//
//			}
//			g_spying = false;
//		}
//
//		[Export("observeDefaultCenterStuff:")]
//		public void ObserverLocal (NSNotification notification)
//		{
//			Console.WriteLine("Local notification: {0}", notification.Object);
//		}
//
//		[Export("observeWorkspaceStuff:")]
//		public void ObserverWorkspace (NSNotification notification)
//		{
//			Console.WriteLine("WorkSpace notification: {0}", notification.Object);
//		}
//
//		[Export("observeDistributedStuff:")]
//		public void ObserverDist (NSNotification notification)
//		{
//			Console.WriteLine("Distributed notification: {0}", notification.Object);
//		}
//	}
}

