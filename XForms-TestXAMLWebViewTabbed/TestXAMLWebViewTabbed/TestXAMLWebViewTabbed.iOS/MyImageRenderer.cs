using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreAnimation;

[assembly: ExportRenderer (typeof (Image), typeof (TestXAMLWebViewTabbed.iOS.MyImageRenderer))]

namespace TestXAMLWebViewTabbed.iOS
{
	public class MyImageRenderer : ImageRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (Control != null) {   // perform initial setup
				// do whatever you want to the UITextField here!

				CALayer layer = Control.Layer;
				var transform = CATransform3D.Identity;
				transform = CATransform3D.MakeRotation ((nfloat)(75 * Math.PI / 180.0f), 1f, 0f, 0f);
				transform.m34 = 1.0f / -500f;

				layer.Transform = transform;
			}
		}
    }
}

