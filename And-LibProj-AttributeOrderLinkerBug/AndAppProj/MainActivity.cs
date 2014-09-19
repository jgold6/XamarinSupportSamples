using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Runtime;
using System.Reflection;

namespace AndAppProj
{
	[Activity(Label = "AndAppProj", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);
			
			button.Click += delegate
			{
				button.Text = string.Format("{0} clicks!", count++);

				var tc = new AndLibProj.TestClass();
				//tc.Foo();
				Type type = typeof(AndLibProj.TestClass);

				MethodInfo methodInf = type.GetMethod("Foo");

				methodInf.Invoke(tc, new string[]{"test", "case"});
			};
		}
	}
}


