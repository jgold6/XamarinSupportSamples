using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Test_Pause
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		Test_PauseViewController viewController;

		public UINavigationController NavigationController;


		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//--- instantiate a new navigation controller
			this.NavigationController = new UINavigationController();

			// Hide the NavigationBar
			this.NavigationController.NavigationBarHidden = true;


			viewController = new Test_PauseViewController ();

			//---- add the home screen to the navigation controller (it'll be the top most screen)
			this.NavigationController.PushViewController(viewController, false);

			//---- set the root view controller on the window.  the nav controller will handle the rest
			this.window.RootViewController = this.NavigationController;
			this.window.MakeKeyAndVisible();

			return true;
		}
	}
}








//
//using System;
//using System.Drawing;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;		// Required for File IO
//using System.Xml;		// For XML parsing
//using System.Text;
//
//using MonoTouch.Foundation;
//using MonoTouch.AVFoundation;		// Play mp3 music
//using MonoTouch.CoreAnimation;
//using MonoTouch.CoreGraphics;
//using MonoTouch.ObjCRuntime;
//using MonoTouch.OpenGLES;
//using MonoTouch.UIKit;
//using MonoTouch.AudioToolbox;		// Play sound effects .aif or .caf
//
//using MonoTouch.CoreImage;
//
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//
//namespace WarGame
//{
//	// The UIApplicationDelegate for the application. This class is responsible for launching the 
//	// User Interface of the application, as well as listening (and optionally responding) to 
//	// application events from iOS.
//	[Register ("AppDelegate")]
//	public partial class AppDelegate : UIApplicationDelegate
//	{
//		public SizeF DeviceBounds { get; set; }
//		public UIUserInterfaceIdiom DeviceIdiom { get; set; }
//		public string DevicieModel { get; set; }
//		public string DeviceSystemVersion { get; set; }
//		// The BaseWidthScale & BaseHeightScale are what easily converts this iPhone game to an iPad game.  By simply changing the zoom I can keep the same settings and not change anything else!  Woot!
//		// Simply use this and compare this DeviceBounds to an iPhone's DeviceBounds.  The ratio will tell you what the Min zoom should be in the battlefield's UIScrollView
//		float WidthScale_ComparedToiPhone { get; set; }		
//		float HeightScale_ComparedToiPhone { get; set; }
//		// Define the min and max zoom factors for zooming in and out.  1 means 1x, 4 means 4x, etc
//		public float BattleField_Zoom_Max { get; set; }
//		public float BattleField_Zoom_Min { get; set; }
//		public float BattleField_Zoom_Initial { get; set; }
//
//
//
//		UIWindow window;
//
//		public UINavigationController NavigationController;
//
//
//		public Globals globals = new Globals();
//		public MyModels Models { get; set; }
//		public MyBallistics Ballistics { get; set; }
//		public MyAnimations Animations { get; set; }
//
//		public int MaxPossibleDistance { get; set; }
//
//
//		public Thread MyThread { get; set; }
//
//
//		public MainMenuViewController MainMenu { get; set; }
//		public CyComViewController CyCom { get; set; }
//		public AnimationBuilderViewController AnimationBuilder { get; set; }
//
//
//		// This method is invoked when the application has loaded and is ready to run. In this 
//		// method you should instantiate the window, load the UI into it and then make the window
//		// visible.
//		//
//		// You have 17 seconds to return from this method, or iOS will terminate your application.
//		//
//		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
//		{
//			DeviceBounds = UIScreen.MainScreen.Bounds.Size;
//			//			Console.WriteLine(DeviceIdiom + " of Size " + DeviceBounds);
//			DeviceIdiom = UIDevice.CurrentDevice.UserInterfaceIdiom;
//			DevicieModel = UIDevice.CurrentDevice.Model;
//			DeviceSystemVersion = UIDevice.CurrentDevice.SystemVersion;
//			WidthScale_ComparedToiPhone = DeviceBounds.Width / 320f;
//			HeightScale_ComparedToiPhone = DeviceBounds.Height / 480f;
//			//			Console.WriteLine("WidthScale_ComparedToiPhone = " + WidthScale_ComparedToiPhone);
//			//			Console.WriteLine("HeightScale_ComparedToiPhone = " + HeightScale_ComparedToiPhone);
//
//			BattleField_Zoom_Min = WidthScale_ComparedToiPhone;
//			if ( HeightScale_ComparedToiPhone > BattleField_Zoom_Min )
//				BattleField_Zoom_Min = HeightScale_ComparedToiPhone;
//
//
//			BattleField_Zoom_Min = 5f;
//
//
//			BattleField_Zoom_Max = 15f;
//			BattleField_Zoom_Initial = BattleField_Zoom_Min;
//
//
//			MaxPossibleDistance = (int)( Math.Sqrt((DeviceBounds.Height*DeviceBounds.Height) + (DeviceBounds.Width*DeviceBounds.Width)) );
//
//			window = new UIWindow (UIScreen.MainScreen.Bounds);
//
//			//--- instantiate a new navigation controller
//			this.NavigationController = new UINavigationController();
//
//			// Hide the NavigationBar
//			this.NavigationController.NavigationBarHidden = true;
//
//
//			MainMenu = new MainMenuViewController ();
//
//
//			MyThread = new Thread ( () => MyThread_Function() );
//			MyThread.IsBackground = true;
//			MyThread.Start();
//
//			//			Console.WriteLine("Returning in AppDelegate");
//			return true;
//		}
//
//
//		public void MyThread_Function ()
//		{
//			// Sleep just enough so that the FinishedLaunching function returns so I avoid the Watch dog possibly closing my app...
//			Thread.Sleep(25);
//			InvokeOnMainThread(delegate {					
//				//---- add the home screen to the navigation controller (it'll be the top most screen)
//				this.NavigationController.PushViewController(MainMenu, false);
//
//				//---- set the root view controller on the window.  the nav controller will handle the rest
//				this.window.RootViewController = this.NavigationController;
//				this.window.MakeKeyAndVisible();
//			});
//		}
//
//	}
//}
