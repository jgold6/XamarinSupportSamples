using System;
using Foundation;
using AppKit;
using CoreGraphics;

namespace XamMacTestProject
{
	[Register("DottedBox")]
    public class DottedBox : NSBox
    {
		NSColor mBorderColor;

		public NSColor DottedBorderColor {
			get{
				return mBorderColor;
			}
			set{
				mBorderColor = value;
				SetNeedsDisplayInRect(this.Bounds);
			}
		}

		public DottedBox(IntPtr handle):base(handle)
		{
			mBorderColor = NSColor.Black;
			RegisterForDraggedTypes(new string[]{"NSFilenamesPboardType"});
		}

		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
		{
			this.DottedBorderColor = NSColor.Red;
			return NSDragOperation.Copy;
		}

		public override void DraggingExited(NSDraggingInfo sender)
		{
			this.DottedBorderColor = NSColor.Black;
			base.DraggingExited(sender);
		}

		public override bool PerformDragOperation(NSDraggingInfo sender)
		{
			var mainView = this.Superview as MainView;
			this.DottedBorderColor = NSColor.Black;
			mainView.PerformDragOperation(sender);
			return true;
		}

		public override void DrawRect(CGRect dirtyRect)
		{
			base.DrawRect(dirtyRect);

			const int dashLength = 5;
			mBorderColor.Set();
			NSBezierPath path = new NSBezierPath();
			path.LineWidth = 5.0f;
			for (int w = 0; w < dirtyRect.Width; w += dashLength*2) {
				// Line along bottom
				path.MoveTo(new CGPoint(w, 0));
				path.LineTo(new CGPoint(w+dashLength, 0));
				// Line along top
				path.MoveTo(new CGPoint(w, dirtyRect.Height));
				path.LineTo(new CGPoint(w+dashLength, dirtyRect.Height));
			}

			for (int h = 0; h < dirtyRect.Width; h += dashLength*2) {
				// Line along left side
				path.MoveTo(new CGPoint(0, h));
				path.LineTo(new CGPoint(0, h+dashLength));
				// Line along right side
				path.MoveTo(new CGPoint(dirtyRect.Width, h));
				path.LineTo(new CGPoint(dirtyRect.Width, h+dashLength));
			}
			path.Stroke();
		}
    }
}

