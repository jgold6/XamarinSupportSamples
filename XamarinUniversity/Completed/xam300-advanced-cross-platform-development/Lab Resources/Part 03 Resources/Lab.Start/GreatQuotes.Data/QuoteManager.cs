using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes
{
	public class QuoteManager
	{
		//static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());
		public static QuoteManager Instance {get; private set;}
//		{ 
//			get	{ return instance.Value; }
//		}

		readonly IQuoteRepository repo;

		public IList<GreatQuote> Quotes { get; private set; }

		public QuoteManager(IQuoteRepository repo)
	    {
			//repo = QuoteRepositoryFactory.Create();
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

