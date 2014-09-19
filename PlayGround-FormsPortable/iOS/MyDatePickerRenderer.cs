using System;
using FormsPlayground;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using FormsPlayground.iOS;
using System.Drawing;

[assembly: ExportRenderer (typeof (MyDatePicker), typeof (MyDatePickerRenderer))]

namespace FormsPlayground.iOS
{
	public class MyDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control


				var nativeTextField = (UITextField) Control;
				// do whatever you want to the textField here!
				Element.Format = "MMMM dd, yyyy";
			} 
		}
	}
}
