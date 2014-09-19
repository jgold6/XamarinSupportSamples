using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace App1.Droid
{
    [Activity(Label = "App1", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());
        }

        protected override void OnResume()
        {
            base.OnResume();

            Console.WriteLine("********************** Start *****************************");

            // start loop using int
            // Thread safe
            ConcurrentBag<int> testBag = new ConcurrentBag<int>();

            try
            {
                System.Threading.Tasks.Parallel.For(0, 1000, ctr =>
                {
                    // Does not cause a hang for Android
                    Console.WriteLine("Parallel For Counter = {0}", ctr.ToString());

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

        }
    }
}

