using GreatQuotes.Data;

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

		public void SayQuote()
		{
			ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();

			if (tts != null) {
				string text = Quote;

				if (string.IsNullOrEmpty(Author) == false) {
					text += " by " + Author;
				}

				tts.Speak(text);
			}
		}
	}
}

