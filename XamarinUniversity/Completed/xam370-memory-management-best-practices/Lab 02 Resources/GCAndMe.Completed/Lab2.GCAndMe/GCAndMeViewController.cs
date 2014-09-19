using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System;

namespace Lab2.GCAndMe
{
	[Register ("GCAndMeViewController")]
	partial class GCAndMeViewController : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			float y = 30;
			View.BackgroundColor = UIColor.White;

			// The image we will work with; we derive our own so we can see
			// it get destroyed.
			var imageView = new MyImageView(new RectangleF(0, View.Bounds.Height / 2, View.Bounds.Width, View.Bounds.Height / 2));
			Add(imageView);

			WeakReference wr = new WeakReference(imageView);
			imageView = null; // set it to null so we aren't holding it anymore.

			// Create the button to remove our image
			AddButton(ref y, "Remove Image from Screen", 
				(sender, e) => {
					Console.WriteLine ("Removing image from UI");

					var iv = wr.Target as UIImageView;
					if (iv != null) {
						iv.RemoveFromSuperview();
						iv.Dispose(); // best practice to dispose when not used anymore
					}
				});

			// TODO: Step 1 - Force GC
			AddButton(ref y, "Force GC Now!", 
				(sender, e) => {
					// This forces a Garbage Collection
					Console.WriteLine ("Forcing GC!");
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
				});

			// TODO: Step 4 - Remove the reference
			AddButton(ref y, "Set ImageView reference to null", 
				(sender, e) => {
					Console.WriteLine ("Setting reference to null.");
					imageView = null;
				});
		}

		#region Support methods
		UIButton AddButton(ref float y, string text, EventHandler eh) {
			var button = new UIButton(UIButtonType.System) {
				Frame = new RectangleF(0, y, View.Bounds.Width, 30),
			};
			button.SetTitle(text, UIControlState.Normal);
			button.TouchUpInside += eh;
			Add(button);
			y += 50;
			return button;
		}
		#endregion
	}
}
