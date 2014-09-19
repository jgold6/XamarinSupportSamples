using System;
using System.IO;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Xamarin.Data.Core;
using Xamarin.Data.Core.Orm;

namespace Xamarin.Data.iOS
{

    public class Application
    {
        public static void Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        private static DataManager _DataManager;
        public static DataManager DataManager
        {
            get {
				//TODO: Step 12a - iOS - Remove placeholder return
//				return null;
				//TODO: Step 12b - iOS - Provide an instance of DataManager
				return _DataManager ?? (_DataManager = new DataManager(new Platform()));
			}
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            window.MakeKeyAndVisible();
            window.RootViewController = new ViewControllers.SessionsViewController();

            return true;
        }
    }
}