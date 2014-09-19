using System;
using MonoTouch.UIKit;
using Xamarin.Forms;
using DatePickerRenderer.iOS;
using DatePickerRenderer;

[assembly: ExportRenderer (typeof (MyDatePicker), typeof (MyDatePickerRenderer))]

namespace DatePickerRenderer.iOS
{
	public class MyDatePickerRenderer : Xamarin.Forms.Platform.iOS.DatePickerRenderer
	{
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeTextField = (UITextField) Control;
				// do whatever you want to the UITextField here!

				nativeTextField.TextColor = UIColor.Red;
			}
		}
	}
}

