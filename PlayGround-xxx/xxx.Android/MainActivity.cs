using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Text;
using System.Net.NetworkInformation;
using Android.App;
using Android.Net;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Java.Lang;
using Java.Net;
using Java.Text;
using System.Threading.Tasks;
using Android.Webkit;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using Java.IO;
using System.Collections.Generic;
using Org.Apache.Http.Client.Methods;
using Android.Gms.Maps.Model;
using Android.Graphics;
using System.Reflection;
using Android.Net.Wifi;
using System.Net.Http;
using Android.Provider;
using Android.Content.PM;
using Android.Media;
using System.Globalization;
using Android.Bluetooth;


namespace xxx.Android
{
	enum TestEnum {zero, one, two, three, four};

	[Activity (Label = "xxx.Android", MainLauncher = true), Preserve(AllMembers=true), DataContract]
	public class MainActivity : Activity
	{
		int count = 1;
		Button button;
		Button button2;
		TextView tv;
		WebView wv;
		ImageView iv;



		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			System.Console.WriteLine("Decimal Separator: {0}", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button> (Resource.Id.myButton);
			button2 = FindViewById<Button>(Resource.Id.myButton2);
			tv = FindViewById<TextView>(Resource.Id.textView1);
			wv = FindViewById<WebView> (Resource.Id.webView1);

			// add and use a resource id for a tag
			//tv.SetTag(Resource.String.tag, (Java.Lang.Object)new TestView(this));

			string cText = GetString(Resource.String.test);
			System.Console.WriteLine("*********** {0}", cText);

//			RefreshWebView(wv);
			System.Console.WriteLine("Media Orientation: {0}", (int)TestEnum.one);
			if ((int)TestEnum.one == 1)
				System.Console.WriteLine("Enum evaluates to int");
				
			button.Click += delegate {
			
				Toast toast = Toast.MakeText(this.ApplicationContext, "Hello Toast", ToastLength.Short);
				toast.SetGravity(GravityFlags.Center,0, 0);
				toast.Show();

				//button.Text = await LoginAsync();
				var builder = new AlertDialog.Builder(this);

				// Inflate from Layout
//				builder.SetView(LayoutInflater.Inflate(Resource.Layout.AlDialog, null));

				builder.SetCancelable(false);
				builder.SetTitle("Prompt");
				builder.SetPositiveButton("Login", async delegate(object sender, DialogClickEventArgs e) {
					string a = await LoginAsync(button);
					//button.Text = await LoginAsync(button);
					System.Console.WriteLine("-----------------------Waiting--------------------------");
					System.Console.WriteLine(a);
				});

				builder.SetNegativeButton("Cancel", (sender, e) =>
					{
						button.Text = LoginCanceled();

					});

				builder.Create().Show();
				button.Text = "Waiting after show";
			};
			button.SetText("Set Text", TextView.BufferType.Normal);
			int position = button.Id;
			Java.Lang.Object o;
			o = position;
			button.SetTag(position,o);
			//System.Console.WriteLine("Button tag: {0}", button.GetTag(position));

			// Force Landscape orientation
//			button2.SetText("Force landscape mode", TextView.BufferType.Normal);
//			button2.Click += (object sender, EventArgs e) => {
//				RequestedOrientation = ScreenOrientation.Landscape;
//
//			};

			// Get Audio Volume
			button2.SetText("Get Audio Volume", TextView.BufferType.Normal);
			button2.Click += (object sender, EventArgs e) => {
				AudioManager audioMgr = (AudioManager)GetSystemService(Context.AudioService);
				int currentVolume = audioMgr.GetStreamVolume(global::Android.Media.Stream.Music);
				button2.SetText("Volume: " + currentVolume.ToString(), TextView.BufferType.Normal);
			};


			//Localize number formats
			float test = 1234567.89f;
			NumberFormat nf = NumberFormat.GetInstance(Java.Util.Locale.Default);
			//System.Console.WriteLine("Local format: {0}", nf.Format(test));
			nf = NumberFormat.GetInstance(Java.Util.Locale.France);
			//System.Console.WriteLine("Local format: {0}", nf.Format(test));
			nf = NumberFormat.GetInstance(Java.Util.Locale.Japan);
			//System.Console.WriteLine("Local format: {0}", nf.Format(test));


			// Network information - endpoints
			TcpConnectionInformation[] interfaces = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections();
			foreach (TcpConnectionInformation tci in interfaces)
			{
				//System.Console.WriteLine("LocalEndpoint: {0}, RemoteEndpoint: {1}, State: {2}", tci.LocalEndPoint, tci.RemoteEndPoint, tci.State);
			}
			// Global properties
			IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties ();
			//System.Console.WriteLine("GlobalProperties Host: {0}, NodeType: {1} ", computerProperties.HostName, computerProperties.NodeType);
			// Wifi
			WifiManager manager = (WifiManager)GetSystemService(Context.WifiService);
			WifiInfo info = manager.ConnectionInfo;
			string address = info.MacAddress;
			//System.Console.WriteLine("MAC Address: {0}", address);
			// Connections
			ConnectivityManager conManager = this.GetSystemService(Context.ConnectivityService) as ConnectivityManager;
			NetworkInfo[] netInfo = conManager.GetAllNetworkInfo();
			foreach (NetworkInfo ni in netInfo)
			{
				//System.Console.WriteLine("AndroidNetworkInfo: {0}", ni.IsConnected);
			}

			DownloadHomepage();

			// Get WiFi info
			global::Android.Net.Wifi.WifiConfiguration wifiConf = null;
			global::Android.Net.Wifi.WifiManager wifiManager = (global::Android.Net.Wifi.WifiManager)GetSystemService(Context.WifiService);
			global::Android.Net.Wifi.WifiInfo connectionInfo = wifiManager.ConnectionInfo;
			IList<global::Android.Net.Wifi.WifiConfiguration> configuredNetworks = wifiManager.ConfiguredNetworks;
			foreach (global::Android.Net.Wifi.WifiConfiguration conf in configuredNetworks) {
				System.Console.WriteLine("Configured networks {0}", conf);
				if (conf.NetworkId == connectionInfo.NetworkId) {
					wifiConf = conf;
					break;
				}
			} // end get wifi info

		}

		public async Task<int> DownloadHomepage()
		{
			var httpClient = new HttpClient(); // Xamarin supports HttpClient!

			Task<string> contentsTask = httpClient.GetStringAsync("http://xamarin.com"); // async method!

			// await! control returns to the caller and the task continues to run on another thread
			string contents = await contentsTask;

			//System.Console.WriteLine("DownloadHomepage method continues after async call. . . . .\n");
			RunOnUiThread(() => {
				button.SetText("RunOnUIThread", TextView.BufferType.Normal);
			});
			// After contentTask completes, you can calculate the length of the string.
			int exampleInt = contents.Length;

			//System.Console.WriteLine("Downloaded the html and found out the length.\n\n\n");

			//ResultEditText.Text += contents; // just dump the entire HTML
			//System.Console.WriteLine(contents);
			RunOnUiThread(() => {
				var text = global::Android.Text.Html.FromHtml("&nbsp;&nbsp;&nbsp;&nbsp;<u>&nbsp;&nbsp;&nbsp;&nbsp;Hello<br>&nbsp;&nbsp;World!</u>");
				tv.TextFormatted = text;
				wv.LoadData(contents, "text/html", "UTF-8");
				//wv.LoadUrl("http://xamarin.com");
			});

			return exampleInt; // Task<TResult> returns an object of type TResult, in this case int
		}

		public async Task<string> LoginAsync(Button btn)
		{
			//System.Console.WriteLine("Shoot!");
			string str = System.String.Format("OK Button clicked {0} times", count++);
			btn.Text = "Shoot!";
			return str;
		}

		public string LoginCanceled()
		{
			//System.Console.WriteLine("Login cancelled");
			return System.String.Format("Login cancelled");
		}

//		private void RefreshWebView(WebView wv) 
//		{
//			WebSettings webSettings = wv.Settings;
//			webSettings.JavaScriptEnabled = true;
//			wv.SetWebViewClient(new MyWebViewClient());
//			wv.LoadUrl("http://www.crunchpups.com");
//		}

//		private class MyWebViewClient : WebViewClient 
//		{
//			private Context context;
//
////			public MyWebViewClient(Context context) {
////				this.context = context;
////			}
////
////			public override bool ShouldOverrideUrlLoading (WebView view, string url) // called when links in the webview are selected
////			{
////				System.Console.WriteLine ("ShouldOverrideUrlLoading: " + url);
////				//Dictionary<string, string> headers = new Dictionary<string, string> ();
////				//headers.Add ("CustomHeaderName", "CustomHeaderValue");
////				//view.LoadUrl (url, headers);
////				return true;
////			}
////
////			public override void OnLoadResource (WebView view, string url) // called for resources--but can't append header!
////			{
////				System.Console.WriteLine ("OnLoadResource: " + url);
////				base.OnLoadResource (view, url);
////			}
//
//			public override WebResourceResponse ShouldInterceptRequest(WebView wv, string url)
//			{
//				System.Console.WriteLine("==================== URL: {0}", url);
//				if (url.Length > 5 && (url.Substring(url.Length-5,5) == ".com/" 
//									|| url.Substring(url.Length-3,3) == "php"))
//					return null;
//				base.ShouldInterceptRequest(wv, url);
//				System.Console.WriteLine("------------------------------------ShouldInterceptRequest: {0}", url);
//				HttpWebRequest request = new HttpWebRequest(new System.Uri(url));
//				WebHeaderCollection whc = new WebHeaderCollection();
//				whc.Set(HttpRequestHeader.KeepAlive, "true");
//				request.Headers = whc;
//				System.Console.WriteLine("***************************Headers: {0}", request.Headers.ToString());
//				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
//
//				Stream responseStream = response.GetResponseStream();
//				 
//				return new WebResourceResponse(response.ContentType, response.ContentEncoding, responseStream);
//			}
//		}


	}
}


