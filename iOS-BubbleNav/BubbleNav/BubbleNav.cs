using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;

namespace People
{
	public class BubbleNav : UIView
	{
//		public BubbleNavViewController NavHeadController;

		public UIImage _image;
		public UIImageView _imageView;

		public AnimType AnimInProgressType;
		public AnimType AnimStacked;

		private SelectionLayer layerSelection;

		public enum AnimType {
			None,
			GenieIn,
			GenieOut
		}

		public BubbleNav (UIImage image) : base()
		{

			_image = image;
			_imageView = new UIImageView (_image);

			Setup (image);
		}

		public BubbleNav (RectangleF frame,UIImage image) : base(frame)
		{
			_image = image;
			Setup (image);
		}

		public void Setup(UIImage image)
		{
			if (image == null) {
				_image = UIImage.FromBundle ("testImage.png");
				_imageView = new UIImageView (_image);
			} else {
				_image = image;
				_imageView = new UIImageView (_image);
			}

			Opaque = false;

			// Moved to ViewController 
//			UITapGestureRecognizer tapBubbleGesture = new UITapGestureRecognizer (() => {
//				Console.WriteLine ("Tapped");
//
//
//				if (NavHeadController != null) {
//					ShowSelection ();
//					//NavHeadController.HideMenu ();
//				}
//
//			});

//			AddGestureRecognizer (tapBubbleGesture);

			// SelectionLayer

			TintSelectionColor = UIColor.DarkGray;

			layerSelection = new SelectionLayer (this);
			layerSelection.BubbleNavProgress = 90;
			//layerSelection.BackgroundColor = TintColor.CGColor;
			this.Layer.AddSublayer(layerSelection);

			layerSelection.SetNeedsDisplay ();

	
		}

		private UIColor tintSelectionColor;
		public UIColor TintSelectionColor {
			get {
				return tintSelectionColor;
			}
			set{
				tintSelectionColor = value;
			}
		}


		public override void Draw (System.Drawing.RectangleF rect)
		{
			base.Draw (rect);
			if (_imageView != null) 
				_imageView.Draw (rect);

		}

		public static string BubbleNavProgressKey = "BubbleNavProgress";

		public void ShowSelection()
		{

			layerSelection.BubbleNavProgress = 450;

			layerSelection.RemoveAnimation (BubbleNavProgressKey);

			var basicAnimation = CABasicAnimation.FromKeyPath (BubbleNavProgressKey);
			basicAnimation.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);

			basicAnimation.From = NSNumber.FromInt32 (90);
			basicAnimation.To =  NSNumber.FromInt32 (450);
			basicAnimation.Duration = 1;

			layerSelection.AddAnimation (basicAnimation, BubbleNavProgressKey);
			layerSelection.SetNeedsDisplay ();
		}

		public void HideSelection ()
		{
			layerSelection.BubbleNavProgress = 90;

			layerSelection.RemoveAnimation (BubbleNavProgressKey);

			var basicAnimation = CABasicAnimation.FromKeyPath (BubbleNavProgressKey);
			basicAnimation.TimingFunction = CAMediaTimingFunction.FromName (CAMediaTimingFunction.EaseInEaseOut);

			basicAnimation.From = NSNumber.FromInt32 (90);
			basicAnimation.To =  NSNumber.FromInt32 (450);
			basicAnimation.Duration = 1;

			layerSelection.AddAnimation (basicAnimation, BubbleNavProgressKey);
			layerSelection.SetNeedsDisplay ();
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			if (layerSelection != null) {
				layerSelection.Frame = new RectangleF (0, 0 , this.Bounds.Width, this.Bounds.Height );

				Layer.InsertSublayer (layerSelection,1);
			}
		}

	}

	/***************************************************************
	 * Selection Effect on the border
	 ***************************************************************/
	 
	public class SelectionLayer : CALayer
	{
		int progress;

		BubbleNav Bubble;
		public SelectionLayer(BubbleNav bubble) : base()
		{
			this.Bubble = bubble;
		}

		[Export ("BubbleNavProgress")]
		public int BubbleNavProgress { 
		get
			{
				return progress;
			} 
		set {
				Console.WriteLine ("Progress {0}",progress);
				progress = value;
				SetNeedsDisplay ();
			}
		 }

		public virtual bool NeedsDisplayForKey (string key)
		{
			Console.WriteLine ("NeedDisplay");
			if (key.Equals (BubbleNav.BubbleNavProgressKey))
				return true;

			return CALayer.NeedsDisplayForKey (key);

		}

		private float DegreeToRadian(double angle)
		{
			return (float)(Math.PI * angle / 180.0);
		}

		public override void DrawInContext (MonoTouch.CoreGraphics.CGContext ctx)
		{
			base.DrawInContext (ctx);
			Console.WriteLine ("DrawInContext");


			RectangleF rect = this.Bounds;
			PointF centerPoint = new PointF (rect.Width / 2, rect.Height / 2);
			float radius = 32;
			float innerRadius = 28;

			// draw selection
			ctx.SetFillColor (this.Bubble.TintSelectionColor.CGColor);
			CGPath path = new CGPath ();
			path.MoveToPoint (centerPoint);
			path.AddArc (centerPoint.X,centerPoint.Y,radius,DegreeToRadian(90),DegreeToRadian(BubbleNavProgress),false);
			path.CloseSubpath ();
			ctx.AddPath (path);
			ctx.FillPath ();

			// clear the inside
			ctx.SetBlendMode (CGBlendMode.Clear);
			RectangleF clearRect = new RectangleF (centerPoint.X - innerRadius, centerPoint.Y -innerRadius, innerRadius*2, innerRadius*2);
			ctx.AddEllipseInRect (clearRect);
			ctx.FillPath ();

			if (progress < 450)
				SetNeedsDisplay ();

		}

	}
















}


