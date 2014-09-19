using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace UnwindSegue
{
	partial class GreenViewController : UIViewController
	{
		public GreenViewController (IntPtr handle) : base (handle)
		{
		}

		[Export("unwindToGreen:")]
		void unwindToGreen (UIStoryboardSegue unwindSegue)
		{
			Console.Write("To Green ");
			UIViewController sourceViewController = unwindSegue.SourceViewController;
			if (sourceViewController.GetType() == typeof(BlueViewController))
				Console.WriteLine("From blue");
		}
	}
}
