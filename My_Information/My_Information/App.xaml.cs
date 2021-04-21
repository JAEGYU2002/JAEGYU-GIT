using System;
using System.IO;
using System.Windows;

namespace My_Information
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string sqlConn { get; set; }
        App()
        {            
            try
            {
                StreamReader SR = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "sqlConn.config");

                string line;

                string result = "";
                while ((line = SR.ReadLine()) != null)
                {
                    result += line;
                }

                sqlConn = result;
                SR.Close();

                Login.LoginView LoginView = new Login.LoginView();
                LoginView.ShowDialog();
            }
            catch (Exception)
            {
                log.Error("usersel에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
