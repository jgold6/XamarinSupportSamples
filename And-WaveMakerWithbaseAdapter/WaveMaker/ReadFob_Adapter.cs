using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace WaveMaker
{
	public class ReadFob_Adapter : BaseAdapter 
	{
        Activity context;
		List<Tuple<string,string,int>> items;
		public ReadFob_Adapter(Activity context, List<Tuple<string,string,int>> objects)
            : base()
        {
            this.context = context;
			items = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.ImageAndSubtitleItem, null);
            //var view = context.LayoutInflater.Inflate(Android.Resource.Layout.SelectDialogMultiChoice, null);
			//var item = GetItem(position);

			view.FindViewById<TextView> (Resource.Id.Text1).Text = items[position].Item1;
			view.FindViewById<TextView>(Resource.Id.Text2).Text = items[position].Item2;
			view.FindViewById<ImageView>(Resource.Id.Icon).SetImageResource(items[position].Item3);

            return view;
        }

		public override int Count {
			get {return items.Count;}
		}
			
		public override Java.Lang.Object GetItem(int position) {
			return null;
		}

		public override long GetItemId(int position) {
			return position;
		}
    }
}