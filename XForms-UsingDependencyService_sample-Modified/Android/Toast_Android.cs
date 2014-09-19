
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
using Xamarin.Forms;
using UsingDependencyService.Android;

[assembly: Dependency(typeof(Toast_Android))]

namespace UsingDependencyService.Android
{
	public class Toast_Android : Java.Lang.Object, IToast
	{
		public Toast_Android() { }

		public void Show(string item)
		{

			Toast.MakeText(global::Android.App.Application.Context, item, ToastLength.Long).Show();
		}
	}
}

