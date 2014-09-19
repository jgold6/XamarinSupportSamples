using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Xamarin.Media;
using ScanditSDK;
using System.Threading.Tasks;

namespace XMScanditTest
{
	public partial class XMScanditTestViewController : UIViewController
	{
		public XMScanditTestViewController() : base("XMScanditTestViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.

			// comment the below out to see full photo quality (effect should be visible when taking the picture)
			SIBarcodePicker.Prepare("aP3ZkqMOEeOBg862JF5vfIl7ASYubaPMrRzwIo7FrxE", SICameraFacingDirection.Back);

			var picker = new MediaPicker();
			MediaPickerController controller = picker.GetTakePhotoUI (new StoreCameraMediaOptions {
				Name = "test.jpg",
				Directory = "MediaPickerSample"
			});

			// On iPad, you'll use UIPopoverController to present the controller
			PresentViewController (controller, true, null);

			controller.GetResultAsync().ContinueWith (t => {
				// Dismiss the UI yourself
				controller.DismissViewController (true, () => {
					MediaFile file = t.Result;
				});

			}, TaskScheduler.FromCurrentSynchronizationContext());		}
	}
	public class YourDelegate : SIOverlayControllerDelegate
	{
		public override void DidScanBarcode (SIOverlayController overlayController, NSDictionary barcode) {
			// perform actions after a barcode was scanned
			Console.WriteLine ("barcode scanned: {0}, '{1}'", barcode["symbology"], barcode["barcode"]);
		}

		public override void DidCancel (SIOverlayController overlayController, NSDictionary status) {
			// perform actions after cancel was pressed
		}

		public override void DidManualSearch (SIOverlayController overlayController, string text) {
			// perform actions after search was used
		}
	}

}

