using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NSTableViewTest
{
	public partial class MainTableView : AppKit.NSView
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainTableView (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainTableView (NSCoder coder) : base (coder)
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion
	}
}
