using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes
{
	public class QuoteManager
	{
		public static QuoteManager Instance { get; private set;}

		readonly IQuoteRepository repo;

		public IList<GreatQuote> Quotes { get; private set; }

		public QuoteManager(IQuoteRepository repo)
	    {
			if (Instance != null)
				throw new Exception("Can only create a single QuoteManager.");

			Instance = this;
			this.repo = repo;
			Quotes = repo.Load().ToList();
	    }

		public void Save()
		{
			repo.Save(Quotes);
		}
	}
}

