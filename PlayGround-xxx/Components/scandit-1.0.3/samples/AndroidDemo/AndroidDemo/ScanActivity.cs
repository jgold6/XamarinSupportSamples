using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Scandit;

namespace XamarinScanditSDKDemoAndroid
{
	[Activity (Label = "ScanActivity")]			
	public class ScanActivity : Activity, Scandit.Interfaces.IScanditSDKListener
	{
		private ScanditSDKAutoAdjustingBarcodePicker picker;
		public static string appKey = "---- ENTER YOUR APP KEY HERE - SIGN UP AT WWW.SCANDIT.COM ----";		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			RequestWindowFeature (WindowFeatures.NoTitle);
			Window.SetFlags (WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

			// Setup the barcode scanner
			picker = new ScanditSDKAutoAdjustingBarcodePicker (this, appKey, ScanditSDKAutoAdjustingBarcodePicker.CameraFacingBack);
			picker.OverlayView.AddListener (this);

			// Show the scan user interface
			SetContentView (picker);
		}

		public void DidScanBarcode (string barcode, string symbology) {
			Console.WriteLine ("barcode scanned: {0}, '{1}'", symbology, barcode);

			// stop the camera
			picker.StopScanning ();

			AlertDialog alert = new AlertDialog.Builder (this)
				.SetTitle (symbology + " Barcode Detected")
					.SetMessage (barcode)
					.SetPositiveButton("OK", delegate {
						picker.StartScanning ();
					})
					.Create ();

			alert.Show ();
		}

		public void DidCancel () {
			Console.WriteLine ("Cancel was pressed.");
			Finish ();
		}

		public void DidManualSearch (string text) {
			Console.WriteLine ("Search was used.");
		}

		protected override void OnResume () {
			picker.StartScanning ();
			base.OnResume ();
		}

		protected override void OnPause () {
			picker.StopScanning ();
			base.OnPause ();
		}

		public override void OnBackPressed () {
			base.OnBackPressed ();
			Finish ();
		}
	}
}

