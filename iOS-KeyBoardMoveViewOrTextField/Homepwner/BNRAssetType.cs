using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using System.Drawing;
using SQLite;

namespace Homepwner
{
	[Table("BNRAssetTypes")]
	public class BNRAssetType
	{
		[PrimaryKey, AutoIncrement, MaxLength(8)]
		public int ID {get; set;}
		[MaxLength(50), Collation("NoCase")]
		public string assetType {get; set;}

		public BNRAssetType()
		{
		}

		public BNRAssetType(string label)
		{
			assetType = label;
		}
	}
}

