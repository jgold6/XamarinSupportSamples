using System;
using FormsPlayground;
using FormsPlayground.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics.Drawables;

[assembly: ExportRenderer (typeof (MyDatePicker), typeof (MyDatePickerRenderer))]

namespace FormsPlayground.Android
{
	public class MyDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeDatePicker = (global::Android.Widget.EditText) Control;
				// do whatever you want to the textField here!


			} 
		}
	}
}


