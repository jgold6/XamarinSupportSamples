using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePickerRenderer;
using DatePickerRenderer.Android;

[assembly: ExportRenderer (typeof (MyDatePicker), typeof (MyDatePickerRenderer))]

namespace DatePickerRenderer.Android
{
	public class MyDatePickerRenderer : Xamarin.Forms.Platform.Android.DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeEditText = (global::Android.Widget.TextView) Control;
				// do whatever you want to the textField here!
				nativeEditText.SetTextColor(global::Android.Graphics.Color.Red);
			}
		}
	}
}

