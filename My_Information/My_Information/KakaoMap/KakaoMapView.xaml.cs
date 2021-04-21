using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using My_Information.Login;

namespace My_Information.KakaoMap
{
    /// <summary>
    /// KakaoMapView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class KakaoMapView : Window
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string id = LoginViewModel.LD.user1.ID.ToString();
        public KakaoMapView()
        {
            InitializeComponent();
            PlaceSelect(id);
            FavoritePlaceID.Header = string.Format($"[{id}]의 즐겨찾는 장소");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<KaKaoBase> mls = KakaoAPI.Search(tbox_query.Text);
            lbox_locale.ItemsSource = mls;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbox_locale.SelectedIndex == -1) {
                return;
            }
            KaKaoBase ml = lbox_locale.SelectedItem as KaKaoBase;
            object[] ps = new object[] { ml.Lat, ml.Lng };
            wb.InvokeScript("setCenter", ps);
        }

        private void lbox_button_Click(object sender, RoutedEventArgs e)
        {
            string place;
            try
            {
                place = lbox_locale.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("검색 후 주소를 선택해주세요", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Insert(id, place);
            PlaceSelect(id);
        }

        public bool Insert(string palce, string id)
        {
            try
            {
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"INSERT INTO bookmark_place (id, place_name) Values('{palce}','{id}')";

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
            return true;
        }

        public void PlaceSelect(string id)
        {
            string _place;

            using (MySqlConnection connection = new MySqlConnection(App.sqlConn))
            {
                try
                {
                    List<Search> items = new List<Search>();
                    connection.Open();
                    string query = $"SELECT * FROM bookmark_place WHERE id = '{id}'";

                    MySqlCommand conn = new MySqlCommand(query, connection);
                    MySqlDataReader rdr = conn.ExecuteReader();

                    while (rdr.Read())
                    {
                        _place = rdr.GetString("place_name");

                        items.Add(new Search() { place_name = $"{_place}"});
                    }
                    place_nameList.ItemsSource = items;
                    connection.Close();
                }
                catch (Exception)
                {
                    log.Error("PlaceSelect에서 오류 발생");
                    MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void place_name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (place_nameList.SelectedIndex == -1)
            {
                return;
            }

            Search search_name = (Search)place_nameList.SelectedItem;
            string search_result = search_name.place_name;

            KaKaoBase mls = KakaoAPI.Search2(search_result);

            object[] ps = new object[] { mls.Lat, mls.Lng };
            try
            {
                wb.InvokeScript("setCenter", ps);
            }
            catch (Exception)
            {
                log.Error("place_name_SelectionChanged에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public class Search
        {
            /// <summary>
            /// 위치
            /// </summary>
            public string place_name { get; set; }
        }

        private void lbox_button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                Search search_name = (Search)place_nameList.SelectedItem;
                string search_result = search_name.place_name;
                string query = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(App.sqlConn))
                {
                    conn.Open();
                    query = $"DELETE FROM bookmark_place WHERE place_name = '{search_result}'";

                    MySqlCommand command = new MySqlCommand(query, conn);
                    int sqlResult = command.ExecuteNonQuery();
                    conn.Close();

                    if (sqlResult == 1)
                    {
                        MessageBox.Show("삭제되었습니다", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (sqlResult == 0)
                    {
                        MessageBox.Show("삭제할 수 없습니다", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
                        throw new Exception();
                    }
                    else
                    {
                        MessageBox.Show("알 수 없는 오류가 발생했습니다", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                log.Error("lbox_button_Click2에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                PlaceSelect(id);
            }
        }
    }
}
