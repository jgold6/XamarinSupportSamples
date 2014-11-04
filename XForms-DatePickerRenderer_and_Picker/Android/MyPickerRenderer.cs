using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DatePickerRenderer;
using DatePickerRenderer.Android;
using Android.App;
using Android.Widget;
using Android.Content;

[assembly: ExportRenderer (typeof (MyPicker), typeof (MyPickerRenderer))]

namespace DatePickerRenderer.Android
{
	public class MyPickerRenderer : Xamarin.Forms.Platform.Android.PickerRenderer
	{
		string[] items = new string[]{"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"};

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeEditText = Control;
				// do whatever you want to the textField here!
				nativeEditText.SetTextColor(global::Android.Graphics.Color.Green);

				nativeEditText.Click += (object s1, EventArgs e1) => {
					Console.WriteLine("Picker Clicked");
					NumberPicker picker = new NumberPicker(base.Context);
					picker.MaxValue = items.Length -1;
					picker.MinValue = 0;
					picker.SetDisplayedValues(items);
					picker.WrapSelectorWheel = false;

					picker.ValueChanged += (object s2, NumberPicker.ValueChangeEventArgs e2) => {
						nativeEditText.Text = items[e2.NewVal];
					};

					LinearLayout linearLayout = new LinearLayout(base.Context) {
						Orientation = Orientation.Vertical
					};
					linearLayout.AddView(picker);

					AlertDialog.Builder builder = new AlertDialog.Builder(base.Context);
					builder.SetView(linearLayout);
					builder.SetTitle("Pick a number from one to ten");

					builder.SetNegativeButton("Done", (s3, e3) => {});

					builder.Create().Show();
				};
			}
		}
	}
}

