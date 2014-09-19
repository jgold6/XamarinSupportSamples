
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
using Android.Content.Res;

[assembly: Dependency(typeof(PopupMenu_Android))]

namespace UsingDependencyService.Android
{
	public class PopupMenu_Android : Java.Lang.Object, IPopupMenu
	{
		public PopupMenu_Android() { }

		public void Show(Xamarin.Forms.View v, Action<string> callback)
		{
			var ctx = Forms.Context;

//			var metrics = global::Android.Content.Res.Resources.DisplayMetrics;
//			var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
//			var heightInDp = ConvertPixelsToDp(metrics.HeightPixels); 

			var v2 = new global::Android.Views.View (ctx);
			v2.Top = 0;
			v2.Left = 0;
			v2.Right = 100;
			v2.Bottom = 100;

			PopupMenu menu = new PopupMenu (ctx, v2);
			menu.MenuInflater.Inflate (Resource.Menu.popup_menu, menu.Menu);

			menu.MenuItemClick += (object sender, PopupMenu.MenuItemClickEventArgs e) => {
				callback(e.Item.TitleFormatted.ToString());
			};

			menu.Show ();
		}
	}
}



