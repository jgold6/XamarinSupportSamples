using System;
using System.IO;
using System.Net;
//TODO: Step 17a - Http using in Downloader.
using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin.Data.Core.WebServices
{
	public static class Downloader
	{
        static string sessionsXmlUrl = "http://docs.xamarin.com/xamu-wcf/Sessions.xml";

		internal async static Task DownloadSessionXmlAsync(StreamWriter streamWriter)
		{
			//TODO: Step 17b - Download sessions.
		    using (var httpClient = new HttpClient())
		        await streamWriter.WriteAsync(await httpClient.GetStringAsync(sessionsXmlUrl)).ConfigureAwait(false);
		}  
	}
}