using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Empty1
{
    public class OptionsView : UIViewController
    {
        UIButton manualButton;
        UIButton autoButton;
        SimpleView simpleView;

        float buttonWidth = 200;
        float buttonHeight = 50;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            float Y = 100;
            manualButton = UIButton.FromType(UIButtonType.RoundedRect);
            manualButton.Frame = new RectangleF(
                (View.Frame.Width / 2) - (buttonWidth / 2),
                Y,
                buttonWidth,
                buttonHeight);
            manualButton.SetTitle("Manual Layout", UIControlState.Normal);
            manualButton.TouchUpInside += (sender, e) =>
                {
                    if (simpleView != null)
                        simpleView.Dispose();
                    simpleView = new SimpleView(false);
                    this.NavigationController.PushViewController(simpleView, true);
                };
            Y += buttonHeight + Physics.VSpacing;
            autoButton = UIButton.FromType(UIButtonType.RoundedRect);
            autoButton.Frame = new RectangleF(
                (View.Frame.Width / 2) - (buttonWidth / 2),
                Y,
                buttonWidth,
                buttonHeight);
            autoButton.SetTitle("Auto Layout", UIControlState.Normal);
            autoButton.TouchUpInside += (sender, e) =>
                {
                    if (simpleView != null)
                        simpleView.Dispose();
                    simpleView = new SimpleView(true);
                    this.NavigationController.PushViewController(simpleView, true);
                };
            View.AddSubviews(manualButton, autoButton);
        }
    }
}