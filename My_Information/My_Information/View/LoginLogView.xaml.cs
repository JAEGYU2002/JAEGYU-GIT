using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// LoginLogView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginLogView : Window
    {
        public LoginLogView()
        {
            InitializeComponent();
            this.DataContext = new LoginlogViewModel();
        }
    }
}
