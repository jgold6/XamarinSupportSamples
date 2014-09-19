using System;
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

namespace testcanceldialog
{
	public class MessView : View
	{
		public MessView(Context context) :
			base(context)
		{
			Initialize();
			this.SetBackgroundColor(Android.Graphics.Color.Azure);
		}

		public MessView(Context context, IAttributeSet attrs) :
			base(context, attrs)
		{
			Initialize();
		}

		public MessView(Context context, IAttributeSet attrs, int defStyle) :
			base(context, attrs, defStyle)
		{
			Initialize();
		}

		void Initialize()
		{

		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
			this.LayoutParameters.Width = ViewGroup.LayoutParams.FillParent;
			this.LayoutParameters.Height = 100;
		}
	}
}

