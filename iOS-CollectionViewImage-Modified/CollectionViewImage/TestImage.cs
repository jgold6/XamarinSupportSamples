using System;
using MonoTouch.UIKit;

namespace CollectionViewImage
{
	public class TestImage : IcollCellImage
	{
		public TestImage ()
		{

		}

		public string Name {
			get {
				return "testImage";
			}
		}
		public UIImage Image {
			get {
				return UIImage.FromBundle ("Images/Default.png");
			}
		}
	}
}

