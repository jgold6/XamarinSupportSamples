using System;
using FormsPlayground;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using FormsPlayground.iOS;

[assembly: ExportRenderer (typeof (MySearchBar), typeof (MySearchBarRenderer))]

namespace FormsPlayground.iOS
{
	public class MySearchBarRenderer : SearchBarRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged (e);
			if (e.OldElement == null) {   // perform initial setup
				// lets get a reference to the native control
				var nativeSearchView = (UISearchBar) Control;
				// do whatever you want to the textField here!

				UITextField searchField = (UITextField)nativeSearchView.ValueForKey(new MonoTouch.Foundation.NSString("_searchField"));
				searchField.TextColor = UIColor.Green;
			} 
		}
	}
}
