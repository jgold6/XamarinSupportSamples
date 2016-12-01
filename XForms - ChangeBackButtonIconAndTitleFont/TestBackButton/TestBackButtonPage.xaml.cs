using Xamarin.Forms;

namespace TestBackButton
{
	public partial class TestBackButtonPage : ContentPage
	{
		public TestBackButtonPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new Page2());
		}
	}
}
