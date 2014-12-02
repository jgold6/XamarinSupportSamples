using System;
using Foundation;
using AppKit;
using CoreGraphics;

namespace XamMacTestProject
{
	[Register("DottedBox")]
    public class DottedBox : NSBox
    {
		public DottedBox(IntPtr handle):base(handle)
		{

		}

		public override void DrawRect(CGRect dirtyRect)
		{
			base.DrawRect(dirtyRect);

			const int dashLength = 5;
			NSColor lineColor = NSColor.Black;
			lineColor.Set();
			NSBezierPath path = new NSBezierPath();
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

