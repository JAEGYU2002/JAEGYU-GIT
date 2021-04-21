using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace My_Information.Dals
{
    public class JoinDals
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool Insert(string id, string password, string name, string ip)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"INSERT INTO login (ID, PASSWORD, NAME, IP) Values('{id}', '{password}', '{name}', '{ip}')";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("JoinDals에서 오류 발생");
                return false;
            }
            stopwatch.Stop();
            StreamWriter writer;
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"JoinDals(Insert) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }
    }
}
