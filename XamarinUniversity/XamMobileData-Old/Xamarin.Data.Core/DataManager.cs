using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Data.Core.Model;
using Xamarin.Data.Core.Orm;
using Xamarin.Data.Core.WebServices;

namespace Xamarin.Data.Core
{
    public class DataManager
    {
        private readonly IPlatform _platform;

        private ConferenceDatabaseAsync _conferenceDatabase;
		//TODO: Step 13 - Offer a ConferenceDatabaseAsync through DataManager
        public ConferenceDatabaseAsync ConferenceDatabase
        {
            get
            {
                return _conferenceDatabase ??
                (
                    _conferenceDatabase = new ConferenceDatabaseAsync(() =>
                        new SQLite.Net.SQLiteConnectionWithLock(
                            _platform.SqlitePlatform,
                            new SQLite.Net.SQLiteConnectionString(_platform.DatabasePath, true)))
                );
            }
        }

        public DataManager(IPlatform platform)
        {
            _platform = platform;
        }

        public async Task DownloadSessionXmlAsync()
        {
            using (var streamWriter = new StreamWriter(_platform.SessionsPath))
                await Downloader.DownloadSessionXmlAsync(streamWriter).ConfigureAwait(false);
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            return await SessionsXmlParser.GetSessionsAsync(_platform.SessionsPath).ConfigureAwait(false);
        }

    }
}
