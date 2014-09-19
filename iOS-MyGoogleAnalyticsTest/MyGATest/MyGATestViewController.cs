using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleAnalytics;
using MonoTouch.CoreData;
using MonoTouch.SystemConfiguration; 

namespace MyGATest
{
	public partial class MyGATestViewController : UIViewController
	{

		public MyGATestViewController () : base ("MyGATestViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		var tracker = GAI.SharedInstance.DefaultTracker;
			// Perform any additional setup after loading the view, typically from a nib.
			this.b1out.TouchUpInside += (sender, e) => {

				tracker.Send(GAIDictionaryBuilder.CreateEventWithCategory("ui_action", "button_press", "btn1", 0).Build());
				Console.WriteLine ("Button 1 clicked");
			};
			b2out.TouchUpInside += (sender, e) => {
				tracker.Send(GAIDictionaryBuilder.CreateEventWithCategory("ui_action", "button_press", "btn2", 0).Build());
				Console.WriteLine ("Button 2 clicked");
			};
			b3out.TouchUpInside += (sender, e) => {
				tracker.Send(GAIDictionaryBuilder.CreateEventWithCategory("ui_action", "button_press", "btn3", 0).Build());
				Console.WriteLine ("Button 3 clicked");
			};


		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

