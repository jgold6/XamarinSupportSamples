using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	public class SessionViewController : UIViewController
	{
		Session session;
		public SessionViewController (Session showSession)
		{
			session = showSession;
		}

		UILabel title, speaker, room;
		UIImageView background, favorite;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = session.Title;
			background = new UIImageView (UIImage.FromBundle ("images/Background"));
			View.Add (background);
			View.SendSubviewToBack (background);

			title = new UILabel (new RectangleF(10, 74, 320, 30));
			title.Font = UIFont.FromName("Avenir-Medium", 20.0f );
			title.BackgroundColor = UIColor.Clear;

			speaker = new UILabel (new RectangleF( 10, 104, 320, 30));
			speaker.Font = UIFont.FromName("Avenir-Light", 14.0f );
			speaker.BackgroundColor = UIColor.Clear;

			room = new UILabel (new RectangleF( 10, 134, 320, 30));
			room.Font = UIFont.FromName("Avenir-Light", 14.0f );
			room.TextColor = UIColor.DarkGray;
			room.BackgroundColor = UIColor.Clear;

			favorite = new UIImageView (new RectangleF (270, 104, 38, 38));
			favorite.Image = UIImage.FromBundle ("images/favorited");

			View.Add (title);
			View.Add (speaker);
			View.Add (room);
			View.Add (favorite);

			title.Text = session.Title;
			speaker.Text = session.Speaker;
			room.Text = session.Location;
		}
	}
}

