using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.ServiceModel;
using HelloWorldWcfHost;
using System.Threading;

namespace HelloWorld.iOS
{
	public partial class HelloWorld_iOSViewController : UIViewController
	{
		public static readonly EndpointAddress EndPoint = new EndpointAddress("http://10.0.1.18:9608/HelloWorldService.svc");

		private HelloWorldServiceClient _client;

		public HelloWorld_iOSViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			InitializeHelloWorldServiceClient();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		#endregion

		private void InitializeHelloWorldServiceClient()
		{
			BasicHttpBinding binding = CreateBasicHttp();

			_client = new HelloWorldServiceClient(binding, EndPoint);
			_client.SayHelloToCompleted += ClientOnSayHelloToCompleted;
			_client.GetHelloDataCompleted += ClientOnGetHelloDataCompleted;

			btnGetHello.TouchUpInside += GetHelloWorldDataButtonTouchUpInside;
			btnSayHello.TouchUpInside += SayHelloWorldDataButtonTouchUpInside;
		}

		private static BasicHttpBinding CreateBasicHttp()
		{
			BasicHttpBinding binding = new BasicHttpBinding
			{
				Name = "basicHttpBinding",
				MaxBufferSize = 2147483647,
				MaxReceivedMessageSize = 2147483647
			};
			TimeSpan timeout = new TimeSpan(0, 0, 30);
			binding.SendTimeout = timeout;
			binding.OpenTimeout = timeout;
			binding.ReceiveTimeout = timeout;
			return binding;
		}

		private void SayHelloWorldDataButtonTouchUpInside(object sender, EventArgs e)
		{
			tvSayHello.Text = "Waiting for WCF...";

			_client.SayHelloToAsync("Kilroy");
		}

		private void GetHelloWorldDataButtonTouchUpInside(object sender, EventArgs e)
		{
			tvGetHello.Text = "Waiting WCF...";
			HelloWorldData data = new HelloWorldData { Name = "Mr. Chad", SayHello = true };
			_client.GetHelloDataAsync(data);
		}

		private void ClientOnGetHelloDataCompleted(object sender, GetHelloDataCompletedEventArgs e)
		{
			string msg = null;

			if (e.Error != null)
			{
				msg = e.Error.Message;
			}
			else if (e.Cancelled)
			{
				msg = "Request was cancelled.";
			}
			else
			{
				msg = e.Result.Name;
			}

			InvokeOnMainThread(() => tvGetHello.Text = msg);
		}

		private void ClientOnSayHelloToCompleted(object sender, SayHelloToCompletedEventArgs e)
		{
			string msg = null;

			if (e.Error != null)
			{
				msg = e.Error.Message;
			}
			else if (e.Cancelled)
			{
				msg = "Request was cancelled.";
			}
			else
			{
				msg = e.Result;
			}
			InvokeOnMainThread(() => tvSayHello.Text = msg);
		}
	}
}

