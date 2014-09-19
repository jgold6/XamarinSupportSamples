using System;
using System.Collections.Generic;

namespace GreatQuotes.Data
{
	public interface IQuoteRepository
	{
		IEnumerable<GreatQuote> Load();
		void Save(IEnumerable<GreatQuote> quotes);
	}

}

