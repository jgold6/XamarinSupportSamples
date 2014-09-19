// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace TestYouTube
{
	[Register ("FirstViewController")]
	partial class FirstViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLoadYouTube { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLoadYouTube != null) {
				btnLoadYouTube.Dispose ();
				btnLoadYouTube = null;
			}
		}
	}
}
