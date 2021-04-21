using System;
using System.Windows;
using MySql.Data.MySqlClient;
using My_Information.Base;
using System.Diagnostics;
using System.IO;

namespace My_Information.Dals
{
    public class ScheuleDals
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);  
        StreamWriter writer;
        public ScheduleBase Select(string id, string day)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ScheduleBase result = new ScheduleBase();
            try
            {
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"SELECT * FROM schedule WHERE id = '{id}' AND DATE(DAY) = '{day}'";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        ScheduleBase corporation = new ScheduleBase
                        {
                            day = rdr["day"].ToString(),
                            title = rdr["title"].ToString(),
                            memo = rdr["memo"].ToString()
                        };

                        result = corporation;
                    };
                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("Select에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return null;
            }
            stopwatch.Stop();
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"ScheuleDals(Select) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return result;
        }

        public bool Insert(ScheduleBase model, string id, string day)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                ScheduleBase ScheduleBase = model as ScheduleBase;
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"INSERT INTO schedule (id, day, title, memo) Values('{id}', '{day}', '{ScheduleBase.title}', '{ScheduleBase.memo}')";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("Insert에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            stopwatch.Stop();
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"ScheuleDals(Insert) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }

        public bool Update(ScheduleBase model, string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            try
            {
                ScheduleBase scheduleBase = model as ScheduleBase;
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"UPDATE schedule SET " +
                              $"title = '{scheduleBase.title}', " +
                              $"memo = '{scheduleBase.memo}' " +
                              $"WHERE day = '{scheduleBase.day}' AND id = '{id}'";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("Update에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            stopwatch.Stop();
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"ScheuleDals(Update) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }

        public bool Delete(ScheduleBase model, string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                ScheduleBase scheduleBase = model as ScheduleBase;
                string day = scheduleBase.day;
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"DELETE FROM schedule WHERE id = '{id}' AND DATE(DAY) = '{day}'";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                log.Error("Delete에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            stopwatch.Stop();
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"ScheuleDals(Delete) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }
    }
}
