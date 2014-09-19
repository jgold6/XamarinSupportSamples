using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;

namespace HelloWorld
{
	public class MyViewHolder : Java.Lang.Object
	{
		public TextView[] textViews = new TextView[50];
		public LinearLayout linLayout;
		public int position;



	}
}

