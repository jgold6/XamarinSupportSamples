using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: Step 2a - Use SQLite in IPlatform.
//using SQLite.Net.Interop;

namespace Xamarin.Data.Core
{
    public interface IPlatform
    {
        Stream SessionsPath { get; }
        
        string DatabasePath { get; }
        
        //TODO: Step 2b - Add ISQLitePlatform to IPlatform.
//        ISQLitePlatform SqlitePlatform { get; }
    }
}
