using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TransparentDialog
{
	[Activity (Label = "TransparentDialog", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				Show();
			};
		}

		private void Show()
		{
			TransparentDialog dlg = new TransparentDialog(this);
			dlg.SetTitle("Dialog Box");
			dlg.Show ();
		}
	}

	public class TransparentDialog : Dialog
	{
		public TransparentDialog(Context context) : base(context, Resource.Style.THENameHere)
		{
			
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			this.SetContentView(Resource.Layout.DialogLayout);
		}
	}
}


