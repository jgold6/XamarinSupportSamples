using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePickerRenderer;
using DatePickerRenderer.Android;

[assembly: ExportRenderer (typeof (MyPicker), typeof (MyPickerRenderer))]

namespace DatePickerRenderer.Android
{
	public class MyPickerRenderer : Xamarin.Forms.Platform.Android.PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeEditText = (global::Android.Widget.TextView) Control;
				// do whatever you want to the textField here!
				nativeEditText.SetTextColor(global::Android.Graphics.Color.Green);
			}
		}
	}
}

