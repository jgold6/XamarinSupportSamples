using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.Threading;

using System.Runtime.InteropServices;

namespace WaveMaker
{
    [Activity(Label = "Read Fob")]
    public class ReadFob : Activity
    {
        List<Tuple<string,string,int>> items;

		//System.Timers.Timer t;

		private Timer m_ReadFobTimer;

		public ReadFob_Adapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ReadFob);

			items = new List<Tuple<string,string,int>>(); // Comment this out to update items rather than add items when the timer fires

			m_ReadFobTimer = new Timer(new TimerCallback(TimerProcessFob), null, Timeout.Infinite, Timeout.Infinite);

            UpdateFields();

			m_ReadFobTimer.Change(1000, 1000);

            var listView = FindViewById<ListView>(Resource.Id.listViewFOB);

			adapter = new ReadFob_Adapter(this, items);
			listView.Adapter = adapter;

            listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                var t = items[e.Position];
                Android.Widget.Toast.MakeText(this, t.Item1, Android.Widget.ToastLength.Short).Show();
                Console.WriteLine("Clicked on " + t.Item1);
				//UpdateFields();
				//adapter.NotifyDataSetChanged();
            };

            

        }

        private void TimerProcessFob(object state)
        {
            UpdateFields();
			RunOnUiThread(() => adapter.NotifyDataSetChanged());
        }

        public void UpdateFields()
        {
            int i = 0;

			//items = new List<Tuple<string,string,int>>(); // Uncomment this to update items rather than add items when the timer fires
			items.Clear();
            for (i = 0; i < DataReadFobClass.getArrayCount(); i++)
            {
                items.Add(new Tuple<string, string, int>(DataReadFobClass.getItemString(i), DataReadFobClass.getDataString(i), Resource.Drawable.ic_launcher));
            }

			//var listView = FindViewById<ListView>(Resource.Id.listViewFOB); // not necessary
			//listView.Adapter = new ReadFob_Adapter(this, items); // not necessary
        }
    }
}