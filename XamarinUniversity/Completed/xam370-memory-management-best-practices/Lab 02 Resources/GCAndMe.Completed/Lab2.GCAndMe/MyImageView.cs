using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace Lab2.GCAndMe
{
	/// <summary>
	/// Simple override just to monitor the lifetime of the image.
	/// </summary>
	public class MyImageView : UIImageView
	{
		public MyImageView(RectangleF frame) : base(frame)
		{
			this.Image = UIImage.FromFile("xamarin.png");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			Console.WriteLine("MyImageView is being disposed({0})", disposing);
		}

		~MyImageView()
		{
			Console.WriteLine("MyImageView is being finalized!");
		}
	}
}

