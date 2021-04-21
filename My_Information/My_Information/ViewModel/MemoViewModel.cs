using System;
using System.IO;
using System.Windows;
using My_Information.Base;
using My_Information.Dals;
using System.Windows.Forms;
using My_Information.Login;

namespace My_Information.ViewModel
{
    public class MemoViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string id = LoginViewModel.LD.user1.ID.ToString();
        memoDals MD = new memoDals();
        public string memoText { get; set; }
        public RelayCommand SaveButton { get; set; }
        public RelayCommand SaveTextMenu { get; set; }
        public RelayCommand ManualMenu { get; set; }

        private MemoBase _memoParameter;
        public MemoBase MemoParameter
        {
            get { return _memoParameter; }
            set { SetProperty(ref _memoParameter, value); }
        }
        public MemoViewModel()
        {
            SaveButton = new RelayCommand(SaveClick);
            SaveTextMenu = new RelayCommand(SaveTextMenuClick);
            ManualMenu = new RelayCommand(ManualMenuClick);
            MemoParameter = MD.Select(id);
        }

        private void SaveClick(object parameter)
        {
            bool UpdateResult = MD.Update(MemoParameter, id);

            if (UpdateResult == true)
            {
                System.Windows.MessageBox.Show("수정되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (UpdateResult == false)
            {
                System.Windows.MessageBox.Show("수정할 수 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                log.Error("SaveClick에서 오류 발생");
                System.Windows.MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveTextMenuClick(object obj)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "텍스트로 저장";
            saveFileDialog.Filter = "텍스트 문서(*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, MD.Select(id).memoText.ToString());
                }
                catch (Exception)
                {
                    log.Error("SaveTextMenuClick에서 오류 발생");
                    System.Windows.MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                System.Windows.MessageBox.Show("저장 완료", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void ManualMenuClick(object obj)
        {
            System.Windows.MessageBox.Show("save : 텍스트를 DB에 저장\nsave to txt : 경로를 지정해 txt파일 형식으로 저장\nexit : memo 종료", "설명서");
        }
    }
}
