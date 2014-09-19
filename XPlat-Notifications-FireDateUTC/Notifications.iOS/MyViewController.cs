namespace Notifications
{
    using System;
    using System.Drawing;

    using MonoTouch.UIKit;

    public class MyViewController : UIViewController
    {
        private readonly float buttonHeight = 50;
        private readonly float buttonWidth = 300;
        private UIButton _button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            AddButtonToView();

            _button.TouchUpInside += (sender, e) =>
			 {
			     //---- create the notification
			     var notification = new UILocalNotification();

			     //---- set the fire date (the date time in which it will fire)
			     notification.FireDate = DateTime.Now.AddSeconds(15);
				Console.WriteLine("Fire Date: " + notification.FireDate.ToString());
				Console.WriteLine("DTNow Date: " + DateTime.Now.ToLocalTime());
				Console.WriteLine("DTNow UTC: " + DateTime.Now.ToUniversalTime());

			     //---- configure the alert stuff
				 notification.AlertAction = "View 15 second Alert";
				 notification.AlertBody = "Your 15 second alert has fired!";

			     //---- modify the badge
			     notification.ApplicationIconBadgeNumber = 1;

			     //---- set the sound to be the default sound
			     notification.SoundName = UILocalNotification.DefaultSoundName;

			     //---- schedule it
			     UIApplication.SharedApplication.ScheduleLocalNotification(notification);
			 };
        }

        private void AddButtonToView()
        {
            _button = UIButton.FromType(UIButtonType.RoundedRect);

            _button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                View.Frame.Height / 2 - buttonHeight / 2,
                buttonWidth,
                buttonHeight);
            _button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                                       UIViewAutoresizing.FlexibleBottomMargin;
            _button.SetTitle("Add notification", UIControlState.Normal);
            _button.ContentMode = UIViewContentMode.ScaleToFill;

            View.AddSubview(_button);
        }
    }
}
