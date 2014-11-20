using System;
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

namespace DistNoteTest
{
	public class Subscriber : NSObject
	{
		public Subscriber() 
		{
		}
			
		[Export("handleNotification:")]
		public void HandleNotification(NSNotification notification)
		{
			var notificationString = notification.Object as NSString;
			Console.WriteLine ("Receiving: " + notificationString);
		}
	}
}

