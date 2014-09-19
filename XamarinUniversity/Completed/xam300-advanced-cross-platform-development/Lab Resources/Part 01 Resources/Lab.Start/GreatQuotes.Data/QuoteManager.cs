using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes.Data
{
	public class QuoteManager
	{
		static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());
		public static QuoteManager Instance 
		{ 
			get { return instance.Value; }
		}

		readonly IQuoteRepository repo;

		public IList<GreatQuote> Quotes { get; private set; }

		QuoteManager()
		{
			repo = QuoteRepositoryFactory.Create();
			Quotes = repo.Load().ToList();
		}

		public void Save()
		{
			repo.Save(Quotes);
		}
	}
}

