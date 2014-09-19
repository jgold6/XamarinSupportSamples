using NUnit.Framework;
using System;

namespace PhoneWord.UnitTests.iOS
{
	[TestFixture()]
	public class Test
	{
		IApp _app;

		[SetUp]
		public void DoSetup()
		{
			_app = ConfigureApp.iOS
				.AppBundle ("/path/to/iosapp")
				.StartApp();
//			app.EnterText (cw = cw.Class("UITextField"), "1-855-XAMARIN");
		}

		[Test()]
		public void StartupRepl()
		{
			_app.Repl ();
		}
	}
}

