using System;

namespace GreatQuotes
{
	public static class QuoteRepositoryFactory
	{
		public static Func<IQuoteRepository> Create { get; set; }
	}
}
