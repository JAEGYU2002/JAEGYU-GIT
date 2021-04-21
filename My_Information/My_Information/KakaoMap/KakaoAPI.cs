using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace My_Information.KakaoMap
{
    static class KakaoAPI
    {
        internal static List<KaKaoBase> Search(string query)
        {
            List<KaKaoBase> mls = new List<KaKaoBase>();
            string site = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string rquery = string.Format("{0}?query={1}", site, query);
            WebRequest request = WebRequest.Create(rquery);
            string rkey = "52c05f422e54b1daeb00ef11feac0331";
            string header = "KakaoAK " + rkey;
            request.Headers.Add("Authorization", header);
            WebResponse response;
            try
            {
                response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                String json = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic dob = js.Deserialize<dynamic>(json);
                dynamic docs = dob["documents"];
                object[] buf = docs;
                int length = buf.Length;
                for (int i = 0; i < length; i++)
                {
                    string lname = docs[i]["place_name"]; double x = double.Parse(docs[i]["x"]); double y = double.Parse(docs[i]["y"]); mls.Add(new KaKaoBase(lname, y, x));
                }
                return mls;
            }
            catch (WebException)
            {
                MessageBox.Show("검색어를 입력해주세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return mls;
            }
            catch (Exception)
            {
                MessageBox.Show("오류가 발생했습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
                return mls;
            }
        }

        internal static KaKaoBase Search2(string query)
        {
            KaKaoBase mls = new KaKaoBase();
            string site = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string rquery = string.Format("{0}?query={1}", site, query);
            WebRequest request = WebRequest.Create(rquery);
            string rkey = "52c05f422e54b1daeb00ef11feac0331";
            string header = "KakaoAK " + rkey;
            request.Headers.Add("Authorization", header);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String json = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic dob = js.Deserialize<dynamic>(json);
            dynamic docs = dob["documents"];
            object[] buf = docs;
            int length = buf.Length;
            string lname = docs[0]["place_name"]; double x = double.Parse(docs[0]["x"]); double y = double.Parse(docs[0]["y"]);
            mls.Name = lname;
            mls.Lng = x;
            mls.Lat = y;
            return mls;
        }
    }
}
