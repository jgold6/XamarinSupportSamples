using System;

using Android.App;
using Android.OS;
using Mono.Data.Sqlite;
using System.Runtime.InteropServices;

namespace Mono.Samples.HelloWorld
{
	[Activity (Label = "Hello World Demo", MainLauncher = true)]
	public class HelloAndroid : Activity
	{
		private SqliteConnection db;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			// SqliteConnection.SetConfig(SQLiteConfig.Serialized);
			sqlite3_shutdown();
			SqliteConnection.SetConfig(SQLiteConfig.Serialized);
			//sqlite3_config(3);
			sqlite3_initialize();


			base.OnCreate (savedInstanceState);
	
			SetContentView (Resource.Layout.main);
		}

		[DllImport("libsqlite.so")]
		internal static extern int sqlite3_shutdown();
		[DllImport("libsqlite.so")]
		internal static extern int sqlite3_initialize();
//		[DllImport("libsqlite.so")]
//		internal static extern int sqlite3_config(int configOption);
	}
}
