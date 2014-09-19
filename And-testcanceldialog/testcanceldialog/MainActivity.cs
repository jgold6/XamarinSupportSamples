using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace testcanceldialog
{
	[Activity(Label = "testcanceldialog", MainLauncher = true)]
	public class MainActivity : Activity, IMenuItemOnMenuItemClickListener
	{
		Button button;
		View messageView;
		AlertDialog dialog;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button>(Resource.Id.myButton);
			
			button.Click += delegate
			{
				messageView = new MessView(this);
				MessageView(this, "Hello World", "This is the dialog", messageView, "OK", "Cancel",true, null);
			};

		}

		public Task<bool> MessageView(Context context, string title, string message, View view, string yesText = "OK", string noText = "Cancel", bool showNoButton = true, Action<AlertDialog> onShown = null)
		{
			var tcs = new TaskCompletionSource<bool>();
			var builder = new AlertDialog.Builder(context).SetPositiveButton(yesText, (sender, args) =>
				{
					button.Text = "OK Pressed";
					tcs.SetResult(true);
				});

			if (showNoButton) {
				builder.SetNegativeButton(noText, (sender, args) =>
				{
					button.Text = "Cancel Pressed";
					tcs.SetResult(false);
				});
			}

			dialog = builder.SetView(view).SetMessage(message).SetTitle(title).Show();

			dialog.CancelEvent += delegate(object sender, EventArgs e)
			{
				button.Text = "Cancelled";
				tcs.SetResult(false);
			};

			RegisterForContextMenu(messageView);
			// Alternate for messageView.ContextMenuCreated
//			messageView.SetOnCreateContextMenuListener(this);
			messageView.ContextMenuCreated += (object sender, View.CreateContextMenuEventArgs e) => {
				MenuInflater inflater = this.MenuInflater;
				inflater.Inflate(Resource.Menu.ContextMenu, e.Menu);
				// No event properties for the below, must use interface.
				e.Menu.GetItem(0).SetOnMenuItemClickListener(this);
				e.Menu.GetItem(1).SetOnMenuItemClickListener(this);
			};

			messageView.Click += delegate {
				dialog.Cancel();
			};

			if (onShown != null)
				onShown(dialog);

			return tcs.Task;
		}

		// Alternate for messageView.ContextMenuCreated
//		public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
//		{
//			base.OnCreateContextMenu(menu, v, menuInfo);
//			MenuInflater inflater = this.MenuInflater;
//			inflater.Inflate(Resource.Menu.ContextMenu, menu);
//			menu.GetItem(0).SetOnMenuItemClickListener(this);
//			menu.GetItem(1).SetOnMenuItemClickListener(this);
//		}

		public bool OnMenuItemClick(IMenuItem menuItem)
		{
			var title = menuItem.TitleFormatted.ToString();
			switch (title) {
				case "ContextMenu1":
					Console.WriteLine("ContextMenu1 clicked");
					dialog.SetTitle("ContextMenu1 clicked");
					break;
				case "ContextMenu2":
					Console.WriteLine("ContextMenu2 clicked");
					dialog.SetTitle("ContextMenu2 clicked");
					break;
				default:
					break;
			}
			return true;
		}
	}
}


