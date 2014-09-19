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
	[Register ("EditQuoteViewController")]
	partial class EditQuoteViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Author { get; set; }

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
