namespace My_Information.ViewModel
{
    public class UserManagementViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string userID { get; set; }
        public UserManagementViewModel()
        {

        }
    }
}
