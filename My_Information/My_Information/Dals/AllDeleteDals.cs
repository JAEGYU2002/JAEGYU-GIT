using System;
using System.Windows;    
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace My_Information.Dals
{
    public class AllDeleteDals
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool Delete()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] table = { "bookmark_place", "memo", "schedule" };

            for (int i = 0; i < table.Length; i++)
            {
                try
                {
                    string query = string.Empty;

                    using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                    {
                        conn.Open();
                        query = $"TRUNCATE TABLE {table[i]}";

                        MySqlCommand command = new MySqlCommand(query, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception)
                {
                    log.Error("Delete에서 오류 발생");
                    MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "SQL 오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                    return false;
                }
            }
            stopwatch.Stop();
            StreamWriter writer;
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"AllDeleteDals(Delete) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }
    }
}
