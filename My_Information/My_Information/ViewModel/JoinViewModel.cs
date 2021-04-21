using System;
using My_Information.Dals;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace My_Information.ViewModel
{
    public class JoinViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        JoinDals JD = new JoinDals();
        public Action CloseAction { get; set; }
        public RelayCommand JoinButton { get; set; }
        public string ID { get; set; }
        public string PASSWORD { get; set; }
        public string NAME { get; set; }

        public JoinViewModel()
        {
            JoinButton = new RelayCommand(JoinClick);
        }

        public void JoinClick(object obj)
        {
            if (PASSWORD.Length < 4)
            {
                MessageBox.Show("비밀번호가 너무 짧습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            bool insertResult = JD.Insert(ID, PASSWORD, NAME, Client_IP);

            if (insertResult == true)
            {
                MessageBox.Show("추가되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);

                memoDals MD = new memoDals();
                MD.Insert(ID);

                CloseAction();
            }
            else if (insertResult == false)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                log.Error("JoinClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
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
