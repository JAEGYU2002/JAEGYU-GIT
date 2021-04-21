using System.IO;

namespace My_Information.ViewModel
{
    public class LoginlogViewModel : Notifier
    {
        public string logText { get; set; }        
        public LoginlogViewModel()
        {
            logText = File.ReadAllText(@"C:\Users\heath\Desktop\My_Information\My_Information\bin\Debug\LoginLog.txt");
        }
    }
}
