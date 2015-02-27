﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{	
	public partial class CustomCellXaml : ContentPage
	{	
		public CustomCellXaml ()
		{
			InitializeComponent ();

			listView.ItemsSource = new [] { "a", "b", "c" };
		}

		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			DisplayAlert("Tapped", e.SelectedItem + " row was tapped", "OK");
			((ListView)sender).SelectedItem = null; // de-select the row
		}

		public void OnCellClicked (object sender, EventArgs e) {
			var b = (Button)sender;
			var t = b.CommandParameter;
			((ContentPage)((ListView)((StackLayout)b.ParentView).ParentView).ParentView).DisplayAlert("Clicked", t + " button was clicked", "OK");
			Debug.WriteLine("clicked" + t);
		}
	}
}

