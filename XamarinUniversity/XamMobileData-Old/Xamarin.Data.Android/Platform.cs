using System;
using System.IO;
//TODO: Step 11a - Android - Using SQLite in Platform
using SQLite.Net.Interop;
using Xamarin.Data.Core;
using Xamarin.Data.Core.Orm;

namespace Xamarin.Data.Droid
{
	//TODO: Step 11b - Android - Implement the platform configurations
    public class Platform : IPlatform
    {
        const string sqliteFilename = "StockDB.db3";
    
        public Stream SessionsPath
        {
            get
            {
                return 
                    File.Open(
                        Path.Combine(
                            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                            "Sessions.xml")
                        , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
        }
    
        public string DatabasePath
        {
            get
            {
                return Path.Combine(
                  System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                  sqliteFilename);
            }
        }
    
		public ISQLitePlatform SqlitePlatform
        {
			get { return new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(); }
        }
    }
}