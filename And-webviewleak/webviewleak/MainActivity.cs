using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace webviewleak
{
	[Activity(Label = "webviewleak", MainLauncher = true)]
	public class MainActivity : Activity
	{
		WebView webView;
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			webView = new WebView(ApplicationContext);
			setConfigCallback((IWindowManager)ApplicationContext.GetSystemService(Context.WindowService));


			button.Click += delegate
			{
				button.Text = string.Format("{0} clicks!", count++);
			};
		}

		public void setConfigCallback(IWindowManager windowManager) {
			try {
				var field = webView.Class.GetDeclaredField("mWebViewCore");
				field = field.Type.GetDeclaredField("mBrowserFrame");
				field = field.Type.GetDeclaredField("sConfigCallback");
				field.Accessible = true;
				var configCallback = field.Get(null);

				if (null == configCallback) {
					return;
				}

				field = field.Type.GetDeclaredField("mWindowManager");
				field.Accessible = true;
				field.Set(configCallback, (Java.Lang.Object)windowManager);
			} catch(Exception e) {
			}
		}
	}
}


