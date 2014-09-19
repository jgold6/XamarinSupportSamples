using System;
using System.IO;

namespace MyTunes
{
	class StreamLoader : IStreamLoader
	{
		public Stream GetStreamForFileName(string filename)
		{
			return File.OpenRead(filename);
		}
	}
}

