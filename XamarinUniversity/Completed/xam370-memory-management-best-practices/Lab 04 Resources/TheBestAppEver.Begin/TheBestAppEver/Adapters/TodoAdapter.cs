using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Webkit;

namespace TheBestAppEver
{
	class TodoAdapter : BaseAdapter<TodoItem>
	{
		readonly List<TodoItem> data;
		readonly Context context;

		public TodoAdapter(Context context, IEnumerable<TodoItem> data)
		{
			this.context = context;
			this.data = data.ToList();
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override TodoItem this[int index] {
			get { 
				return data[index];
			}
		}

		public class ViewHolder : Java.Lang.Object
		{
			public TextView label;
			public TextView details;
			public ImageView icon;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{

			var item = data[position];

			var view = convertView;
			ViewHolder holder;
			if (view == null) {
				view = LayoutInflater.FromContext(context).Inflate(Resource.Layout.TodoItemCell, parent, false);
				holder = new ViewHolder() {
					label = view.FindViewById<TextView>(Resource.Id.label),
					details = view.FindViewById<TextView>(Resource.Id.details),
					icon = view.FindViewById<ImageView>(Resource.Id.icon)
				};
				holder.icon.SetImageResource(Resource.Drawable.check);
				view.Tag = holder;

			}
			holder = view.Tag as ViewHolder;
			holder.label.Text = item.Title;
			holder.details.Text = item.Notes;
			holder.icon.Visibility = (item.Completed) ? ViewStates.Visible : ViewStates.Invisible;

			return view;
		}
	}
}

