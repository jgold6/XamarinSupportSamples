using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using System.Collections.Generic;

namespace Phoneword
{
	[Activity(Label = "Phoneword App", MainLauncher = true, Icon = "@drawable/translate")]
    public class MainActivity : Activity
    {
		List<string> _phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

			var editText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			var btnCall = FindViewById<Button>(Resource.Id.CallButton);
			var btnTranslate = FindViewById<Button>(Resource.Id.TranslateButton);
			var btnCallHistory = FindViewById<Button>(Resource.Id.CallHistoryButton);

			string transNumber = string.Empty;
			btnTranslate.Click += (object sender, EventArgs e) => {
				var imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow(editText.WindowToken, 0);
				var number = editText.Text;
				transNumber = Core.PhonewordTranslator.ToNumber(number);
				if (string.IsNullOrWhiteSpace(transNumber)) {
					btnCall.Enabled = false;
					btnCall.Text = "Call";
				} else {
					btnCall.Enabled = true;
					btnCall.Text = "Call: " + transNumber;
				}

			};

			btnCall.Click += (sender, e) =>
			{
				// On "Call" button click, try to dial phone number.
				var callDialog = new AlertDialog.Builder(this);

				callDialog.SetMessage("Call " + transNumber + "?");

				callDialog.SetNeutralButton("Call", 
					delegate
				{
					// Record the number in the call history list
					_phoneNumbers.Add(transNumber);

					// enable the Call History button
					btnCallHistory.Enabled = true;

					// Create intent to dial phone
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + transNumber));
					StartActivity(callIntent);
				});

				callDialog.SetNegativeButton("Cancel", 
					delegate
				{
					// nothing to do
				});

				// Show the alert dialog to the user and wait for response.
				callDialog.Show();
			};

			btnCallHistory.Click += (object sender, EventArgs e) => {
				var intent = new Intent(this, typeof(CallHistoryActivity));
				intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
				StartActivity(intent);
			};

        }
    }
}


