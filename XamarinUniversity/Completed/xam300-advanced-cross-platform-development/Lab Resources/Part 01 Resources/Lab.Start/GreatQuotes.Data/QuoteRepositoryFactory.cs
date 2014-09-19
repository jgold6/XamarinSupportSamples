using System;

namespace GreatQuotes.Data
{
    public static class QuoteRepositoryFactory
    {
		public static Func<IQuoteRepository> Create { get; set; }
    }
}

