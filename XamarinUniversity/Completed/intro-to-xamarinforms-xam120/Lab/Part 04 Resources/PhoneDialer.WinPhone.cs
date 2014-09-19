using Microsoft.Phone.Tasks;
using Phoneword.WinPhone;

namespace Phoneword.WinPhone
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask 
			{ 
				PhoneNumber = number, DisplayName = "Phoneword" 
			};
            
			phoneCallTask.Show();
            return true;
        }
    }
}