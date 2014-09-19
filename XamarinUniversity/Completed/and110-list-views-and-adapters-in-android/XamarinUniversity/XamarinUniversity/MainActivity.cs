using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity
{
    [Activity(Label = "Instructors", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
			var listView = FindViewById<ListView>(Resource.Id.instructorListView);
			//ArrayAdapter adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1, InstructorData.Instructors);
			var adapter = new InstructorAdapter(this, InstructorData.Instructors);

			listView.Adapter = adapter;

			listView.FastScrollEnabled = true;

			listView.ItemClick += HandleItemClick;
        }

        void HandleItemClick (object sender, AdapterView.ItemClickEventArgs e)
        {
			var position = e.Position;
			var intent = new Intent(this, typeof(InstructorDetailsActivity));
			intent.PutExtra("position", position);
			StartActivity(intent);

//			var dialog = new AlertDialog.Builder(this)
//				.SetTitle("Instructor")
//				.SetMessage(string.Format("You selected {0}", InstructorData.Instructors[position].Name))
//				.SetNeutralButton("Close", delegate(object sender2, DialogClickEventArgs e2) {
//					Console.WriteLine("Close Clicked: {0}, {1}", sender2, e2.Which);
//				});
//			dialog.Show();

        }
    }
}


