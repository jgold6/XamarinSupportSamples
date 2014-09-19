using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//TODO: Step 1a - using SQLite in ConferenceDatabaseAsync
//using SQLite.Net.Async;
using Xamarin.Data.Core.Model;

namespace Xamarin.Data.Core.Orm
{
    //TODO: Step 1b - Inherit from SQLiteAsyncConnection
//    public class ConferenceDatabaseAsync : SQLiteAsyncConnection
    public class ConferenceDatabaseAsync
    {
        //TODO: Step 1c - Allow injection of function to get platform-specific connection
//        public ConferenceDatabaseAsync(Func<SQLite.Net.SQLiteConnectionWithLock> connection)
//            : base(connection)
//        {
//
//        }

        public async Task SetupDatabaseAsync()
        {
            //TODO: Step 5 - Create tables
//            // create the SQLite database tables based on the Model classes
//            await CreateTableAsync<Session>().ConfigureAwait(false);
//            await CreateTableAsync<Speaker>().ConfigureAwait(false);
        }

        #region Sessions

        public async Task<List<Session>> GetSessionsAsync()
        {
            //TODO: Step 6a - Remove placeholder return
            return await Task.FromResult<List<Session>>(null);
            //TODO: Step 6b - Select All Records from Table 
//            return await Table<Session>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<Session> GetSessionAsync(int id)
        {
            //TODO: Step 7a - Remove placeholder return
            return await Task.FromResult<Session>(null);
            //TODO: Step 7b - Select records from table using Linq
//            return await Table<Session>().Where(s => s.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveSessionAsync(Session item)
        {
            //TODO: Step 8a - Remove placeholder return
            return await Task.FromResult(-1);
            //TODO: Step 8b - Perform an insert or update to the database 
//            if (item.Id <= 0)
//                return await InsertAsync(item).ConfigureAwait(false);
//
//            await UpdateAsync(item).ConfigureAwait(false);
//            return item.Id;
        }

        public async Task SaveSessionsAsync(IEnumerable<Session> sessions)
        {
            //TODO: Step 8c - Perform a bulk insert or update to the database
//            await InsertAllAsync(sessions).ConfigureAwait(false);
        }

        public async Task<int> DeleteSessionAsync(Session session)
        {
            //TODO: Step 9a - Remove placeholder return
            return await Task.FromResult(-1);
            //TODO: Step 9b - Delete a record from the table
//            return await DeleteAsync(session).ConfigureAwait(false);
        }

        public async Task DeleteSessionsAsync()
        {
            //TODO: Step 10 - Delete all data using SQL commands
//            await this.ExecuteAsync("DELETE FROM Session;").ConfigureAwait(false);
        }

        #endregion Sessions
    }
}
