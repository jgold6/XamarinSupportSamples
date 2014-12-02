using System;
using AppKit;
using Foundation;

namespace XamMacTestProject
{
	[Register("DragZone")]
    public class DragZone : NSTextField
    {
		public DragZone(IntPtr handle):base(handle)
		{
//			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});
		}

//		public override void AwakeFromNib()
//		{
//			base.AwakeFromNib();
//		}
//
//		[Export ("draggingEntered:")]
//		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
//		{
//			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
//
//			var draggedUrl = draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url");
//			if (draggedUrl != null) {
//				NSUrl url = NSUrl.FromString(draggedUrl);
//				string path = url.Path;
//				Console.WriteLine("NSTextField DraggingEntered called: file path = {0}", path);
//			}
//			return NSDragOperation.Copy;
//		}
//
//		[Export ("performDragOperation:")]
//		public override bool PerformDragOperation(NSDraggingInfo sender)
//		{
//			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
//			var draggedUrl = draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url");
//			if (draggedUrl != null) {
//				NSUrl url = NSUrl.FromString(draggedUrl);
//				string path = url.Path;
//				Console.WriteLine("NSTextField PerformDragOperation called: file path = {0}", path);
//			}
//			return true;
//		}
    }
}

