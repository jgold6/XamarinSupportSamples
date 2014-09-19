using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace MacCustomTableViewCell
{
	public partial class AViewController : MonoMac.AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public AViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public AViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}
		// Call to load from the XIB/NIB file
		public AViewController() : base("AView", NSBundle.MainBundle)
		{
			Initialize();
		}
		// Shared initialization code
		void Initialize()
		{
		}

		#endregion
	
	}
}

