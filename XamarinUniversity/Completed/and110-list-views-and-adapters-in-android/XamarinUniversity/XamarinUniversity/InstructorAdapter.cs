using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using System.IO;
using Android.Graphics.Drawables;

namespace XamarinUniversity
{
	public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
		List<Instructor> instructors;
		Activity context;

		Java.Lang.Object[] sectionHeaders
		= SectionIndexerBuilder.BuildSectionHeaders(InstructorData.Instructors);

		Dictionary<int, int> positionForSectionMap
		= SectionIndexerBuilder.BuildPositionForSectionMap(InstructorData.Instructors);

		Dictionary<int, int> sectionForPositionMap
		= SectionIndexerBuilder.BuildSectionForPositionMap(InstructorData.Instructors);

        public InstructorAdapter()
        {
        }

		public InstructorAdapter(MainActivity cont, List<Instructor> inst)
		{
			this.context = cont;
			this.instructors = inst;

		
		}

		public override Instructor this[int index]
		{
			get
			{
				return instructors[index];
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



		public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var view = convertView;

			if (view == null) {
				view = context.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);

				var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
				var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
				var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

				view.Tag = new ViewHolder() { Photo = photo, Name = name, Specialty = specialty };
			}

			var holder = (ViewHolder)view.Tag;

			var item = instructors[position];

			holder.Photo.SetImageDrawable(ImageAssetManager.Get(context, item.ImageUrl));
			holder.Name.Text = item.Name;
			holder.Specialty.Text = item.Specialty;

			return view;
		}

		// ISectionIndexer implementation

		public Java.Lang.Object[] GetSections()
		{
			return sectionHeaders;
		}

		public int GetPositionForSection(int section)
		{
			return positionForSectionMap[section];
		}

		public int GetSectionForPosition(int position)
		{
			return sectionForPositionMap[position];
		}

	}
}

