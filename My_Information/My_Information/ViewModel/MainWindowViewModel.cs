using System;
using System.Windows;
using My_Information.View;
using My_Information.KakaoMap;

namespace My_Information.ViewModel
{
    public class MainWindowViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region RelayCommand
        public RelayCommand infoButton { get; set; }
        public RelayCommand ScheduleButton { get; set; }
        public RelayCommand MapButton { get; set; }
        public RelayCommand MemoButton { get; set; }
        public RelayCommand MusicButton { get; set; }
        public RelayCommand LotteryButton { get; set; }
        public RelayCommand AdminButton { get; set; }
        public RelayCommand LogoutButton { get; set; }        
        #endregion

        public MainWindowViewModel()
        {
            infoButton = new RelayCommand(infoClick);
            ScheduleButton = new RelayCommand(ScheduleClike);
            MapButton = new RelayCommand(MapClick);
            MemoButton = new RelayCommand(MemoClick);
            MusicButton = new RelayCommand(MusicClick);
            LotteryButton = new RelayCommand(LotteryClick);
            AdminButton = new RelayCommand(ClientClick);
            LogoutButton = new RelayCommand(LogoutClick);            
        }

        public void infoClick(object parameter)
        {
            try
            {
                string filePath = @"C:\Users\heath\Desktop\jk.lee";
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception)
            {
                log.Error("infoClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }
        }

        public void ScheduleClike(object parameter)
        {
            ScheduleView SV = new ScheduleView();
            SV.ShowDialog();
        }

        public void MapClick(object obj)
        {
            KakaoMapView KV = new KakaoMapView();
            KV.ShowDialog();
        }

        public void MemoClick(object parameter)
        {
            MemoView MV = new MemoView();
            MV.ShowDialog();
        }

        public void MusicClick(object obj)
        {
            MusicView MV2 = new MusicView();
            MV2.ShowDialog();
        }

        public void LogoutClick(object parameter)
        {
            try
            {
                MessageBox.Show("로그아웃 되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                System.Windows.Forms.Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception)
            {
                log.Error("LogoutClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return;
            }
        }

        private void LotteryClick(object obj)
        {
            LotteryView LV = new LotteryView();
            LV.ShowDialog();
        }

        private void ClientClick(object obj)
        {
            AdminView AV = new AdminView();
            AV.ShowDialog();
        }
    }
}
