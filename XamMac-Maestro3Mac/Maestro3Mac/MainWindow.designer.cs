// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Maestro3Mac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton BlurButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField BlurTextGUI { get; set; }

		[Outlet]
		Maestro3Mac.ToolBarView ControlBar { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton ExitButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton FullScreenButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField FullScreenTextGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton HelpButtonGUI { get; set; }

		[Outlet]
		Maestro3Mac.MenuView HelpMenuGUI { get; set; }

		[Outlet]
		Maestro3Mac.MenuView HelpViewMenu { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton HideButtonGUI { get; set; }

		[Outlet]
		Maestro3Mac.MaestroWorkspaceView MaestroWorkspaceViewGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton PrintButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField PrintTextGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton SaveButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SaveTextGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton ShowButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton TheaterButtonGUI { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField TheaterTextGUI { get; set; }

		[Outlet]
		Maestro3Mac.ToolBarView TitleBar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TheaterButtonGUI != null) {
				TheaterButtonGUI.Dispose ();
				TheaterButtonGUI = null;
			}

			if (BlurButtonGUI != null) {
				BlurButtonGUI.Dispose ();
				BlurButtonGUI = null;
			}

			if (PrintButtonGUI != null) {
				PrintButtonGUI.Dispose ();
				PrintButtonGUI = null;
			}

			if (SaveButtonGUI != null) {
				SaveButtonGUI.Dispose ();
				SaveButtonGUI = null;
			}

			if (FullScreenButtonGUI != null) {
				FullScreenButtonGUI.Dispose ();
				FullScreenButtonGUI = null;
			}

			if (TheaterTextGUI != null) {
				TheaterTextGUI.Dispose ();
				TheaterTextGUI = null;
			}

			if (BlurTextGUI != null) {
				BlurTextGUI.Dispose ();
				BlurTextGUI = null;
			}

			if (PrintTextGUI != null) {
				PrintTextGUI.Dispose ();
				PrintTextGUI = null;
			}

			if (SaveTextGUI != null) {
				SaveTextGUI.Dispose ();
				SaveTextGUI = null;
			}

			if (FullScreenTextGUI != null) {
				FullScreenTextGUI.Dispose ();
				FullScreenTextGUI = null;
			}

			if (ExitButtonGUI != null) {
				ExitButtonGUI.Dispose ();
				ExitButtonGUI = null;
			}

			if (ControlBar != null) {
				ControlBar.Dispose ();
				ControlBar = null;
			}

			if (HelpButtonGUI != null) {
				HelpButtonGUI.Dispose ();
				HelpButtonGUI = null;
			}

			if (HelpMenuGUI != null) {
				HelpMenuGUI.Dispose ();
				HelpMenuGUI = null;
			}

			if (HelpViewMenu != null) {
				HelpViewMenu.Dispose ();
				HelpViewMenu = null;
			}

			if (HideButtonGUI != null) {
				HideButtonGUI.Dispose ();
				HideButtonGUI = null;
			}

			if (MaestroWorkspaceViewGUI != null) {
				MaestroWorkspaceViewGUI.Dispose ();
				MaestroWorkspaceViewGUI = null;
			}

			if (ShowButtonGUI != null) {
				ShowButtonGUI.Dispose ();
				ShowButtonGUI = null;
			}

			if (TitleBar != null) {
				TitleBar.Dispose ();
				TitleBar = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
