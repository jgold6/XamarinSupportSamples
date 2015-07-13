using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreAnimation;

[assembly: ExportRenderer (typeof (TestXAMLWebViewTabbed.MyLabel), typeof (TestXAMLWebViewTabbed.iOS.MyLabelRenderer))]

namespace TestXAMLWebViewTabbed.iOS
{
    public class MyLabelRenderer : LabelRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null) {   // perform initial setup
				// do whatever you want to the UITextField here!
				Control.TextColor = UIColor.Red;

				CALayer layer = Control.Layer;
				var transform = CATransform3D.Identity;
				transform = CATransform3D.MakeRotation ((nfloat)(75 * Math.PI / 180.0f), 0, 1f, 0f);
				transform.m34 = 1.0f / -500f;

				layer.Transform = transform;
			}
		}
    }
}

