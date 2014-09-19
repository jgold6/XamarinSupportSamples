using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace MacCustomTableViewCell
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController(IntPtr handle) : base(handle)
		{
			Initialize();
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MainWindowController(NSCoder coder) : base(coder)
		{
			Initialize();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController() : base("MainWindow")
		{
			Initialize();
		}
		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		public override void WindowDidLoad()
		{
			base.WindowDidLoad();

			string[] tableItems = new string[] {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"};
			tv.Source = new TableSource(tableItems);
		}



		//strongly typed window accessor
		public new MainWindow Window
		{
			get
			{
				return (MainWindow)base.Window;
			}
		}
	}

	public class TableSource : NSTableViewSource 
	{
		string[] tableItems;
		string cellIdentifier = "TableCell";

		public TableSource(string[] items)
		{
			tableItems = items;
		}           

		public override NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			return NSString.FromObject(tableItems [row]);
		}

		public override int GetRowCount (NSTableView tableView)
		{
			return tableItems.Count();
		} 
		public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			if (tableColumn.Identifier == "Col1") { return new NSTextField (); }
			var view = tableView.MakeView ("AView", this);

//			// There is no existing cell to reuse so create a new one
			if (view == null) {
				var avc = new AViewController ();
				view = avc.View;
				view.Identifier = "AView";

			}
			return view;
		}
	}
}





















