
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

namespace TestMultiChoice
{
	public class TableItem
	{
		public string Heading { get; set; }

		public string SubHeading { get; set; }

		public int ImageResourceId { get; set; }

		public string txtHelm { get; set; }

		public string txtClass { get; set; }
	}
}
