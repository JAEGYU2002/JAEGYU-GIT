using System.Windows;
using System.IO;
using System.Net;
using System.Net.Sockets;
using My_Information.View;

namespace My_Information.Login
{
    public class LoginViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int count = 0;
        public static LoginDals LD = new LoginDals();
        public RelayCommand JoinButton { get; set; }
        public RelayCommand LoginButton { get; set; }
        public string Textbox1 { get; set; }
        public string Textbox2 { get; set; }
        public string IpAddress { get; set; }

        public LoginViewModel()
        {
            JoinButton = new RelayCommand(JoinClick);
            LoginButton = new RelayCommand(LoginClick);
            IpAddress = "접속 IP : " + Client_IP;
        }

        public void JoinClick(object obj)
        {
            JoinView JV = new JoinView();
            JV.ShowDialog();
        }

        public void LoginClick(object parameter)
        {
            try
            {
                string ID = Textbox1.ToString();
                string PASSWORD = Textbox2.ToString();

                if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(PASSWORD))
                {
                    MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                bool result = LD.usersel(ID, PASSWORD);

                if (result)
                {
                    string id = LoginViewModel.LD.user1.ID.ToString();
                    StreamWriter writer;
                    writer = File.AppendText("LoginLog.txt");
                    writer.WriteLine($"[{id}] LoginTime : " + System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    writer.Close();

                    MainWindow MW = new MainWindow();
                    Application.Current.MainWindow.Close();
                    MW.ShowDialog();
                }
                else
                {
                    string Ip_check = Client_IP;

                    if (Ip_check != "192.168.0.10")
                    {
                        MessageBox.Show("접속이 허용되지 않은 IP입니다.", "보안 경고", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }

                    if (count >= 2)
                    {
                        MessageBox.Show("의심스러운 로그인이 차단되었습니다.", "보안 경고", MessageBoxButton.OK, MessageBoxImage.Stop);
                        Application.Current.MainWindow.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("아이디와 비밀번호를 확인해주세요", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                        count++;
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("빈 항목이 있습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catch (System.Exception)
            {
                MessageBox.Show("알 수 없는 오류가 발생했습니다.", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                log.Error("LoginClick에서 오류 발생");
                return;
            }
        }

        public static string Client_IP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = host.AddressList[i].ToString();
                    }
                }
                return ClientIP;
            }
        }
    }
}
