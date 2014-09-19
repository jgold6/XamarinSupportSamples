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
		public string itemName {get; set;}
		public DateTime dateCreated {get; set;} 
		public double orderingValue {get; set;} // For SQL method of saving

		public BNRItem() : this("New Item")
		{

		}

		public BNRItem(string name)
		{
			itemName = name;
			dateCreated = DateTime.Now;
		}
	}
}



















