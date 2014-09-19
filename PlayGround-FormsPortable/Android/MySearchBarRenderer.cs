using System;
using FormsPlayground;
using FormsPlayground.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics.Drawables;

[assembly: ExportRenderer (typeof (MySearchBar), typeof (MySearchBarRenderer))]

namespace FormsPlayground.Android
{
	public class MySearchBarRenderer : SearchBarRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeSearchView = (global::Android.Widget.SearchView) Control;
				// do whatever you want to the textField here!

				int searchTextViewId = nativeSearchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
				TextView searchTextView = (TextView) nativeSearchView.FindViewById(searchTextViewId);
				searchTextView.SetTextColor(global::Android.Graphics.Color.Green);
				//searchTextView.SetBackgroundColor(global::Android.Graphics.Color.White);
				//nativeSearchView.SetBackgroundColor(global::Android.Graphics.Color.Gray);
			} 
		}
    }
}

