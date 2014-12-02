using System;
using AppKit;
using Foundation;

namespace XamMacTestProject
{
	[Register("ImageDragZone")]
	public class ImageDragZone : NSImageView
    {
		public ImageDragZone(IntPtr handle):base(handle){

//			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});

		}

//		public override void AwakeFromNib()
//		{
//			base.AwakeFromNib();
//			this.WantsLayer = true;
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
//				Console.WriteLine("NSImageView DraggingEntered called: file path = {0}", path);
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
//				Console.WriteLine("NSImageView PerformDragOperation called: file path = {0}", path);
//			}
//			return true;
//		}
    }
}

