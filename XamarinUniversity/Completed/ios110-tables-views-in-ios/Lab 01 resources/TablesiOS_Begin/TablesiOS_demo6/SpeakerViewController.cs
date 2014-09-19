using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	public class SpeakerViewController : UIViewController
	{
		Speaker speaker;
		public SpeakerViewController (Speaker showSpeaker)
		{
			speaker = showSpeaker;
		}

		UILabel name, company;
		UIImageView avatar;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = speaker.Name;
			View.BackgroundColor = UIColor.White;

			name = new UILabel (new RectangleF(10, 74, 200, 30));
			name.Text = speaker.Name;
			name.Font = UIFont.BoldSystemFontOfSize (20f);

			company = new UILabel (new RectangleF( 10, 104, 200, 30));

			avatar = new UIImageView (new RectangleF (230, 74, 75, 75));

			View.Add (name);
			View.Add (company);
			View.Add (avatar);

			name.Text = speaker.Name;
			company.Text = speaker.Company;
			avatar.Image = UIImage.FromBundle (speaker.HeadshotUrl);

		}
	}
}

