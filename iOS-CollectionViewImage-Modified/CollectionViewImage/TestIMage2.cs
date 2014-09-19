using System;
using MonoTouch.UIKit;

namespace CollectionViewImage
{
	public class TestImage2 : IcollCellImage
	{
		public TestImage2 ()
		{

		}

		public string Name {
			get {
				return "testImage2";
			}
		}
		public UIImage Image {
			get {
				return UIImage.FromBundle ("Images/placeholder2.png");
			}
		}
	}
}
