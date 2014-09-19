using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CollectionViewDemo
{
	// class to use for supplementary view
	public class Header : UICollectionReusableView
	{
		UILabel label;

		// string to display in the label
		public string Text {
			set {
				label.Text = value;
			}
		}

		[Export ("initWithFrame:")]
		Header (RectangleF frame) : base (frame)
		{
			label = new UILabel (){
				Frame = new RectangleF (0,0,UIScreen.MainScreen.Bounds.Width, 50),  
				BackgroundColor = UIColor.Purple,
				TextColor = UIColor.White,
				TextAlignment = UITextAlignment.Center,
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth
			};

			AddSubview (label);
		}
	}
}