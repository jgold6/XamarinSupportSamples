using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;

namespace ViewTest1
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{


		private const float SEPARATION = 5.0f;
		private const float BOX_WIDTH = 80.0f;
		private const float BOX_HEIGHT = 80.0f;
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			NSView docView = scrolloutlet.DocumentView as NSView;
			docView.SetFrameSize(new SizeF(scrolloutlet.ContentView.Frame.Size.Width, scrolloutlet.ContentView.Frame.Size.Height));

			//NSScrollView scrollView = EnclosingScrollView;
			//NSScrollView scrollView = scrolloutlet;
			//	if (scrollView == null) 
			//		return;
			//scrollView.ScrollsDynamically = true;
			//scrollView.HasHorizontalRuler = true;
			//scrollView.HasVerticalRuler = true;
			//scrollView.RulersVisible = true;
			//addbtn.BezelStyle = NSBezelStyle.RoundedDisclosure;
			  addbtn.KeyEquivalent = "\r";
			//addbtn.NeedsDisplay = true;

		}

		public void layout()
		{
			NSView[] subviews = simpleview.Subviews;
			PointF curPoint;
			//Console.WriteLine (simpleview.Bounds.Size.Width.ToString ());
			//curPoint = new PointF(simpleview.Bounds.Size.Width/2.0f, 0.0f);

			curPoint = new PointF(simpleview.Bounds.Size.Width/2.0f,simpleview.Bounds.Size.Height/1.10f);
			//curPoint = new PointF (0.0f, 485.0f);
			//curPoint = new PointF(0.0f, 0.0f);

			foreach (NSView subview in subviews) 
			{
				RectangleF frame = new RectangleF (curPoint.X - 442.0f / 2.0f, curPoint.Y, 442.0f, 35.0f);
				animateView (subview, frame);
				curPoint.Y -= frame.Size.Height + SEPARATION;
				//curPoint.X += frame.Size.Width + SEPARATION;

			}

		}



		/* This method returns a rect that is integral in base coordinates. */
		private RectangleF integralRect (RectangleF rect) 
		{
			// missing NSIntegralRect
			//return simpleView.ConvertRectFromBase(NSIntegralRect(simpleView.ConvertRectToBase(rect)));
			return simpleview.ConvertRectFromBase(simpleview.ConvertRectToBase(rect));	
		}


		// Helper method to animate the sub view
		private void animateView(NSView subView, RectangleF toFrame) 
		{
			#if true
			// Simple animation: assign the new value, and let CoreAnimation
			// take it from here

			((NSView) subView.Animator).Frame = toFrame;
			scrolloutlet.ContentView.ScrollRectToVisible(toFrame);


			#else
			//
			// Performing the animation by hand, every step of the way
			//
			var animationY = CABasicAnimation.FromKeyPath("position.y");
			animationY.To = NSNumber.FromFloat(toFrame.Y);
			animationY.AnimationStopped += delegate {
			//Console.WriteLine("animation stopped");
			subView.Layer.Frame = toFrame;
			};

			var animationX = CABasicAnimation.FromKeyPath("position.x");
			animationX.To = NSNumber.FromFloat(toFrame.X);

			animationY.AutoReverses = false;
			animationX.AutoReverses = false;

			animationY.RemovedOnCompletion = false;
			animationX.RemovedOnCompletion = false;

			animationY.FillMode = CAFillMode.Forwards;
			animationX.FillMode = CAFillMode.Forwards;

			subView.Layer.AddAnimation(animationX,"moveX");
			subView.Layer.AddAnimation(animationY,"moveY");
			#endif
		}


		partial void Addbutton (NSObject sender)
		{
			UserControlController ucc = new UserControlController(DateTime.Now.ToString());
			simpleview.AddSubview(ucc.View);
			NSView docView = scrolloutlet.DocumentView as NSView;
			docView.SetFrameSize(new SizeF(docView.Frame.Size.Width, docView.Frame.Size.Height + ucc.View.Frame.Height));
			layout();
			//popover.Show(RectangleF.Empty,(NSView)sender,NSRectEdge.MaxYEdge);
		
			/*UserControlController user= new UserControlController("Prerana");
			NSPopover pop= new NSPopover();
			pop.ContentViewController= user;
			pop.Behavior=NSPopoverBehavior.Semitransient;
			pop.Show(RectangleF.Empty,(NSView)sender,NSRectEdge.MaxYEdge);
           */
		}

		partial void RefreshAction (NSObject sender)
		{
			layout();
		

		}





	}
}

