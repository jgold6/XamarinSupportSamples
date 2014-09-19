using System;
using System.Collections.Generic;
using System.Linq;
using Android.Widget;
using Android.App;
using Android.Views;

namespace AsyncWork
{
	public class StringAdapter<T> : BaseAdapter<T>
	{
		readonly List<T> data;
		readonly Func<T, long> getItemId;
		readonly Func<T, string> getText;
		readonly Func<T, string> getDetailText;

		public StringAdapter(IEnumerable<T> data, Func<T, long> getItemId = null, 
			Func<T, string> getText = null, Func<T, string> getDetailText = null)
		{
			this.getDetailText = getDetailText;
			this.getText = getText;
			this.getItemId = getItemId;
			this.data = data.ToList();
		}

		public override int Count {
			get {
				return data.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return getItemId == null ? position : getItemId(data[position]);
		}

		public override T this[int index] {
			get { return data[index]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var context = Application.Context;

			var view = convertView;
			if (view == null) {
				view = LayoutInflater.FromContext(context).Inflate(
					(getDetailText != null) 
					? Android.Resource.Layout.SimpleListItem2
					: Android.Resource.Layout.SimpleListItem1, null);
			}

			var item = data[position];
			var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
			text.Text = getText == null ? item.ToString() : getText(item);

			if (getDetailText != null) {
				var detail = view.FindViewById<TextView>(Android.Resource.Id.Text2);
				detail.Text = getDetailText(item);
			}

			return view;
		}
	}
}

