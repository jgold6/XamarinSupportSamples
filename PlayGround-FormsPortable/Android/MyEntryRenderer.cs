using System;
using FormsPlayground;
using FormsPlayground.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof (MyEntry), typeof (MyEntryRenderer))]

namespace FormsPlayground.Android
{
	public class MyEntryRenderer : EntryRenderer
	{
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeEditText = (global::Android.Widget.EditText) Control;
				// do whatever you want to the textField here!
				nativeEditText.InputType = global::Android.Text.InputTypes.ClassPhone;

				// KeyPress
				nativeEditText.KeyPress += (object sender, KeyEventArgs evt) => {
					evt.Handled = false;


					if (evt.Event.Action == global::Android.Views.KeyEventActions.Up) {

						string replace = ""; // The text to replace the text field with
						int cursorPosition = nativeEditText.Text.Length - nativeEditText.SelectionStart;
						string input = nativeEditText.Text; // the text in the input field
						string rawNumber = input.Replace("(", "").Replace(")", "").Replace("-","");
						if (evt.KeyCode != global::Android.Views.Keycode.Del) {
							switch (rawNumber.Length) {
								case 1:
								case 2:
								case 3:
									replace = "(" + rawNumber;
									nativeEditText.Text = replace;
									break;
								case 4:
								case 5:
								case 6:
									replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3);
									nativeEditText.Text = replace;
									break;
								case 7:
								case 8:
								case 9:
								case 10:
									replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3, 3) + "-" + rawNumber.Substring(6);
									nativeEditText.Text = replace;
									break;
								case 11:
									replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3, 3) + "-" + rawNumber.Substring(6, 4);
									nativeEditText.Text = replace;
									break;
							}
							nativeEditText.SetSelection(nativeEditText.Text.Length - cursorPosition);

						}
					}
				};

				// TextChanged event handler
//				nativeEditText.TextChanged += (object sender, global::Android.Text.TextChangedEventArgs evt) =>  {
//					// Don't do anything if you have just changed the text in the text field
//					if (changed) {
//						changed = false;
//						return;
//					}
//					string replace = ""; // The text to replace the text field with
//					int cursorPosition = nativeEditText.Text.Length - nativeEditText.SelectionStart;
//					string input = nativeEditText.Text; // the text in the input field
//					string rawNumber = input.Replace("(", "").Replace(")", "").Replace("-","");

//					switch (rawNumber.Length) {
//						case 1:
//						case 2:
//						case 3:
//							replace = "(" + rawNumber;
//							changed = true;
//							nativeEditText.Text = replace;
//							break;
//						case 4:
//						case 5:
//						case 6:
//							replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3);
//							changed = true;
//							nativeEditText.Text = replace;
//							break;
//						case 7:
//						case 8:
//						case 9:
//						case 10:
//							replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3, 3) + "-" + rawNumber.Substring(6);
//							changed = true;
//							nativeEditText.Text = replace;
//							break;
//						case 11:
//							replace = "(" + rawNumber.Substring(0,3) + ")" + rawNumber.Substring(3, 3) + "-" + rawNumber.Substring(6, 4);
//							changed = true;
//							nativeEditText.Text = replace;
//							break;
//					}
//					nativeEditText.SetSelection(nativeEditText.Text.Length-cursorPosition);

//				};
			}
		}
	}
}

