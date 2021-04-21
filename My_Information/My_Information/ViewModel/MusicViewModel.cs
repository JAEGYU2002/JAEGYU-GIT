using System;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media;

namespace My_Information.ViewModel
{
    public class MusicViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MediaPlayer media = new MediaPlayer();

        private string _mp3Name;
        public string Mp3Name
        {
            get { return _mp3Name; }
            set { SetProperty(ref _mp3Name, value); }
        }
        public RelayCommand Mp3Open { get; set; }
        public RelayCommand Mp3Play { get; set; }
        public RelayCommand Mp3Stop { get; set; }
        public RelayCommand Mp3Pause { get; set; }

        public MusicViewModel()
        {
            Mp3Open = new RelayCommand(OpenClick);
            Mp3Play = new RelayCommand(PlayClick);
            Mp3Stop = new RelayCommand(StopClick);
            Mp3Pause = new RelayCommand(PauseClick);
        }

        private void OpenClick(object obj)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                if (file.ShowDialog() == true)
                {
                    Mp3Name = file.FileName;
                    media.Open(new Uri(file.FileName));
                }
            }
            catch (Exception)
            {
                log.Error("OpenClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void PlayClick(object obj)
        {
            try
            {
                media.Play();
            }
            catch (Exception)
            {
                log.Error("PlayClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void StopClick(object obj)
        {
            try
            {
                media.Pause();
            }
            catch (Exception)
            {
                log.Error("StopClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void PauseClick(object obj)
        {
            try
            {
                media.Stop();
            }
            catch (Exception)
            {
                log.Error("PauseClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
