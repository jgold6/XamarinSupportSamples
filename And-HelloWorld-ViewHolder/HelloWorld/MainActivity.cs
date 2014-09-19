// Uncomment the following line to have the application hang.
//#define INCLUDE_LOOPER_OVERRIDE

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Threading;
using Java.IO;

namespace HelloWorld
{
	[Activity (Label = "HelloWorld", MainLauncher = true)]
	public class MainActivity : Activity
	{

		public class MyListViewAdapter : BaseAdapter<int>
		{
			Activity _hostingActivity = null;
			List<int> _items = null;
			public MyListViewAdapter(Activity hostingActivity, List<int> items) : base()
			{
				_hostingActivity = hostingActivity;
				_items = items;
			}

			public override int this [int index] { get { return _items[index]; } }
			public override int Count { get { return _items.Count; } }

			public override long  GetItemId (int position)
			{
				return position;
			}

			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				int item = this[position];
				MyViewHolder holder = null;
				if ( convertView == null )
				{
					convertView = _hostingActivity.LayoutInflater.Inflate(Resource.Layout.ListRow, null);
					holder = new MyViewHolder();
					holder.linLayout = convertView as LinearLayout;
					for ( int columnIndex = 0; columnIndex < holder.linLayout.ChildCount; ++columnIndex ){
						holder.textViews[columnIndex] = holder.linLayout.GetChildAt(columnIndex) as TextView;
					}
					convertView.Tag = holder;
				}
				else 
					holder = (MyViewHolder)convertView.Tag;


				for ( int columnIndex = 0; columnIndex < holder.linLayout.ChildCount; ++columnIndex )
				{
					holder.textViews[columnIndex].Text = string.Format("({0}, {1})",position, columnIndex);
					// Comment out the following line to see the gref count increase from 275 to 525.
					// We feel we should not need to invoke Dispose() explicitly. The gref should be
					// disposed of/freed when we leave the scope of GetView(), given that we do not
					// save a copy of the given gref. The only thing that holds on to the TextView
					// reference is the LinearLayout, which is probably holding on to the underlying
					// Android object, not a gref.
					//
					// If you click the "click me" button to generate the gref crash, with this line NOT
					// commented out, and look at logcat output from the crash, you will see 0 TextViews
					// reported. However WITH this line commented out you will see 250 TextViews reported,
					// implying something is in fact holding onto them.
					// textView.Dispose();
				}
				return convertView;
			}
		}

		int count = 1;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button buttonReference1 = FindViewById<Button> (Resource.Id.myButton);

			#if DRS
			buttonReference1.Dispose();

			buttonReference1 = FindViewById<Button> (Resource.Id.myButton);

			Button buttonReference2 = FindViewById<Button> (Resource.Id.myButton);

			buttonReference2.Dispose();
			Console.WriteLine("crashes on this line due to buttonReference1 having been disposed as a result of disposing buttonReference2, button = {0}",
			buttonReference1);
			#endif

			List <int> items = new List<int>();
			for ( int i = 0; i < 500; ++i )
				items.Add(i);

			ListView listView = FindViewById<ListView>(Resource.Id.myListView);
			listView.Adapter = new MyListViewAdapter(this, items);

			buttonReference1.Click += delegate {
				buttonReference1.Text = string.Format ("{0} clicks!", count++);

				// Force a gref crash.
				List<RadioButton> buttons = new List<RadioButton>();
				do
					buttons.Add(new RadioButton(this));
				while ( true );
			};
		}
	}
}


