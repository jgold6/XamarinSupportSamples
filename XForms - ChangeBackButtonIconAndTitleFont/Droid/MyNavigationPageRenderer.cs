using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TestBackButton;
using TestBackButton.Droid;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.App;
using Support = Android.Support.V7.Widget;
using Android.Support.V7.Widget;
using Android.Widget;

[assembly: ExportRenderer(typeof(MyNavigationPage), typeof(MyNavigationPageRenderer))]
namespace TestBackButton.Droid
{
	public class MyNavigationPageRenderer : NavigationPageRenderer
	{
		private Support.Toolbar toolbar;

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			for (int i = 0; i < toolbar.ChildCount; i++)
			{
				var item = toolbar.GetChildAt(i);

				if (item.GetType() == typeof(TextView))
				{
					TextView tv = item as TextView;
					tv.SetTypeface(Android.Graphics.Typeface.Serif, Android.Graphics.TypefaceStyle.Italic);
				}

			}
		}
		public override void OnViewAdded(Android.Views.View child)
		{
			base.OnViewAdded(child);

			if (child.GetType() == typeof(Support.Toolbar))
				toolbar = (Support.Toolbar)child;

			for (int i = 0; i < toolbar.ChildCount; i++)
			{
				var item = toolbar.GetChildAt(i);

				if (item.GetType() == typeof(ImageButton))
				{
					ImageButton ib = item as ImageButton;
					ib.SetImageResource(Resource.Drawable.hollowstar);
				}

			}
		}
	}
}
