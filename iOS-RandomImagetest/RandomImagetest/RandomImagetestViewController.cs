using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RandomImagetest
{
	public partial class RandomImagetestViewController : UIViewController
	{
		int imageCount = 0;

		public RandomImagetestViewController() : base("RandomImagetestViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
			int numberOfPics = 26;
			string[] Num2 = new string[numberOfPics]; //array for random random filenames
			for (int i = 0; i < Num2.Length; i++) {
				Num2[i] = "pic" + i + ".jpg";
			}

			// Shuffle Array
			Random rnd = new Random((int)DateTime.Now.Ticks);
			for (int i = Num2.Length; i > 1; i--) {
				// Pick random element to swap
				int j = rnd.Next(0, numberOfPics);
				// Swap
				string temp = Num2[j];
				Num2[j] = Num2[i - 1];
				Num2[i-1] = temp;
			}

			// Output shuffled array to console
			for (int i = 0; i < Num2.Length; i++) {
				Console.WriteLine("Element {0} = {1}", i, Num2[i]);
			}

			// Check for doubles (there can't be, but always good to double check
			for (int i = 0; i < Num2.Length - 1; i++) {
				for (int j = i+1; j < Num2.Length; j++) {
					if (Num2[i] == Num2[j])
						Console.WriteLine("{2}, {3}---------------------Duplicate found {0} = {1}", Num2[i], Num2[j], i, j);
					else
						Console.WriteLine("{2}, {3} No Duplicate {0} != {1}", Num2[i], Num2[j], i, j);
				}
			}

			btn.TouchUpInside += (object sender, EventArgs e) =>  {
				if (imageCount >= Num2.Length)
					imageCount = 0;
				imageView.Image = UIImage.FromFile(Num2[imageCount]);
				btn.SetTitle(String.Format("{0}, array element {1}", Num2[imageCount], imageCount), UIControlState.Normal);
				imageCount++;
			};

//			int ic = -1; //int count
//			rand2(ref Num2); //routine to generate random numbers...
//			btn.TouchUpInside += (object sender, EventArgs e) => {
//				//submit the rating
//				ic = ic + 1; //increase the count
//				imgSorce.Image.Dispose(); //clear the current image
//				using (var pool = new NSAutoreleasePool ()) { //put this in to prevent leaks
//					this.imgSorce.Image = UIImage.FromFile ("image/pic" + Num2[ic] + 
//						".jpg"); //display the next image
//				};
//			};
		}

		private void rand2 (ref int[] rn)
		{
			int i = 0;
			int icount = 0;
			for (i = 0; i <= 26;)
			{
				int n = 0;
				rand3(ref n);
				for(icount = 0; icount <= i;)
				{
					if (n == rn[icount])
					{
						icount--;
					}
					icount = icount + 1;
					if (icount == 140)
					{
						rn[i] = n;
						i = i+1;
					}
				}
			};
			rn[140] = 0;
		}

		private void rand3 (ref int num)
		{
			Random r = new Random();
			num = r.Next(0, 27);
		}
	}
}

