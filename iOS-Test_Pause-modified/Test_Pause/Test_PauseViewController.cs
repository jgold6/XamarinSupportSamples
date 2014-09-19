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
using MonoTouch.CoreFoundation;

using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Test_Pause
{
	public partial class Test_PauseViewController : UIViewController
	{
		public Test_PauseViewController () : base ("Test_PauseViewController", null)
		{
		}

//		AppDelegate appDel = (AppDelegate)UIApplication.SharedApplication.Delegate;

		UIView TestViewKeyFrameAnim;
		double pauseTime = 0;                   // added
		double timeSincePause = 0;              // added

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



			// TO XAMARIN SUPPORT //
			// Run the app, the animation will start immediatly.  Press the pause button, it pauses correctly.  Press the resume button, it resumes correctly. 
			// But when you press the pause button again it pauses at a position as if it had never been paused in the first place!  I can almost understand what it's doing, but I'm not sure how to get the desired result. 
			// The desired result being when you pause it the second time it halts exactly where it is (rather than jumping ahead)

			TestViewKeyFrameAnim = new UIView(new RectangleF(0, 0, 100, 100));
			TestViewKeyFrameAnim.Center = new PointF(100, 100);
			TestViewKeyFrameAnim.BackgroundColor = UIColor.Red;
			View.AddSubview(TestViewKeyFrameAnim);


			AnimationKeyFrame(TestViewKeyFrameAnim);


			UIButton PauseButton = new UIButton(new RectangleF(190, 100, 70, 50));
			PauseButton.BackgroundColor = UIColor.Green;
			PauseButton.Layer.CornerRadius = 9f;
			PauseButton.SetTitle("Pause", UIControlState.Normal);
			View.AddSubview(PauseButton);
			PauseButton.TouchUpInside += delegate(object sender, EventArgs e) {
				pauseTime = TestViewKeyFrameAnim.Layer.ConvertTimeFromLayer(CAAnimation.CurrentMediaTime(), TestViewKeyFrameAnim.Layer); // removed double
				TestViewKeyFrameAnim.Layer.Speed = 0.0f;
				TestViewKeyFrameAnim.Layer.TimeOffset = pauseTime - timeSincePause; // added - timeSincePause
			};


			UIButton ResumeButton = new UIButton(new RectangleF(285, 100, 70, 50));
			ResumeButton.BackgroundColor = UIColor.Red;
			ResumeButton.Layer.CornerRadius = 9f;
			ResumeButton.SetTitle("Resume", UIControlState.Normal);
			View.AddSubview(ResumeButton);
			ResumeButton.TouchUpInside += delegate(object sender, EventArgs e) {
				pauseTime = TestViewKeyFrameAnim.Layer.TimeOffset; // removed double
				TestViewKeyFrameAnim.Layer.Speed = 1.0f;
				TestViewKeyFrameAnim.Layer.TimeOffset = 0.0f;
				TestViewKeyFrameAnim.Layer.BeginTime = 0.0f;
				timeSincePause = (TestViewKeyFrameAnim.Layer.ConvertTimeFromLayer(CAAnimation.CurrentMediaTime(), TestViewKeyFrameAnim.Layer) - pauseTime); // removed double
				TestViewKeyFrameAnim.Layer.BeginTime = timeSincePause;
			};
		}


		public void AnimationKeyFrame( UIView view )
		{	
			CAKeyFrameAnimation newAnimation = CAKeyFrameAnimation.GetFromKeyPath ("position");
			CGPath path = new CGPath();
			path.MoveToPoint(new PointF(100, 100));
			path.AddLineToPoint(new PointF(400, 400));
			newAnimation.Path = path;
			newAnimation.Duration = 10;
			newAnimation.AnimationStarted += delegate(object sender, EventArgs e) {
				Console.WriteLine("newAnimation Started");
			};
			newAnimation.AnimationStopped += delegate(object sender, CAAnimationStateEventArgs e) {
				Console.WriteLine("newAnimation Stopped " + e.Finished);
			};
			view.Layer.AddAnimation(newAnimation, "position");  
		}
//
//
//		public void AnimationUIViewAnim( UIView view )
//		{	
//			NSAction animation = new NSAction(delegate {
//				CGAffineTransform transform = CGAffineTransform.MakeIdentity();
//				transform.Translate(400, 400);
//				view.Transform = transform;
//			});
//
//
//			UIView.Animate(10, animation);
//		}
	}
}

