namespace GreatQuotes
{
	public class GreatQuote
	{
		static ITextToSpeech TTS;

		public string Author { get; set; }
		public string Quote { get; set; }

		public GreatQuote(ITextToSpeech tts = null) 
		{
			Author = string.Empty;
			Quote = "Say something interesting.";

			// Save off one copy for storage.
			if (GreatQuote.TTS == null && tts != null)
				GreatQuote.TTS = tts;
		}

		public void SayQuote()
		{
			if (TTS != null) {
				TTS.Speak(Quote + " by " + Author);
			}
		}
	}
}

