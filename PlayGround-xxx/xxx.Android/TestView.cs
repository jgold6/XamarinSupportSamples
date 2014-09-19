﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace xxx.Android
{
	public class TestView : TextView
	{
		public TestView(Context context) :
			base(context)
		{
			Initialize();
		}

		public TestView(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize();
		}

		public TestView(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			Initialize();
		}

		void Initialize()
		{
		}
	}
}

