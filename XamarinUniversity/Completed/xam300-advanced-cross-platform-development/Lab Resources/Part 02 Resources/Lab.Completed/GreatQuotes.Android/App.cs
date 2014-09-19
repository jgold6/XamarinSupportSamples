using Android.App;
using System;
using Android.Runtime;

namespace GreatQuotes
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

		public override void OnCreate()
		{
			QuoteRepositoryFactory.Create = () => new QuoteLoader();
			ServiceLocator.Instance.Add<ITextToSpeech, TextToSpeechService>();

			base.OnCreate();
		}
	}
}

