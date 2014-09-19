
using Android.App;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Net;
using System.Net.Sockets;

//using Android.Net.Wifi;

using System.Windows;

using System.Windows.Input;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


using System.Runtime.InteropServices;

namespace WaveMaker
{
    [Activity(Label = "WaveMaker", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        Intent gui_view;

		//System.Timers.Timer t;

        private Timer m_UpdateFobData;

        int click_count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            m_UpdateFobData = new Timer(new TimerCallback(TimerProcess),
                              null, Timeout.Infinite, Timeout.Infinite);

            m_UpdateFobData.Change(1000, 1000);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            { 
                button.Text = string.Format("{0} clicks!", count++);
                Call_Tab_Function();
            };

            // Get our button from the layout resource,
            // and attach an event to it
            Button button_1 = FindViewById<Button>(Resource.Id.button1);

            button_1.Click += delegate
            {
                button_1.Text = string.Format("{0} clicks!", count++);
                DataReadFobClass.setItemString("Clicked", 1);
                DataReadFobClass.setDataString(click_count.ToString(), 1);
                click_count++;
            };
        }

        private void TimerProcess(object state)
        {
            DataReadFobClass.setDataNew(false);
            DataReadFobClass.setItemString("Ticked", 1);
            DataReadFobClass.setDataString(click_count.ToString(), 1);
            click_count++;
            DataReadFobClass.setDataNew(true);


        }

        private void Call_Tab_Function()
        {
            gui_view = new Intent(this, typeof(ReadFob));
            gui_view.PutExtra("FirstData", "Data from FirstActivity");
            StartActivity(gui_view);
        }
    }
}

