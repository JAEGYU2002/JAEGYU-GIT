using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// LotteryView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LotteryView : Window
    {
        public LotteryView()
        {
            InitializeComponent();
            this.DataContext = new LotteryViewModel();
        }
    }
}
