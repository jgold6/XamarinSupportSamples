using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace xxx
{
	partial class testAddSeparate : UIViewController
	{
		public testAddSeparate() : base ("testAddSeparate", null)
		{
		}

		private T TestGetMethod<T>(T test)
		{
			T x = test;
			return x;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Console.WriteLine("ViewDidLoad Is Being Presented? {0}, {1}", this.IsBeingPresented, this.View.Window);
			btnLinkTest.TouchUpInside += (object sender, EventArgs e) => {
				Console.WriteLine("Is Being Presented? {0}, {1}", this.IsBeingPresented, this.View.Window);
				Console.WriteLine("Boolean Test: {0}, {1}\n===========================", this.IsViewLoaded, this.View.Window);
				this.DismissViewController(true, null);
			};
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			Console.WriteLine("ViewDidAppear IsLoaded? {0}, {1}", this.IsViewLoaded, this.View.Window);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			Console.WriteLine("ViewWillDisappear IsLoaded? {0}, {1}", this.IsViewLoaded, this.View.Window);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			Console.WriteLine("ViewDidDisappear IsLoaded? {0}, {1}", this.IsViewLoaded, this.View.Window);
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return (UIInterfaceOrientationMask.Landscape);
		}
	}
}

