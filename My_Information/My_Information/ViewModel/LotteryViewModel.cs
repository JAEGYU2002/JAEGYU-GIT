using System;
using System.Windows;

namespace My_Information.ViewModel
{
    public class LotteryViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RelayCommand LotteryButton { get; set; }

        #region num 0~6
        private string _num0;
        public string num0
        {
            get { return _num0; }
            set { SetProperty(ref _num0, value); }
        }

        private string _num1;
        public string num1
        {
            get { return _num1; }
            set { SetProperty(ref _num1, value); }
        }

        private string _num2;
        public string num2
        {
            get { return _num2; }
            set { SetProperty(ref _num2, value); }
        }

        private string _num3;
        public string num3
        {
            get { return _num3; }
            set { SetProperty(ref _num3, value); }
        }

        private string _num4;
        public string num4
        {
            get { return _num4; }
            set { SetProperty(ref _num4, value); }
        }

        private string _num5;
        public string num5
        {
            get { return _num5; }
            set { SetProperty(ref _num5, value); }
        }

        private string _num6;
        public string num6
        {
            get { return _num6; }
            set { SetProperty(ref _num6, value); }
        }
        #endregion  

        public LotteryViewModel()
        {
            try
            {
                LotteryButton = new RelayCommand(LotteryClick);

                #region num 0~6
                num0 = "0";
                num1 = "0";
                num2 = "0";
                num3 = "0";
                num4 = "0";
                num5 = "0";
                num6 = "0";
                #endregion
            }
            catch (Exception)
            {
                log.Error("LotteryViewModel() 생성자에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        public void LotteryClick(object obj)
        {
            try
            {
                #region Random
                Random randomNumber = new Random();
                int randomNumberResult = randomNumber.Next(1, 5);

                num0 = randomNumberResult.ToString();

                Random randomNumber1 = new Random();
                int randomNumberResult1 = randomNumber.Next(0, 9);

                num1 = randomNumberResult1.ToString();

                Random randomNumber2 = new Random();
                int randomNumberResult2 = randomNumber.Next(0, 9);

                num2 = randomNumberResult2.ToString();

                Random randomNumber3 = new Random();
                int randomNumberResult3 = randomNumber.Next(0, 9);

                num3 = randomNumberResult3.ToString();

                Random randomNumber4 = new Random();
                int randomNumberResult4 = randomNumber.Next(0, 9);

                num4 = randomNumberResult4.ToString();

                Random randomNumber5 = new Random();
                int randomNumberResult5 = randomNumber.Next(0, 9);

                num5 = randomNumberResult5.ToString();

                Random randomNumber6 = new Random();
                int randomNumberResult6 = randomNumber.Next(0, 9);

                num6 = randomNumberResult6.ToString();
                #endregion
            }
            catch (Exception)
            {
                log.Error("LotteryClick에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
