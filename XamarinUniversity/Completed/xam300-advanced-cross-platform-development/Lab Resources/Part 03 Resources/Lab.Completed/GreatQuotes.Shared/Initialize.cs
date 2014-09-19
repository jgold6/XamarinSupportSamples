using System;

namespace GreatQuotes
{
	/// <summary>
	/// Simple class to intitialize our container and create all
	/// the dependencies.
	/// </summary>
    public class Initialize
    {
		readonly SimpleContainer container = new SimpleContainer();

		public void Setup()
		{
			container.Register<SimpleContainer>(() => container);
			container.Register<Func<GreatQuote>>(() => container.FactoryFor<GreatQuote>());
			container.Register<IQuoteRepository, QuoteLoader>();
			container.Register<ITextToSpeech, TextToSpeechService>();
			container.Create<QuoteManager>();
		}
    }
}

