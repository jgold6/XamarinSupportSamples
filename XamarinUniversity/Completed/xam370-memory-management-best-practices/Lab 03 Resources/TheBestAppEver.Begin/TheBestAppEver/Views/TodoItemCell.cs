using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace TheBestAppEver
{
	public class TodoItemCell : UITableViewCell
	{
		public const string Key = "todoCell";
		UIImageView checkImage;

		static UIImage _image = UIImage.FromBundle ("small_check.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);

		public TodoItemCell () : base (UITableViewCellStyle.Default,Key)
		{
		checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = _image};
			AccessoryView = checkImage;
		}

		public override void PrepareForReuse ()
		{
			base.PrepareForReuse ();

			AccessoryView = checkImage = new UIImageView (new RectangleF(0,0,25,25)) {Image = _image};
		}

		TodoItem item;
		public TodoItem Item {
			get {
				return item;
			}
			set {
				item = value;
				AccessoryView.TintColor = item.Completed ? UIColor.Black : UIColor.LightGray;
				TextLabel.Text = item.Title;
			}
		}
	}
}

