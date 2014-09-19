using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace XamMacTestProject
{
	public partial class ModalWindow : MonoMac.AppKit.NSWindow
	{

		#region Constructors
		public ModalWindow()
		{
			Initialize();
		}

		// Called when created from unmanaged code
		public ModalWindow(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public ModalWindow(NSCoder coder) : base(coder)
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

