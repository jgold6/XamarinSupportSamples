using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics.Drawables;
using System.IO;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>
	{
		Activity         context;
		List<Instructor> instructors;

		public InstructorAdapter(Activity context, List<Instructor> instructors)
		{
			this.context     = context;
			this.instructors = instructors;
		}

		public override Instructor this[int position]
		{
			get
			{
				return instructors[position];
			}
		}

		public override int Count
		{
			get
			{
				return instructors.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = context.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);

			var photo     = view.FindViewById<ImageView>(Resource.Id.photoImageView);
			var name      = view.FindViewById<TextView >(Resource.Id.nameTextView);
			var specialty = view.FindViewById<TextView >(Resource.Id.specialtyTextView);

			Stream   stream   = context.Assets.Open(instructors[position].ImageUrl);
			Drawable drawable = Drawable.CreateFromStream(stream, null);
			photo.SetImageDrawable(drawable);

			name     .Text = instructors[position].Name;
			specialty.Text = instructors[position].Specialty;

			return view;
		}
	}
}