using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;		// Required for File IO
using System.Xml;		// For XML parsing
using System.Text;
using System.Runtime.InteropServices;		// Alloc and Free for unmanaged memory and unsafe code

using MonoTouch.Foundation;
using MonoTouch.AVFoundation;		// Play mp3 music
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;
using MonoTouch.OpenGLES;
using MonoTouch.UIKit;
using MonoTouch.AudioToolbox;		// Play sound effects .aif or .caf
using MonoTouch.CoreImage;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Test_Pause
{
	public partial class NewViewController : UIViewController
	{
		public NewViewController () : base ("NewViewController", null)
		{
		}

		AppDelegate appDel = (AppDelegate)UIApplication.SharedApplication.Delegate;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.


			UIImageView backroudnImage = new UIImageView(View.Bounds);
			backroudnImage.BackgroundColor = UIColor.Green;
			View.AddSubview(backroudnImage);


			UIButton ReturnButton = new UIButton(new RectangleF(50, 50, 100, 100));
			ReturnButton.BackgroundColor = UIColor.Blue;
			ReturnButton.SetTitle("Resume", UIControlState.Normal);
			View.AddSubview(ReturnButton);
			ReturnButton.TouchUpInside += delegate(object sender, EventArgs e) {
				appDel.NavigationController.PopViewControllerAnimated(false);
			};
		}
	}
}

