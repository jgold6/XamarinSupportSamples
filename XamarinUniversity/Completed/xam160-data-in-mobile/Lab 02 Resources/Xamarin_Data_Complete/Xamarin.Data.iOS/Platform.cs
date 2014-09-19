using System;
using System.IO;
//TODO: Step 11a - iOS - Using SQLite in Platform
using SQLite.Net.Interop;
using Xamarin.Data.Core;
using Xamarin.Data.Core.Orm;

namespace Xamarin.Data.iOS
{
	//TODO: Step 11b - iOS - Implement the platform configurations
    class Platform : IPlatform
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
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                return Path.Combine(libraryPath, sqliteFilename);
            }
        }
    
        public ISQLitePlatform SqlitePlatform
        {
            get {return new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();}
        }
    }
}