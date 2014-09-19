using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace GreatQuotes
{
	/// <summary>
	/// Simple delegate-based Adapter to retrieve data.
	/// </summary>
	public class ListAdapter<T> : BaseAdapter<T>
	{
		IList<T> dataSource;
		Context context;

		/// <summary>
		/// Data source for the adapter.
		/// </summary>
		/// <value>The data source.</value>
		public IList<T> DataSource {
			get {
				return dataSource;
			}
			set {
				dataSource = value;
				this.NotifyDataSetChanged();
			}
		}

		/// <summary>
		/// Function to retrieve the text for the cell.
		/// </summary>
		/// <value>The text proc.</value>
		public Func<T,string> TextProc { get; set; }

		/// <summary>
		/// Function to retrieve the detail text for the cell
		/// </summary>
		/// <value>The detail text proc.</value>
		public Func<T,string> DetailTextProc { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context">Context.</param>
		public ListAdapter(Context context)
		{
			this.context = context;
		}

		/// <summary>
		/// Refreshes the data from the list.
		/// </summary>
		public void Refresh() 
		{
			this.NotifyDataSetChanged();
		}

		/// <summary>
		/// Retrieve the row id associated with the given position.
		/// </summary>
		/// <param name="position">Position in the list</param>
		public override long GetItemId(int position)
		{
			return position;
		}

		/// <summary>
		/// Retrieves the View for the given row index.
		/// </summary>
		/// <returns>The view.</returns>
		/// <param name="position">Position.</param>
		/// <param name="convertView">Convert view.</param>
		/// <param name="parent">Parent.</param>
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			if (view == null) {
				view = LayoutInflater.FromContext(context).Inflate(
					(DetailTextProc != null) 
					? global::Android.Resource.Layout.SimpleListItem2
					: global::Android.Resource.Layout.SimpleListItem1, null);
			}

			T item = dataSource[position];
			var text = view.FindViewById<TextView>(global::Android.Resource.Id.Text1);
			text.SetMaxLines(2);
			text.Ellipsize = Android.Text.TextUtils.TruncateAt.End;
			text.Text = TextProc == null ? item.ToString() : TextProc(item);

			if (DetailTextProc != null) {
				var detail = view.FindViewById<TextView>(global::Android.Resource.Id.Text2);
				detail.Text = DetailTextProc(item);
			}

			return view;
		}

		/// <summary>
		/// Count of items available
		/// </summary>
		public override int Count {
			get {
				return dataSource.Count;
			}
		}

		/// <summary>
		/// Indexer for the data.
		/// </summary>
		/// <param name="index">Index.</param>
		public override T this[int index] {
			get {
				return dataSource[index];
			}
		}
	}
}

