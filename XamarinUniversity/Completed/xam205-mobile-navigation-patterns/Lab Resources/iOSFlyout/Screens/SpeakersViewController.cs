using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.ios.flyout
{
	public class SpeakersViewController : EvolveFlyoutTableViewControllerBase
	{
		List<Speaker> speakers;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Title = "Speakers";

			speakers = EvolveData.SpeakerData;
			TableView.Source = new SpeakersTableSource (speakers, this);
		}
	}
}