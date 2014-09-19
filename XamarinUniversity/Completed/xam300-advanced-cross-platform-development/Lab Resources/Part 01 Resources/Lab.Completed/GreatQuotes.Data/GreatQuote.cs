namespace GreatQuotes
{
	public class GreatQuote
	{
		public string Author { get; set; }
		public string Quote { get; set; }

		public GreatQuote() : this("Unknown","Quote goes here..")
		{
		}

		public GreatQuote(string author, string quote)
		{
			Author = author;
			Quote = quote;
		}
	}
}

