using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using MySql.Data.MySqlClient;
using My_Information.ViewModel;
using My_Information.Login;

namespace My_Information.View
{
    /// <summary>
    /// UserManagementView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserManagementView : Window
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public UserManagementView()
        {
            InitializeComponent();
            this.DataContext = new UserManagementViewModel();
            PlaceSelect();
        }

        public void PlaceSelect()
        {
            string _id;
            string _name;
            string _ip;

            using (MySqlConnection connection = new MySqlConnection(App.sqlConn))
            {
                try
                {
                    List<LoginBase> items = new List<LoginBase>();
                    connection.Open();
                    string query = $"SELECT * FROM login";

                    MySqlCommand conn = new MySqlCommand(query, connection);
                    MySqlDataReader rdr = conn.ExecuteReader();

                    while (rdr.Read())
                    {
                        _id = rdr.GetString("ID");
                        _name = rdr.GetString("NAME");
                        _ip = rdr.GetString("IP");
                        items.Add(new LoginBase() { ID = $"{_id}", NAME = $"{_name}", IP = $"{_ip}" });
                    }
                    myListView.ItemsSource = items;
                    connection.Close();
                }
                catch (Exception)
                {
                    log.Error("usersel에서 오류 발생");
                    MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
