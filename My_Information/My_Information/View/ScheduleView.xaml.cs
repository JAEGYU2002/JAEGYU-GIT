using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// ScheduleView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScheduleView : Window
    {
        public ScheduleView()
        {
            InitializeComponent();
            this.DataContext = new ScheuleViewModel();
            test.AcceptsReturn = true;
        }
    }
}
