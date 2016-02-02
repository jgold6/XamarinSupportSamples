using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace NSTableViewTest
{
	public partial class MainTableViewController : AppKit.NSViewController
	{
		private NSMutableArray m_personArray = new NSMutableArray();

		[Export("PersonArray")]
		public NSMutableArray PersonArray {
			get { return m_personArray; }
			set { 
				WillChangeValue ("PersonArray");
				m_personArray = value;
				DidChangeValue ("PersonArray");
			}
		}

		#region Constructors

		// Called when created from unmanaged code
		public MainTableViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainTableViewController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}

		// Call to load from the XIB/NIB file
		public MainTableViewController () : base ("MainTableView", NSBundle.MainBundle)
		{
			Initialize ();
		}

		// Shared initialization code
		void Initialize ()
		{
			PersonArray.Add (new Person ("John", "Cena", 18));
			PersonArray.Add (new Person ("Victoria", "Veil", 34));
			PersonArray.Add (new Person ("Frank", "Lumm", 48));
			PersonArray.Add (new Person ("Fred", "Clusberg", 52));
			PersonArray.Add (new Person ("Manny", "Curry", 14));
			PersonArray.Add (new Person ("Mary", "Lang", 21));
			PersonArray.Add (new Person ("Chasey", "Lane", 23));
		}

		#endregion

		//strongly typed view accessor
		public new MainTableView View {
			get {
				return (MainTableView)base.View;
			}
		}


		// Things I had to do in the MainTableView.xib:
		// Add outlet for the NSArrayController to be able to add items using the NSArrayController.
		// Change class for 4th column to CustomTableCellView
		// Add action for NSButton targeting the CustomTableCellView class CellButtonClick: method
		// Assign the delegate for the NSTableView to File's Owner, i.e this MainTableViewController class
		// Assigning the Delegate allows us to override the following and add the event handler for the CustomTableCellView
		#region - NSTableView Delegate method overrides
		[Export ("tableView:didAddRowView:forRow:")]
		public void DidAddRowView (AppKit.NSTableView tableView, AppKit.NSTableRowView rowView, System.nint row)
		{
			CustomTableCellView ctcv = (CustomTableCellView)rowView.ViewAtColumn (3);
			ctcv.CellButtonClicked -= CellView_CellButtonClicked;
			ctcv.CellButtonClicked += CellView_CellButtonClicked;
		}
		#endregion

		#region - Event Handlers
		void CellView_CellButtonClicked (NSObject sender, CustomTableCellViewEventArgs e)
		{
			arrayController.AddObject (new Person ((e.Sender).Title,"Button",2));
		}
		#endregion
	}

	#region - CustomTableCellView
	public class CustomTableCellViewEventArgs : EventArgs
	{
		public NSButton Sender { get; set; }
	}

	public delegate void CustomTableCellViewEventHandler(NSObject sender, CustomTableCellViewEventArgs e);

	[Register ("CustomTableCellView")]
	public class CustomTableCellView : NSTableCellView
	{
		public event CustomTableCellViewEventHandler CellButtonClicked;

		protected virtual void OnCellButtonClicked(CustomTableCellViewEventArgs e)
		{
			CustomTableCellViewEventHandler handler = CellButtonClicked;
			if (handler != null)
			{
				handler (this, e);
			}
		}

		public CustomTableCellView(IntPtr handle) : base(handle)
		{

		}

		[Action("CellButtonClick:")]
		void CellButtonClick (NSButton sender)
		{
			CustomTableCellViewEventArgs args = new CustomTableCellViewEventArgs () { Sender = sender };
			OnCellButtonClicked (args);
		}
	}
	#endregion
}
