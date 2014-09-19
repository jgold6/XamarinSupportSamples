using System;

namespace SearchSample
{
    public class GuidIndexedDataItem
    {
        public Guid I { get; set; }
        public string X { get; set; }
        public string T { get; set; }

        public GuidIndexedDataItem(string guid, string index, string text)
        {
            I = new Guid(guid);
            X = index;
            T = text;
        }
    }
}