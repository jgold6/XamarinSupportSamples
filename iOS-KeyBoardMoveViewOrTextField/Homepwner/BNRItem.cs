using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using SQLite;

namespace Homepwner
{
	[Table("BNRItems")]
	public class BNRItem
	{
		[PrimaryKey, AutoIncrement, MaxLength(8)]
		public int ID {get; set;}
		public string imageKey {get; set;}
		public string itemName {get; set;}
		public string serialNumber {get; set;}
		public int valueInDollars {get; set;}
		public DateTime dateCreated {get; set;} 
//		UIImage thumbnail; // no sql move to image store  // Archiving method of saving
//		public NSData thumbnailData {get; set;} // no sql move to image store // Archiving method of saving
		public double orderingValue {get; set;} // For SQL method of saving
		[MaxLength(50)]
		public string assetType {get; set;}

//		public UIImage Thumbnail() // Archiving method of saving
//		{ // Archiving method of saving
//			// if there is no thumbnailData, then I have no thumbnail to return // Archiving method of saving
//			if (thumbnailData == null) { // Archiving method of saving
//				return null; // Archiving method of saving
//			} // Archiving method of saving
// // Archiving method of saving
//			// If I have not yet created my thumbnail image from my data, do so now // Archiving method of saving
//			if (thumbnail == null) { // Archiving method of saving
//				// create the image form the data // Archiving method of saving
//				thumbnail = UIImage.LoadFromData(thumbnailData); // Archiving method of saving
//			} // Archiving method of saving
//			return thumbnail; // Archiving method of saving
//		} // Archiving method of saving

//		static Random random = new Random((int)DateTime.Now.Ticks); // Archive method of saving

		public BNRItem(string name, int value, string serial)
		{
			itemName = name;
			serialNumber = serial;
			valueInDollars = value;
			dateCreated = DateTime.Now;
		}

		public BNRItem(string name, string serial) : this(name, 0, serial)
		{
		}

		public BNRItem(string name) : this(name, 0, "")
		{
		}

		public BNRItem() : this("Item", 0, "")
		{
		}

		public UIImage getThumbnailFromImage(UIImage image)  // Return void for Archiving method of saving
		{
			SizeF origImageSize = image.Size;

			// The Rectangle of the thumbnail
			RectangleF newRect = new RectangleF(0, 0, 40, 40);

			// Figure out a scaling ration to make sure we maintain the same aspect ratio
			float ratio = Math.Max(newRect.Size.Width / origImageSize.Width, newRect.Size.Height / origImageSize.Height);

			// Create a transparent bitmap context with a scaling factor equal to that of the screen
			UIGraphics.BeginImageContextWithOptions(newRect.Size, false, 0.0f);

			// Create a path that is a rounded rectangle
			UIBezierPath path = UIBezierPath.FromRoundedRect(newRect, 5.0f);
			// Make all subsequent drawing clip to this rounded rectangle
			path.AddClip();

			// Center the image in the thumbnail rectangle
			RectangleF projectRect = new RectangleF();
			projectRect.Width = ratio * origImageSize.Width;
			projectRect.Height = ratio * origImageSize.Height;
			projectRect.X = (newRect.Size.Width - projectRect.Size.Width) / 2.0f;
			projectRect.Y = (newRect.Size.Height - projectRect.Size.Height) / 2.0f;

			// Draw the image to the context
			image.Draw(projectRect);

			// Get the image from the image context, keep it as our thumbnail
			UIImage smallImage = UIGraphics.GetImageFromCurrentImageContext();
//			thumbnail = smallImage; // Archiving method of saving

//			// Get the PNG representation of the image and set it as our archivable data // Archiving method of saving
//			NSData data = smallImage.AsPNG(); // Archiving method of saving
//			thumbnailData = data; // Archiving method of saving

			// Clean up image context resources, we're done
			UIGraphics.EndImageContext();

			// return thumbnail image // Archiving method of saving
			return smallImage; // remove for Archiving method of saving
		}

		//Archive method of saving data
//		[Export("initWithCoder:")]
//		public BNRItem(NSCoder decoder)
//		{
//			NSString str = (NSString)decoder.DecodeObject(@"itemName");
//			if (str != null)
//				this.itemName = str.ToString();
//			str = (NSString)decoder.DecodeObject(@"serialNumber");
//			if (str != null)
//				this.serialNumber = str.ToString();
//			str = (NSString)decoder.DecodeObject(@"imageKey");
//			if (str != null)
//				this.imageKey = str.ToString();
//			this.valueInDollars = decoder.DecodeInt(@"valueInDollars");
//
//			NSDate storedDate = (NSDate)decoder.DecodeObject(@"dateCreated"); // Archive Methofd of Saving
//			dateCreated = (DateTime)storedDate;
//
////			thumbnailData = (NSData)decoder.DecodeObject("thumbnailData"); // Archiving method of saving
//			str = (NSString)decoder.DecodeObject(@"assetType");
//			if (str != null)
//				this.assetType = str.ToString();
//		}
//
//		public override void EncodeTo (NSCoder coder)
//		{
//			if (this.itemName != null)
//				coder.Encode(new NSString(this.itemName), "itemName");
//			if (this.serialNumber != null)
//				coder.Encode(new NSString(this.serialNumber), "serialNumber");
//			coder.Encode(this.valueInDollars, "valueInDollars");
//			NSDate date = new NSDate();
//			date = dateCreated;
//			coder.Encode(date, "dateCreated");
//			if (this.imageKey != null)
//				coder.Encode(new NSString(this.imageKey), "imageKey");
////			if (thumbnailData != null) // Archiving method of saving
////				coder.Encode(thumbnailData, "thumbnailData"); // Archiving method of saving
//			if (this.assetType != null)
//				coder.Encode(new NSString(this.assetType), "assetType");
//		}

		public static BNRItem RandomBNRItem()
		{

			Random random = new Random((int)DateTime.Now.Ticks);

			List<string> randAdjList = new List<string>();
			randAdjList.Add("Fluffy");
			randAdjList.Add("Rusty");
			randAdjList.Add("Shiny");

			List<string> randNounList = new List<string>();
			randNounList.Add("Bear");
			randNounList.Add("Spork");
			randNounList.Add("Mac");

			int adjIndex = random.Next(0, 3);
			int nounIndex = random.Next(0, 3);

			string randomName = String.Format("{0} {1}", randAdjList[adjIndex], randNounList[nounIndex]);

			int randomValue = random.Next(0, 100);

			string randomSerialNumber = String.Format("{0}{1}{2}{3}{4}", (char)('0' + random.Next(0,10)), (char)('A' + random.Next(0,10)), (char)('0' + random.Next(0,10)), (char)('A' + random.Next(0,10)), (char)('0' + random.Next(0,10)));

			return new BNRItem(randomName, randomValue, randomSerialNumber);
		}

		public override string ToString()
		{
			return String.Format("{0} ({1}): Worth ${2}, recorded on {3} {4}", itemName, serialNumber, valueInDollars, dateCreated.ToLongDateString(), dateCreated.ToLongTimeString());
		}
	}
}



















