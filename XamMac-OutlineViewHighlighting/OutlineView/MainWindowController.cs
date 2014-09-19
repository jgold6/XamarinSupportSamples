
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.CoreGraphics;

namespace OutlineView
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		//
		protected Animal animalTree;
		protected AnimalsOutlineDataSource outlineDataSource;

		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			animalTree = new Animal() { Name = "My Animals", Children = 
				new List<Animal> () { 
					new Animal () { Name = "Amphibians", Children =
						new List<Animal> () { 
							new Animal () { Name = "Frog" },
							new Animal () { Name = "Amphibious Snake" }
						}
					},
					new Animal () { Name = "Birds", Children =
						new List<Animal> () { 
							new Animal () { Name = "Parrots", Children =
								new List<Animal> () { 
									new Animal () { Name = "Maccaw" },
									new Animal () { Name = "African Gray" }
								}
							},
							new Animal () { Name = "Song Birds", Children =
								new List<Animal> () { 
									new Animal () { Name = "Blue Jay" },
									new Animal () { Name = "Western Goldfinch" }
								}
							},
						}
					},
					new Animal () { Name = "Mammals", Children =
						new List<Animal> () { 
							new Animal () { Name = "Human" },
							new Animal () { Name = "Opossum" },
							new Animal () { Name = "Kangaroo" },
							new Animal () { Name = "Rat" },
							new Animal () { Name = "Gorrila" }
						}
					},
					new Animal () { Name = "Fish", Children =
						new List<Animal> () { 
							new Animal () { Name = "Sea Bass" },
							new Animal () { Name = "Lake Trout" },
							new Animal () { Name = "Bluefin Tuna" },
							new Animal () { Name = "Amberjack Tuna" },
							new Animal () { Name = "Steelhead" },
							new Animal () { Name = "Salmon" },
							new Animal () { Name = "Minnow" }
						}
					}
				}
			};


		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();

			this.outlineDataSource = new AnimalsOutlineDataSource (this.animalTree);
			this.MainOutlineView.DataSource = this.outlineDataSource;
			this.MainOutlineView.SelectionHighlightStyle = NSTableViewSelectionHighlightStyle.None;
			//this.MainOutlineView.AllowsMultipleSelection = true;
			this.MainOutlineView.Delegate = new OVDelegate();

		}

		#endregion
		
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}
	}

	public class OVDelegate :NSOutlineViewDelegate
	{
		public override void WillDisplayCell(NSOutlineView outlineView, NSObject cell, NSTableColumn tableColumn, NSObject item)
		{
			uint rowNo = (uint)outlineView.RowForItem(item);
			NSColor backgroundColor;
			NSFont font;
			if (outlineView.SelectedRows.Contains(rowNo)) {
				font = NSFont.BoldSystemFontOfSize(12);
				backgroundColor = NSColor.FromCGColor(new CGColor(0.69f, 0.78f, 0.93f, 1.0f));
			}
			else {
				font = NSFont.SystemFontOfSize(12);
				backgroundColor = NSColor.Clear;
			}
			var bCell = (NSTextFieldCell)cell;
			bCell.BackgroundColor = backgroundColor;
			bCell.DrawsBackground = true;// = backgroundColor;
			bCell.Font = font;
		}
	}
}

