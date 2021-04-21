namespace My_Information.Login
{
    public class LoginBase
    {
        /// <summary>
        /// 아이디
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 패스워드
        /// </summary>
        public string PASSWORD { get; set; }
        /// <summary>
        /// 이름
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 허용 IP주소
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 권한
        /// </summary>
        public string authorization { get; set; }
    }
}
