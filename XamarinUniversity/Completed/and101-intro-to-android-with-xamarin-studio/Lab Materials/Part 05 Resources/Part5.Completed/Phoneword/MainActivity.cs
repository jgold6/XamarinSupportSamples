using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;

namespace Phoneword
{
	[Activity(Label = "Translate", MainLauncher = true, Icon = "@drawable/translate")]
	public class MainActivity : Activity
	{
		List<string> _phoneNumbers = new List<string>();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			// Get our UI controls from the loaded layout
			Button   translateButton   = FindViewById<Button  >(Resource.Id.TranslateButton);
			EditText phoneNumberText   = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			Button   callButton        = FindViewById<Button  >(Resource.Id.CallButton);
			Button   callHistoryButton = FindViewById<Button  >(Resource.Id.CallHistoryButton);

			// Disable the "Call" button
			callButton.Enabled = false;

			// Add code to translate number
			string translatedNumber = string.Empty;

			translateButton.Click += delegate
			{
				var imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow(phoneNumberText.WindowToken, 0);

				translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);

				if (string.IsNullOrWhiteSpace(translatedNumber))
				{
					callButton.Text    = "Call";
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text    = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};

			// Add code to make the phone call
            callButton.Click +=	delegate
			{
                // On "Call" button click, try to dial phone number.
                var callDialog = new AlertDialog.Builder(this);
                
				callDialog.SetMessage("Call " + translatedNumber + "?");
                
				callDialog.SetNeutralButton("Call", 
                    delegate
                    {
						// Record the number in the call history list
						_phoneNumbers.Add(translatedNumber);

						// enable the Call History button
		                callHistoryButton.Enabled = true;
	
                        // Create intent to dial phone
                        var callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
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

			callHistoryButton.Click += delegate
			{
				var intent = new Intent(this, typeof(CallHistoryActivity));
				intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
				StartActivity(intent);
			};
		}
	}
}