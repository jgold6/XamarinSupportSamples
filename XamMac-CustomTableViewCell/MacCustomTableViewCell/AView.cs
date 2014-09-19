using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;
using System.Diagnostics;

namespace MacCustomTableViewCell
{
	public partial class AView : MonoMac.AppKit.NSTableCellView
	{
		static int count = 0;
		#region Constructors

		// Called when created from unmanaged code
		public AView(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public AView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		public AView() : base()
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

