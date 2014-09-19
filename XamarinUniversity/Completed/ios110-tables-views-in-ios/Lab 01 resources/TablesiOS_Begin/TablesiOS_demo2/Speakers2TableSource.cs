using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TablesDemo
{
	public class SpeakersTableSource : UITableViewSource
	{		
		static readonly string speakerCellId = "SpeakerCell";
		List<Speaker> data;
		string[] indices; // array to show in index
		IGrouping<char, Speaker>[] grouping; // sub-group of speakers in each index
		
		public SpeakersTableSource (List<Speaker> speakers)
		{
			data = speakers;

			// TODO: Step 2b: get the filtered data
			indices = SpeakerIndicies ();
			grouping = GetSpeakersGrouped();
		}

		// TODO: Step 2c: implement NumberOfSections and SectionIndexTitles
		public override int NumberOfSections (UITableView tableView)
		{
			return indices.Count ();
		}

		public override string[] SectionIndexTitles (UITableView tableView)
		{
			return indices;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return grouping [section].Count ();
		}


		// TODO: Step 2a: filter the data by the first letter of each name
		// This method is required to generate the list of letters for the index
		public string[] SpeakerIndicies ()
		{
			var indicies = (from s in data 
			                orderby s.Name ascending
			                group s by s.Name [0] into g 
			                select g.Key.ToString ()).ToArray ();
			
			return indicies;
		}
		// This method groups the Speakers by their first letter
		IGrouping<char, Speaker>[] GetSpeakersGrouped ()
		{
			var speakersGrouped = (from s in data 
			                       orderby s.Name ascending
			                       group s by s.Name [0] into g 
			                       select g).ToArray ();
			
			return speakersGrouped;
		}




		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var speakerGroup = grouping [indexPath.Section];
			var speaker = speakerGroup.ElementAt (indexPath.Row);
			
			new UIAlertView ("Speaker Selected", speaker.Name, null, "OK", null).Show ();
			
			tableView.DeselectRow (indexPath, true);
		}
		

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (speakerCellId);
			
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, speakerCellId);
			
			var speakerGroup = grouping [indexPath.Section];
			var speaker = speakerGroup.ElementAt (indexPath.Row);
			
			cell.TextLabel.Text = speaker.Name;

			return cell;
		}
	}
}