using System;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace TestDragAndDrop
{
	[Register("DragZone")]
	public class DragZone : NSTextField
	{
		public DragZone(IntPtr handle):base(handle){

			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});

		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
		{
			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
			Console.WriteLine("Entered Sender: {0}", draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url"));
			return NSDragOperation.Copy;
		}

		public override bool PerformDragOperation(NSDraggingInfo sender)
		{
			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
			Console.WriteLine("Perform Sender: {0}", draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url"));
			return true;
		}
	}
}

