using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;


namespace testRestService
{
	public partial class testRestServiceViewController : UIViewController
	{
		public testRestServiceViewController () : base ("testRestServiceViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			btnSendRestRequest.TouchUpInside += (sender, e) => {
				string response = CallService ("http://www.petiscos.com/ws_apps/getReceitasFromCat_json.php?id=32&pagina=2");
				lblOutput.Text = response;
			};

			btnClearText.TouchUpInside += (sender, e) => {
				lblOutput.Text = "";
			};
			int successes = 0;
			int failures = 0;
			for (var i = 0; i < 100; i++) {
				string response = CallService ("http://www.petiscos.com/ws_apps/getReceitasFromCat_json.php?id=32&pagina=2");
				if (response == "No response")
					failures++;
				else
					successes++;
				lblOutput.Text = "Successes: " + successes + ", Failures: " + failures + "\n" + response;
			}
		}

		public string CallService (string url )
		{
			string ret = "";
			var request = new RestRequest ( ) ;
			request.RequestFormat = DataFormat.Json ;
			var client = new RestClient ( url ) ; 

			var response = client.Execute (request) ;

			if (string.IsNullOrWhiteSpace (response.Content) || (response.StatusDescription.Equals (" OK "))) {
				ret = "No response";
			} else
				ret = response.Content;

			return ret;
		} 

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

