using System.Windows;
using My_Information.ViewModel;
using My_Information.Login;

namespace My_Information
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string authorization = LoginViewModel.LD.user1.authorization.ToString();
            if (authorization == "0")
                AdminButton.IsEnabled = false;
            this.DataContext = new MainWindowViewModel();
    }

        private void Next(object sender, RoutedEventArgs e)
        {
            #region 1 PAGE BUTTON HIDDEN
            FolderButton.Visibility = Visibility.Hidden;
            ScheduleButton.Visibility = Visibility.Hidden;
            MemoButton.Visibility = Visibility.Hidden;
            MapButton.Visibility = Visibility.Hidden;
            #endregion

            #region 2 PAGE BUTTON VISIBLE
            MusicButton.Visibility = Visibility.Visible;
            LotteryButton.Visibility = Visibility.Visible;
            AdminButton.Visibility = Visibility.Visible;
            LogoutButton.Visibility = Visibility.Visible;
            #endregion

            //페이지 구분
            PageCountText.Text = "2";
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            #region 1 PAGE BUTTON VISIBLE
            FolderButton.Visibility = Visibility.Visible;
            ScheduleButton.Visibility = Visibility.Visible;
            MemoButton.Visibility = Visibility.Visible;
            MapButton.Visibility = Visibility.Visible;
            #endregion

            #region 2 PAGE BUTTON HIDDEN
            MusicButton.Visibility = Visibility.Hidden;
            LotteryButton.Visibility = Visibility.Hidden;
            AdminButton.Visibility = Visibility.Hidden;
            LogoutButton.Visibility = Visibility.Hidden;
            #endregion

            //페이지 구분
            PageCountText.Text = "1";
        }
    }
}
