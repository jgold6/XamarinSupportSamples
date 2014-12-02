using System;
using AppKit;
using Foundation;

namespace XamMacTestProject
{
	[Register("MainView")]
	public class MainView : NSView
	{
		public MainView(IntPtr handle):base(handle)
		{

		}

		#region - uncomment the below to handle drag and drops in the entire window
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});
		}
			

		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
		{
			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
			var draggedUrl = draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url");
			if (draggedUrl != null) {
				NSUrl url = NSUrl.FromString(draggedUrl);
				string path = url.Path;
				Console.WriteLine("NSTextField DraggingEntered called: file path = {0}", path);
			}
			return NSDragOperation.Copy;
		}

		public override bool PerformDragOperation(NSDraggingInfo sender)
		{
			NSPasteboard draggingPasteBoard = sender.DraggingPasteboard;
			var draggedUrl = draggingPasteBoard.PasteboardItems[0].GetStringForType("public.file-url");
			if (draggedUrl != null) {
				NSUrl url = NSUrl.FromString(draggedUrl);
				string path = url.Path;
				Console.WriteLine("NSTextField PerformDragOperation called: file path = {0}", path);
			}
			return true;
		}
		#endregion
	}
}

