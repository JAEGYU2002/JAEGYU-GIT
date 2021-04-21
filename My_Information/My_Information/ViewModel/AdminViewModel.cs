using My_Information.View;
using My_Information.Dals;
using System.Windows.Forms;
using System;

namespace My_Information.ViewModel
{
    public class AdminViewModel
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);  
        public RelayCommand userButton { get; set; }
        public RelayCommand loginLogButton { get; set; }
        public RelayCommand dbResetButton { get; set; }
        public AdminViewModel()
        {
            userButton = new RelayCommand(UserClick);
            loginLogButton = new RelayCommand(loginLogClick);
            dbResetButton = new RelayCommand(dbResetClick);
            //zz
        }

        public void UserClick(object obj)
        {
            UserManagementView UV = new UserManagementView();
            UV.ShowDialog();
        }

        private void loginLogClick(object obj)
        {
            LoginLogView LV = new LoginLogView();
            LV.ShowDialog();
        }

        private void dbResetClick(object obj)
        {
            if (MessageBox.Show("유저 정보를 제외한 모든 데이터가 삭제됩니다. 진행하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = AllDeleteDals.Delete();

                if (result)
                {
                    MessageBox.Show("성공적으로 삭제되었습니다.");
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("삭제 작업을 취소합니다.");
            }
        }
    }
}
