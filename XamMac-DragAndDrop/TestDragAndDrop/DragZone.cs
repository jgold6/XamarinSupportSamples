using System;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace TestDragAndDrop
{
	[Register("DragZone")]
	public class DragZone : NSTextField
	{
		public DragZone(IntPtr handle):base(handle){


		}

		#region - comment out to use MainView instead, then uncomment the same section in MainView.cs
//		public override void AwakeFromNib()
//		{
//			base.AwakeFromNib();
//			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});
//		}
//
//		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
//		{
//			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
//			Console.WriteLine("Entered Sender: {0}", draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url"));
//			return NSDragOperation.Copy;
//		}
//
//		public override bool PerformDragOperation(NSDraggingInfo sender)
//		{
//			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
//			Console.WriteLine("Perform Sender: {0}", draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url"));
//			return true;
//		}
		#endregion
	}
}

