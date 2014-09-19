using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.IO;
using MonoTouch.ObjCRuntime;

namespace Homepwner
{
	public static class BNRImageStore : object
	{
		public static Dictionary<string, UIImage> dictionary = new Dictionary<string, UIImage>();

		public static void setImage(UIImage i, string s)
		{
			dictionary.Add(s, i);

			// Create full path for image
			string imagePath = imagePathForKey(s);

			// Turn image into JPG/PNG data.
			NSData d = i.AsJPEG(0.5f);

			// Write it to the full path
			NSError error = new NSError(new NSString("ImageSaveError"), 404);
			d.Save(imagePath, NSDataWritingOptions.Atomic, out error);
		}

		public static UIImage imageForKey(string s)
		{
			if (s == ".thumbnail")
				return null;
			UIImage image;
			// Is image in dictionary?
			if (!dictionary.TryGetValue(s, out image)) {
				image = UIImage.FromFile(imagePathForKey(s)); // No, load from file system
				// Did we find an image on the file system?
				if (image != null)
					dictionary.Add(s, image);
				else
					Console.WriteLine("Error: unable to find {0}", imagePathForKey(s));

			}
			return image;
		}

		public static void deleteImageForKey(string s)
		{
			if (s == "") {
				return;
			}
			dictionary.Remove(s);

			string path = imagePathForKey(s);
			NSError error = new NSError(new NSString("ImageDeleteError"), 504);
			NSFileManager.DefaultManager.Remove(path, out error);
		}

		public static string imagePathForKey(string key)
		{
			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);

			// Get one and only document directory from that list
			string documentDirectory = documentDirectories[0];
			return Path.Combine(documentDirectory, key);
		}

		public static void clearCache()
		{
			Console.WriteLine("Clearing {0} images from the cache", dictionary.Count);
			dictionary.Clear();
		}
	}
}

