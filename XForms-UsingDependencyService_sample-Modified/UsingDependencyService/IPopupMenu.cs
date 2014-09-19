using System;

namespace UsingDependencyService
{
	public interface IPopupMenu
	{
		void Show(Xamarin.Forms.View v, Action<string> callback);
	}
}

