// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GreatQuotes
{
	[Register ("QuoteDetailViewController")]
	partial class QuoteDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Author { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView Quote { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Author != null) {
				Author.Dispose ();
				Author = null;
			}
			if (Quote != null) {
				Quote.Dispose ();
				Quote = null;
			}
		}
	}
}
