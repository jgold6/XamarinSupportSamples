using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using System.Collections.Concurrent;

namespace App1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            window.RootViewController = App.GetMainPage().CreateViewController();

            window.MakeKeyAndVisible();
 

			Console.WriteLine("********************** Start *****************************");

			// start loop using int
			// Thread safe
			ConcurrentBag<int> testBag = new ConcurrentBag<int>();

            try
            {
				System.Threading.Tasks.Parallel.For(0, 1000, ctr =>
				{
					// Comment out the below to avoid the VS hang
					//Console.WriteLine("Parallel For Counter = {0}", ctr.ToString());

					testBag.Add(ctr);
				});

				//for (int i = 0; i < 1000; i++)
				//{
				//    Console.WriteLine("Normal for Counter = {0}", i.ToString());
				//    testBag.Add(i);
				//}

                System.Threading.Tasks.Parallel.ForEach(testBag, iteration =>
                {
                    Console.WriteLine("Parallel ForEach {0}", iteration);
                });

            }
            catch (Exception ex)
            {
                foreach (int j in testBag)
                    Console.WriteLine("Normal foreach {0}", j);
                Console.WriteLine(ex);
            }


			Console.WriteLine("********************** End *****************************");

            return true;
        }
    }
}
