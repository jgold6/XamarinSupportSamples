
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.CoreGraphics;
using System.Drawing;

namespace Maestro3Mac
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Fields
		protected float _MenuAnimTime = 3f;
		protected bool _TitleBarExpanded = true;
		protected bool _FullScreen = false;
		#endregion

		#region Properties
		protected float MenuAnimTime
		{
			get { return _MenuAnimTime; }
			set { _MenuAnimTime = value; }
		}
		protected bool TitleBarExapanded
		{
			get{ return _TitleBarExpanded; }
			set{ _TitleBarExpanded = value; }
		}
		protected bool FullScreen
		{
			get { return _FullScreen; }
			set { _FullScreen = value; }
		}
		#endregion

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
		}

		#endregion


		#region Overrides
		public override void AwakeFromNib ()
		{
			HelpButtonGUI.Activated += (object sender, EventArgs e) => {
				ShowHideHelpMenu();
				ExpandCollapesTileBarButtons();
			};

			HideButtonGUI.Activated += (object sender, EventArgs e) => {
				ShowHideToolBars();
			};

			ShowButtonGUI.Activated += (object sender, EventArgs e) => {
				ShowHideToolBars();
			};

			ExitButtonGUI.Activated += (object sender, EventArgs e) => {
				ExitApplication();
			};

			FullScreenButtonGUI.Activated += (object sender, EventArgs e) => {
				ToggleFulScreen();
			};
		}
		#endregion
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		#region Methods
		protected void ShowHideToolBars()
		{
			if (TitleBar.ToolBarOpen && ControlBar.ToolBarOpen) {
				MenuAnimation.OpenCloseMenu (TitleBar.Frame.Y, (TitleBar.Frame.Height + TitleBar.Frame.Y), MenuAnimTime, TitleBar, MenuMoveDirection.y);
				TitleBar.ToolBarOpen = !TitleBar.ToolBarOpen;

				MenuAnimation.OpenCloseMenu(ControlBar.Frame.X, (ControlBar.Frame.Width * -1), MenuAnimTime, ControlBar, MenuMoveDirection.x);
				ControlBar.ToolBarOpen = !ControlBar.ToolBarOpen;

				MenuAnimation.OpenCloseMenu ((ShowButtonGUI.Frame.Width * -1), 0f , MenuAnimTime, ShowButtonGUI, MenuMoveDirection.x);
			} else {

				MenuAnimation.OpenCloseMenu((ControlBar.Frame.Width * -1), 0f, MenuAnimTime, ControlBar, MenuMoveDirection.x);
				ControlBar.ToolBarOpen = !ControlBar.ToolBarOpen;

				
				MenuAnimation.OpenCloseMenu (TitleBar.Frame.Y, (MaestroWorkspaceViewGUI.Frame.Height - TitleBar.Frame.Height), MenuAnimTime, TitleBar, MenuMoveDirection.y);
				TitleBar.ToolBarOpen = !TitleBar.ToolBarOpen;

				MenuAnimation.OpenCloseMenu (ShowButtonGUI.Frame.X, (ShowButtonGUI.Frame.Width * -1), MenuAnimTime, ShowButtonGUI, MenuMoveDirection.x);
			}
		}

		protected void ShowHideHelpMenu()
		{
			if (HelpViewMenu.MenuOpen) {
				MenuAnimation.OpenCloseMenu(HelpViewMenu.Frame.X, (HelpViewMenu.Frame.Width * -1), MenuAnimTime, HelpMenuGUI, MenuMoveDirection.x);
				HelpViewMenu.MenuOpen = !HelpViewMenu.MenuOpen;
			} else {
				MenuAnimation.OpenCloseMenu((HelpViewMenu.Frame.Width * -1), 0, MenuAnimTime, HelpMenuGUI, MenuMoveDirection.x);
				HelpViewMenu.MenuOpen = !HelpViewMenu.MenuOpen;
			}
		}

		protected void ExpandCollapesTileBarButtons()
		{
			if (TitleBarExapanded) {
				FullScreenTextGUI.Hidden = true;
				SaveTextGUI.Hidden = true;
				PrintTextGUI.Hidden = true;
				BlurTextGUI.Hidden = true;
				TheaterTextGUI.Hidden = true;
				MenuAnimation.MoveNSViewX (FullScreenButtonGUI, (MaestroWorkspaceViewGUI.Frame.Width - FullScreenButtonGUI.Frame.Width));
				MenuAnimation.MoveNSViewX (SaveButtonGUI, (MaestroWorkspaceViewGUI.Frame.Width - (SaveButtonGUI.Frame.Width * 2)));
				MenuAnimation.MoveNSViewX (PrintButtonGUI, (MaestroWorkspaceViewGUI.Frame.Width - (PrintButtonGUI.Frame.Width*3)));
				MenuAnimation.MoveNSViewX (BlurButtonGUI, (MaestroWorkspaceViewGUI.Frame.Width - (BlurButtonGUI.Frame.Width * 4)));
				MenuAnimation.MoveNSViewX (TheaterButtonGUI, (MaestroWorkspaceViewGUI.Frame.Width - (TheaterButtonGUI.Frame.Width * 5)));

				TitleBarExapanded = !TitleBarExapanded;
			} else {
				FullScreenTextGUI.Hidden = false;
				SaveTextGUI.Hidden = false;
				PrintTextGUI.Hidden = false;
				BlurTextGUI.Hidden = false;
				TheaterTextGUI.Hidden = false;
				MenuAnimation.MoveNSViewX(FullScreenButtonGUI, (FullScreenTextGUI.Frame.X - (FullScreenButtonGUI.Frame.Width + 2.5f)));
				MenuAnimation.MoveNSViewX (SaveButtonGUI, (SaveTextGUI.Frame.X - (SaveButtonGUI.Frame.Width + 2.5f)));
				MenuAnimation.MoveNSViewX (PrintButtonGUI, (PrintTextGUI.Frame.X - (PrintButtonGUI.Frame.Width + 2.5f)));
				MenuAnimation.MoveNSViewX (BlurButtonGUI, (BlurTextGUI.Frame.X - (BlurButtonGUI.Frame.Width + 2.5f)));
				MenuAnimation.MoveNSViewX (TheaterButtonGUI, (TheaterTextGUI.Frame.X - (TheaterButtonGUI.Frame.Width + 2.5f)));
				TitleBarExapanded = !TitleBarExapanded;
			}
		}

		protected void ExitApplication()
		{
			if (FullScreen) {
				ToggleFulScreen ();
			}
			this.Close ();
		}

		protected void ToggleFulScreen()
		{
			if (FullScreen) {
				Window.ContentView.ExitFullscreenModeWithOptions (new NSDictionary ());
				Window.ContentView.NeedsUpdateConstraints = true;
				FullScreen = !FullScreen;
			} else {
				Window.ContentView.EnterFullscreenModeWithOptions (NSScreen.MainScreen, new NSDictionary ());
				Window.ContentView.NeedsUpdateConstraints = true;
				FullScreen = !FullScreen;

			}
		}
		#endregion
	}
}

