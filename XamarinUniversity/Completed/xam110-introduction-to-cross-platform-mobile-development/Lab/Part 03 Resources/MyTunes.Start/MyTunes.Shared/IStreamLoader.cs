using System;
using System.IO;

namespace MyTunes
{
    public interface IStreamLoader
    {
		Stream GetStreamForFileName(string filename);

    }
}

