using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace My_Information.Login
{
    public class LoginDals
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginBase user1 = new LoginBase();
        StreamWriter writer;

        public bool usersel(string id, string password)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string query = string.Empty;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"SELECT * FROM login WHERE id = '{id}' AND password = '{password}'";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        user1 = new LoginBase
                        {
                            ID = rdr["id"].ToString(),
                            PASSWORD = rdr["password"].ToString(),
                            IP = rdr["IP"].ToString(),
                            authorization = rdr["authorization"].ToString()
                        };
                    }
                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("usersel에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }

            if (id == user1.ID && password == user1.PASSWORD)
            {
                stopwatch.Stop();
                writer = File.AppendText("SqlTime.txt");
                writer.WriteLine($"LoginDals(usersel) time : " + stopwatch.ElapsedMilliseconds + "ms");
                writer.Close();
                    
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
