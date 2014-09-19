using System;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;
using MonoMac.CoreAnimation;

namespace Maestro3Mac
{
	public enum MenuMoveDirection {x, y};

	public class MenuAnimation
	{
		public static void OpenCloseMenu (float startPoint, float endPoint, float durration, NSView view, MenuMoveDirection direction)
		{
			CABasicAnimation menuOpenCloseAnim = CABasicAnimation.FromKeyPath (string.Format("position.{0}", direction.ToString().ToLower()));
			menuOpenCloseAnim.From = NSNumber.FromFloat (startPoint);
			menuOpenCloseAnim.To = NSNumber.FromFloat (endPoint);
			menuOpenCloseAnim.RemovedOnCompletion = true;
			menuOpenCloseAnim.AutoReverses = false;
			menuOpenCloseAnim.FillMode = CAFillMode.Forwards;
			view.Layer.AddAnimation (menuOpenCloseAnim, string.Format("move{0}", direction.ToString().ToUpper()));

			switch (direction) {
			case (MenuMoveDirection.x):
				view.SetFrameOrigin(new PointF (endPoint, view.Frame.Y));
					break;

			case (MenuMoveDirection.y):
				view.SetFrameOrigin(new PointF (view.Frame.X, endPoint));
					break;
			}
		}

		public static void HideText(NSView textView)
		{
			textView.Layer.Frame = new RectangleF (textView.Frame.X, textView.Frame.Y, 0f, textView.Frame.Height);
		}

		public static void ShowText(NSView textView)
		{
			textView.Layer.Frame = new RectangleF (textView.Frame.X, textView.Frame.Y, textView.Frame.Width, textView.Frame.Height);
		}

		public static void MoveNSViewX(NSView view, float xPos)
		{
			view.Frame = new RectangleF (xPos, view.Frame.Y, view.Frame.Width, view.Frame.Height);
		}

		public static void MoveNSViewY(NSView view, float yPos)
		{
			view.Frame = new RectangleF (view.Frame.X, yPos, view.Frame.Width, view.Frame.Height);
		}
	}
}

