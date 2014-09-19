using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace GreatQuotes
{
	public class QuoteLoader : IQuoteRepository
	{
		const string FileName = "quotes.xml";

		Func<GreatQuote> quoteCreator;

		public QuoteLoader(Func<GreatQuote> quoteCreator)
		{
			this.quoteCreator = quoteCreator;
		}

		private string GetFileName()
		{
			#if __IOS__
			return Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
				"..", "Library", FileName);
			#elif __ANDROID__
			return Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
				FileName);
			#endif
		}

		public IEnumerable<GreatQuote> Load()
		{
			XDocument doc = null;

			string filename = GetFileName();
			if (File.Exists(filename)) {
				try 
				{
					doc = XDocument.Load(filename);
				} 
				catch 
				{
				}
			} 

			if (doc == null)
				doc = XDocument.Parse(DefaultData);

			if (doc.Root != null) {
				foreach (var entry in doc.Root.Elements("quote")) {
					var quote = quoteCreator();
					quote.Author = entry.Attribute("author").Value;
					quote.Quote = entry.Value;
					yield return quote;
				}
			}
		}

		public void Save(IEnumerable<GreatQuote> quotes)
		{
			string filename = GetFileName();

			if (File.Exists(filename))
				File.Delete(filename);

			XDocument doc = new XDocument(
				new XElement("quotes",
					quotes.Select(q =>
						new XElement("quote", new XAttribute("author", q.Author))
						{
							Value = q.Quote
						})));

			doc.Save(filename);
		}

		#region Internal Data
		static string DefaultData = 
			@"<?xml version=""1.0"" encoding=""UTF-8""?>
<quotes>
	<quote author=""Eleanor Roosevelt"">Great minds discuss ideas; average minds discuss events; small minds discuss people.</quote>
	<quote author=""William Shakespeare"">Some are born great, some achieve greatness, and some have greatness thrust upon them.</quote>
	<quote author=""Winston Churchill"">All the great things are simple, and many can be expressed in a single word: freedom, justice, honor, duty, mercy, hope.</quote>
	<quote author=""Ralph Waldo Emerson"">Our greatest glory is not in never failing, but in rising up every time we fail.</quote>
	<quote author=""William Arthur Ward"">The mediocre teacher tells. The good teacher explains. The superior teacher demonstrates. The great teacher inspires.</quote>
</quotes>";
		#endregion
	}
}
