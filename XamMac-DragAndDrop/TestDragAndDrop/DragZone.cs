﻿using System;
using AppKit;
using Foundation;

namespace TestDragAndDrop
{
	[Register("DragZone")]
	public class DragZone : NSTextField
	{
		public DragZone(IntPtr handle):base(handle){


		}

		#region - comment out to use MainView instead, then uncomment the same section in MainView.cs
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			this.WantsLayer = true;
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
			this.BackgroundColor = NSColor.LightGray;
			return NSDragOperation.Copy;
		}

		public override void DraggingExited (NSDraggingInfo sender)
		{
			base.DraggingExited (sender);
			this.BackgroundColor = NSColor.White;
			Console.WriteLine("NSTextField DraggingExited called");
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
			this.BackgroundColor = NSColor.White;
			return true;
		}
		#endregion
	}
}

