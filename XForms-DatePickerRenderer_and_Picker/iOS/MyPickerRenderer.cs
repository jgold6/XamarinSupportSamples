using System;
using MonoTouch.UIKit;
using Xamarin.Forms;
using DatePickerRenderer.iOS;
using DatePickerRenderer;

[assembly: ExportRenderer (typeof (MyPicker), typeof (MyPickerRenderer))]

namespace DatePickerRenderer.iOS
{
	public class MyPickerRenderer : Xamarin.Forms.Platform.iOS.PickerRenderer
	{

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Picker> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeTextField = (UITextField) Control;
				// do whatever you want to the UITextField here!

				nativeTextField.TextColor = UIColor.Green;
			}
		}
	}
}

