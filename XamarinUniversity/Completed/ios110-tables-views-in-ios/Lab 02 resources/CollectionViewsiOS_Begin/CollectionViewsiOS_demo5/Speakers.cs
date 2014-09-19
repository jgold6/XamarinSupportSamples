using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MonoTouch.Foundation;

namespace CollectionViewDemo
{
	// Loads a collection of speakers containing file paths of speaker images
	public class Speakers : List<Speakers.Speaker>
	{
		public Speakers ()
		{
			Regex pattern = new Regex (@"^.*\.(jpg|png)$", RegexOptions.IgnoreCase);
			string path = Path.Combine (NSBundle.MainBundle.BundlePath, "speakers");

			Directory.GetFiles (path).Where (f => pattern.IsMatch (f)).ToList ().ForEach (p => {
				Speaker s = new Speaker{ ImageFile = "speakers/" + Path.GetFileName (p) };
				this.Add (s);
			});
		}

		public class Speaker
		{
			public string ImageFile { get; set; }
		}
	}
}