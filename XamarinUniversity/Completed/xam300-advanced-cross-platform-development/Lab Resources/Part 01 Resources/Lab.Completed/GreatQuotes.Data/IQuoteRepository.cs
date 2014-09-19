using System.Collections.Generic;

namespace GreatQuotes
{
	public interface IQuoteRepository
	{
		IEnumerable<GreatQuote> Load();
		void Save(IEnumerable<GreatQuote> quotes);
	}
}
