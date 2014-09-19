using MonoTouch.AVFoundation;

namespace GreatQuotes
{
	public class TextToSpeechService : ITextToSpeech
	{
		public void Speak(string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer();
			speechSynthesizer.SpeakUtterance(new AVSpeechUtterance(text) {
				Rate = AVSpeechUtterance.MaximumSpeechRate/4,
				Voice = AVSpeechSynthesisVoice.FromLanguage ("en-US"),
				Volume = .5f,
				PitchMultiplier = 1.0f
			});
		}
	}
}

