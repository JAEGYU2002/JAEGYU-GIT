using System;
using System.Windows;
using MySql.Data.MySqlClient;
using My_Information.Base;
using System.Diagnostics;
using System.IO;

namespace My_Information.Dals
{
    public class memoDals
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        StreamWriter writer;
        public bool Insert(string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"INSERT INTO memo (ID) Values('{id}')";

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
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"memoDals(Insert) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }

        public MemoBase Select(string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MemoBase result = new MemoBase();

            try
            {
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"SELECT * FROM memo WHERE id = '{id}'";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        MemoBase corporation = new MemoBase
                        {
                            memoText = rdr["memoText"].ToString()
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
            }
            stopwatch.Stop();
            writer = File.AppendText("SqlTime.txt");
            writer.WriteLine($"memoDals(Select) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return result;
        }

        public bool Update(MemoBase model, string id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                MemoBase memoBase = model as MemoBase;
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"UPDATE memo SET " +
                              $"memoText = '{memoBase.memoText}' " +
                              $"WHERE id = '{id}'";

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
            writer.WriteLine($"memoDals(Update) time : " + stopwatch.ElapsedMilliseconds + "ms");
            writer.Close();

            return true;
        }
    }
}
