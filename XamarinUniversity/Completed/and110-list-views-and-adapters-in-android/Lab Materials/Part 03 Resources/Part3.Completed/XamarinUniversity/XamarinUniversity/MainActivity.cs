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
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var instructorList = FindViewById<ListView>(Resource.Id.instructorListView);
			instructorList.ItemClick += OnItemClick;

			instructorList.Adapter = new InstructorAdapter(this, InstructorData.Instructors);
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var instructor = InstructorData.Instructors[e.Position];

			var dialog = new AlertDialog.Builder(this);
			dialog.SetMessage(instructor.Name);
			dialog.SetNeutralButton("OK", delegate { });
			dialog.Show();
		}
	}
}