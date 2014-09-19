
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
	[Activity (Label = "PARTICIPANTES", MainLauncher = true, Icon = "@drawable/icon")]			
	public class entries : Activity
	{

		List<TableItem> entryList = new List<TableItem> ();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			Spinner spnRegata = FindViewById<Spinner> (Resource.Id.spnRegata);
			fFillSpinner ();

			entryList.Add (new TableItem () { txtHelm = "MIGUEL PALACIO - INT 420" });
			entryList.Add (new TableItem () { txtHelm = "EUGENIO GARCERÁ - INT 420" });
			entryList.Add (new TableItem () { txtHelm = "ADRIAN HART - INT 420" });
			entryList.Add (new TableItem () { txtHelm = "JUANJO BARCELÓ - LASER STD" });
			entryList.Add (new TableItem () { txtHelm = "GUILLERMO PONZINIBBIO - LASER STD" });
			entryList.Add (new TableItem () { txtHelm = "DIEGO DIAZ - LASER STD" });
			entryList.Add (new TableItem () { txtHelm = "JUAN TABOADA - LASER STD" });
			entryList.Add (new TableItem () { txtHelm = "RODRIGO AZCUETA - LASER 4000" });
			entryList.Add (new TableItem () { txtHelm = "DAAN HIRS - LASER VAGO" });


			var ListAdapter = new entriesAdapter (this, entryList);
			var listView = FindViewById<ListView> (Resource.Id.lstEntries);

			listView.Adapter = ListAdapter;
			listView.ChoiceMode = Android.Widget.ChoiceMode.Multiple;
			listView.SetItemChecked(0, true);
			listView.SetItemChecked(2, true);
			listView.SetItemChecked(4, true);

			var sparseArray = listView.CheckedItemPositions;
			string t = "";
			for (var i = 0; i < sparseArray.Size (); i++)
				t = (sparseArray.KeyAt (i) + "=" + sparseArray.ValueAt (i) + ",") + t;
			Android.Widget.Toast.MakeText (this, t, Android.Widget.ToastLength.Short).Show ();

		}

		public void fFillSpinner ()
		{




		}


	}
}

