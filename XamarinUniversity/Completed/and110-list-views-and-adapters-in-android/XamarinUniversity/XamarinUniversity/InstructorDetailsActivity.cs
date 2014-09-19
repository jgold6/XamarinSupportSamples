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

namespace XamarinUniversity
{
	[Activity(Label = "Instructor Details", Icon = "@drawable/icon")]			
	public class InstructorDetailsActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.InstructorDetails);

			var position   = Intent.GetIntExtra("position", -1);
			var instructor = InstructorData.Instructors[position];

			var photo     = FindViewById<ImageView>(Resource.Id.photoImageView);
			var name      = FindViewById<TextView >(Resource.Id.nameTextView);
			var specialty = FindViewById<TextView >(Resource.Id.specialtyTextView);
			var biography = FindViewById<TextView >(Resource.Id.biographyTextView);

			photo.SetImageDrawable(ImageAssetManager.Get(this, instructor.ImageUrl));
			name     .Text = instructor.Name;
			specialty.Text = instructor.Specialty;
			biography.Text = instructor.Biography;
		}
	}
}