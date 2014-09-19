using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;

namespace XformsBinding
{
	public class FirstViewModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string _mainText;
		private string _sayItText;

		public FirstViewModel()
		{
			_mainText = "Hello Xamarin Forms!";
			_sayItText = "Andorid Rocks!";
		}


		public String MainText
		{
			get {return _mainText;}
			set {
				//if (string.Compare(value, _mainText, StringComparison.OrdinalIgnoreCase) !=0) {
					_mainText = value;
					OnPropertyChanged();
				//}
			}
		}
		public String SayItText
		{
			get {return _sayItText;}
			set {
				//if (string.Compare(value, _sayItText, StringComparison.OrdinalIgnoreCase) !=0) {
					_sayItText = value; 
					OnPropertyChanged();
				//}
			}
		}
			
		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}

