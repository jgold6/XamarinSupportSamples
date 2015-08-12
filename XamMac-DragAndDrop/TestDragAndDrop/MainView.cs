using System;
using AppKit;
using Foundation;

namespace TestDragAndDrop
{
	[Register("MainView")]
	public class MainView : NSView
	{
		public MainView(IntPtr handle):base(handle)
		{

		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

	}
}

