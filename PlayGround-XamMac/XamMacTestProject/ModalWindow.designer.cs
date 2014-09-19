// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace XamMacTestProject
{
	[Register ("ModalWindowController")]
	partial class ModalWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton btnReturn { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnReturn != null) {
				btnReturn.Dispose ();
				btnReturn = null;
			}
		}
	}

	[Register ("ModalWindow")]
	partial class ModalWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
