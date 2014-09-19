using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;

namespace ViewTest1
{
	public partial class UserControlController : MonoMac.AppKit.NSViewController
	{

		#region Constructors

		// Called when created from unmanaged code
		public UserControlController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public UserControlController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file

		string myName = "";
		public UserControlController (string myNameL) : base ("UserControl", NSBundle.MainBundle)
		{
			Initialize ();
			myName = myNameL;
		}
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion

		//strongly typed view accessor
		public new UserControl View {
			get {
				return (UserControl)base.View;
			}
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			label.StringValue = myName;// DateTime.Now.TimeOfDay.ToString();

		}

		partial void flickrAction (NSObject sender)
		{

			if((flickoutlet.State==NSCellStateValue.On))
				Console.WriteLine("Flicker Checked---->>"+label.StringValue);
			else
				Console.WriteLine("Flicker unchecked---->>"+label.StringValue);


			flickoutlet.BezelStyle= NSBezelStyle.Rounded;
		}

		partial void PicassaAction (NSObject sender)
		{
			if((picassaoutlet.State==NSCellStateValue.On))

				Console.WriteLine("Picassa Checked---->>"+label.StringValue);
			else
				Console.WriteLine("Picassa unchecked---->>"+label.StringValue);
		}

		partial void SmugAction (NSObject sender)
		{
			    
			if((smugoutlet.State==NSCellStateValue.On))
			   Console.WriteLine("Smugmug Checked---->>"+label.StringValue);
				else
				Console.WriteLine("Smugmug Unchecked---->>"+label.StringValue);

		}

		partial void cancel (NSObject sender)
		{
			MainWindowController m= new MainWindowController();
			this.View.RemoveFromSuperview();
			Console.WriteLine(myName+" Removed");


		}


	}
}

