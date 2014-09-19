using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace UnwindSegue
{
	partial class RedViewController : UIViewController
	{
		public RedViewController (IntPtr handle) : base (handle)
		{
		}

		[Export("unwindToRed:")]
		void unwindToRed (UIStoryboardSegue unwindSegue)
		{
			Console.Write("To Red ");
			UIViewController sourceViewController = unwindSegue.SourceViewController;

			if (sourceViewController.GetType() == typeof(BlueViewController))
				Console.WriteLine("From blue");
			if (sourceViewController.GetType() == typeof(GreenViewController))
				Console.WriteLine("From green");
			if (sourceViewController.GetType() == typeof(YellowViewController))
				Console.WriteLine("From yellow");
		}
	}
}
