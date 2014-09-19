using Android.Speech.Tts;
using Android.App;
using System.Collections.Generic;
using GreatQuotes.Data;

namespace GreatQuotes
{
	public class TextToSpeechService : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speech;
		string lastText;

		public void Speak(string text)
		{
			if (speech == null) {
				lastText = text;
				speech = new TextToSpeech(Application.Context, this);
			}
			else {
				speech.Speak(text, QueueMode.Flush, new Dictionary<string,string>());
			}
		}

		public void OnInit(OperationResult status)
		{
			if (status == OperationResult.Success) {
				speech.Speak(lastText, QueueMode.Flush, new Dictionary<string,string>());
				lastText = null;
			}
		}
	}
}

