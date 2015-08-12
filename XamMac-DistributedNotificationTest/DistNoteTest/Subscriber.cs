using System;
using Foundation;
using ObjCRuntime;

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

