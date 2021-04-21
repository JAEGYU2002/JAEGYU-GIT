using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// MusicView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MusicView : Window
    {
        public MusicView()
        {
            InitializeComponent();
            this.DataContext = new MusicViewModel();
        }
    }
}
