using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// MemoView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MemoView : Window
    {
        public MemoView()
        {
            InitializeComponent();
            MemoBox.AcceptsReturn = true;
            this.DataContext = new MemoViewModel();
        }

        //MemoView 창 닫기
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
