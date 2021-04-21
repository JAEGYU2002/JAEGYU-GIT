namespace My_Information.KakaoMap
{
    public class KaKaoBase
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        internal KaKaoBase(string name, double lat, double lng)
        {
            Name = name;
            Lat = lat;
            Lng = lng;
        }

        public KaKaoBase()
        {
        }

        public override string ToString() { return Name; }
    }
}
