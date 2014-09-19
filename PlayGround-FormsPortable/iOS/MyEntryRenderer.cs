using System;
using Xamarin.Forms;
using FormsPlayground;
using FormsPlayground.iOS;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]

namespace FormsPlayground.iOS
{
	public class MyEntryRenderer : EntryRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeTextField = (UITextField) Control;
				// do whatever you want to the UITextField here!
				nativeTextField.BackgroundColor = UIColor.White;
				nativeTextField.BorderStyle = UITextBorderStyle.RoundedRect;

				nativeTextField.EditingChanged += (object sender, EventArgs evt) => {
					Console.WriteLine(nativeTextField.Text);
				};

			}
		}
	}
}

