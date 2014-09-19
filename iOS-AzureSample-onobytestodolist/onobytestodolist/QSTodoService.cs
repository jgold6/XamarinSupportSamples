using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using MonoTouch.UIKit;

namespace onobytestodolist
{
	public class QSTodoService : DelegatingHandler
	{
		static QSTodoService instance = new QSTodoService ();
		const string applicationURL = @"https://onobytestodolist.azure-mobile.net/";
		const string applicationKey = @"GizgzomDqWJMdMegYRycmRAcRnEcHv46";
		MobileServiceClient client;
		IMobileServiceTable<ToDoItem> todoTable;
		int busyCount = 0;

		public event Action<bool> BusyUpdate;

		private MobileServiceUser user; 
		public MobileServiceUser User { get { return user; } }

		QSTodoService ()
		{
			CurrentPlatform.Init ();

			// Initialize the Mobile Service client with your URL and key
			client = new MobileServiceClient (applicationURL, applicationKey, this);

			// Create an MSTable instance to allow us to work with the TodoItem table
			//todoTable = client.GetTable <ToDoItem> ();
		}

		public static QSTodoService DefaultService {
			get {
				return instance;
			}
		}

		public List<ToDoItem> Items { get; private set;}

		async public Task<List<ToDoItem>> RefreshDataAsync ()
		{
			try {
				// This code refreshes the entries in the list view by querying the TodoItems table.
				// The query excludes completed TodoItems
				Items = await todoTable
					.Where (todoItem => todoItem.Complete == false).ToListAsync ();

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}

			return Items;
		}

		public async Task InsertTodoItemAsync (ToDoItem todoItem)
		{
			try {
				// This code inserts a new TodoItem into the database. When the operation completes
				// and Mobile Services has assigned an Id, the item is added to the CollectionView
				await todoTable.InsertAsync (todoItem);
				Items.Add (todoItem); 

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		public async Task CompleteItemAsync (ToDoItem item)
		{
			try {
				// This code takes a freshly completed TodoItem and updates the database. When the MobileService 
				// responds, the item is removed from the list 
				item.Complete = true;
				await todoTable.UpdateAsync (item);
				Items.Remove (item);

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

		void Busy (bool busy)
		{
			// assumes always executes on UI thread
			if (busy) {
				if (busyCount++ == 0 && BusyUpdate != null)
					BusyUpdate (true);

			} else {
				if (--busyCount == 0 && BusyUpdate != null)
					BusyUpdate (false);

			}
		}

		private async Task Authenticate(UIViewController view)
		{
			try
			{
				user = await client.LoginAsync(view, MobileServiceAuthenticationProvider.Facebook);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine (@"ERROR - AUTHENTICATION FAILED {0}", ex.Message);
			}
		}

		private async Task CreateTable()
		{
			// Create an MSTable instance to allow us to work with the TodoItem table
			todoTable = client.GetTable<ToDoItem>();
		}

		public async Task LoginAndGetData(UIViewController view)
		{
			await Authenticate(view);
			await CreateTable();
		}

		#region implemented abstract members of HttpMessageHandler

		protected override async Task<System.Net.Http.HttpResponseMessage> SendAsync (System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
		{
			Busy (true);
			var response = await base.SendAsync (request, cancellationToken);

			Busy (false);
			return response;
		}

		#endregion
	}
}

