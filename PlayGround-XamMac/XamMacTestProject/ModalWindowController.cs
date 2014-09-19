using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace XamMacTestProject
{
	public partial class ModalWindowController : MonoMac.AppKit.NSWindowController
	{

		#region Constructors

		// Called when created from unmanaged code
		public ModalWindowController(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public ModalWindowController(NSCoder coder) : base(coder)
		{
			Initialize();
		}
		// Call to load from the XIB/NIB file
		public ModalWindowController() : base("ModalWindow")
		{
			Initialize();
		}
		// Shared initialization code
		void Initialize()
		{
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			this.Window.WindowShouldClose += (NSObject sender) => {
				Console.WriteLine("Window should close");
				NSAlert alert = new NSAlert();
				alert.MessageText = "Window will close now";
				alert.RunModal();
				NSApplication.SharedApplication.StopModal();
				return true;
			};
			btnReturn.Activated += (object sender, EventArgs e) => {
				Console.WriteLine("Button return Pressed");
				this.Window.PerformClose(this);
			};


		}

		#endregion

		//strongly typed window accessor
		public new ModalWindow Window
		{
			get
			{
				return (ModalWindow)base.Window;
			}
		}
	}
}

