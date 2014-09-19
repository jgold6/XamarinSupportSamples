using System;
using System.Collections.Generic;
using System.IO;
// TODO: Step 1a include namespaces
using Mono.Data.Sqlite;
using Xamarin.AdoData.Core.Model;
using System.Threading.Tasks;

namespace Xamarin.AdoData.Core.Ado
{
    public class StockDatabase
    {
        private static readonly AsyncLock Mutex = new AsyncLock();

		//TODO: Step 1b - Setup database path 
        private static string _databaseFilePath;

        public static string DatabaseFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(_databaseFilePath))
                    return _databaseFilePath;

                const string sqliteFilename = "StockDB.db3";

				// Get the documents folder.
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#if __IOS__
				// In iOS we want to use the library path so this file is not
				// backed up to iCloud.
				path = Path.Combine(path, "..", "Library"); // Library folder
#endif

				_databaseFilePath = Path.Combine(path, sqliteFilename);

                return _databaseFilePath;
            }
        }

        private static SqliteConnection CreateConnection()
        {
            return new SqliteConnection("Data Source=" + DatabaseFilePath);
        }

		private async Task<int> ExecuteNonQueryAsync(string commandText)
		{
		    var updates = 0;
		    using (await Mutex.LockAsync().ConfigureAwait(false))
		    {
		        using (var connection = CreateConnection())
		        {
		            connection.Open();
		            using (var transaction = connection.BeginTransaction())
		            {
		                using (var c = connection.CreateCommand())
		                {
		                    c.CommandText = commandText;
		                    updates = await c.ExecuteNonQueryAsync().ConfigureAwait(false);
		                }
		                transaction.Commit();
		            }
		            connection.Close();
		        }
		    }

		    return updates;
		}

		//TODO: Step 2 - Create Database if it does not currently exist
		public async Task<bool> CreateDatabaseIfNotExistsAsync()
		{
		    if (File.Exists(DatabaseFilePath))
		        return true;

		    return await 
		        ExecuteNonQueryAsync("CREATE TABLE [Stock] (_id ntext, Symbol ntext);").ConfigureAwait(false) > 0;
		}

		// TODO: Step 3 - Query database and map to model objects
		public async Task<IList<Stock>> SelectStockAsync()
		{
			var stockInDatabase = new List<Stock>();

			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				using (var connection = CreateConnection())
				{
					connection.Open();

					using (var contents = connection.CreateCommand())
					{
						contents.CommandText = "SELECT [_id], [Symbol] from [Stock]";
						using (var reader = await contents.ExecuteReaderAsync().ConfigureAwait(false))
						{
							while (await reader.ReadAsync().ConfigureAwait(false)) {
								stockInDatabase.Add(
									new Stock {
										Id = Convert.ToInt32(reader["_id"]),
										Symbol = reader["Symbol"].ToString()
									});
							}

						    reader.Close();
						}
					}
					connection.Close();
				}
			}
			return stockInDatabase;
		}

		//TODO: Step 4 - Perform an Insert
		public async Task<bool> InsertStockAsync(Stock stock)
		{
			var updates = 0;
			using (await Mutex.LockAsync().ConfigureAwait(false))
			{
				using (var connection = CreateConnection())
				{
					connection.Open();
					using (var transaction = connection.BeginTransaction())
					{
						using (var c = connection.CreateCommand())
						{
							c.CommandText = "INSERT INTO Stock (_id, Symbol) values (@id, @symbol);";
							c.Parameters.Add ("@id", System.Data.DbType.String).Value = stock.Id;
							c.Parameters.Add ("@symbol", System.Data.DbType.String).Value = stock.Symbol;

							updates = await c.ExecuteNonQueryAsync().ConfigureAwait(false);
						}
						transaction.Commit();
					}
					connection.Close();
				}
			}

			return updates > 0;
		}
    }
}