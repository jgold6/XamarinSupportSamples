using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Phoneword
{
	[Activity(Label = "@string/callHistory", Icon = "@drawable/history")]
	public class CallHistoryActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.CallHistory);

			var phoneNumbers = Intent.GetStringArrayListExtra("phone_numbers") ?? new string[0];

			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, phoneNumbers);

			var list = FindViewById<ListView>(Resource.Id.PhoneNumberList);
			list.Adapter = adapter;		
		}
	}
}