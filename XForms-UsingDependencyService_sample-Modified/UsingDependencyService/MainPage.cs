using System;
using Xamarin.Forms;

namespace UsingDependencyService
{
	public class MainPage : ContentPage
	{
		Button speak;
		public MainPage ()
		{
//			var speak = new Button {
//				Text = "Hello, Forms !",
//				VerticalOptions = LayoutOptions.CenterAndExpand,
//				HorizontalOptions = LayoutOptions.CenterAndExpand,
//			};
//			speak.Clicked += (sender, e) => {
//				DependencyService.Get<IToast>().Show("Hello World!");
//			};
//			speak.Clicked += (sender, e) => {
//				DependencyService.Get<ITextToSpeech>().Speak("Hello from Xamarin Forms");
//			};
			speak = new Button {
				Text = "Click",
				Command = new Command (() => {
					DependencyService.Get<IPopupMenu> ().Show (speak, (item)=> {
						DependencyService.Get<IToast>().Show(item);
					});
				})
			};
			Content = speak;
		}
	}
}

