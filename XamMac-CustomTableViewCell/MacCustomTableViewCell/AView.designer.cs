// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace MacCustomTableViewCell
{
	[Register ("AViewController")]
	partial class AViewController
	{
		[Outlet]
		public MonoMac.AppKit.NSImageView imageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}
		}
	}

	[Register ("AView")]
	partial class AView
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
