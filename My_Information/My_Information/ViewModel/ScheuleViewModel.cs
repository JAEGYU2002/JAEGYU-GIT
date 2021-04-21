using System;
using System.Windows;
using My_Information.Base;
using My_Information.Dals;
using My_Information.Login;

namespace My_Information.ViewModel
{
    public class ScheuleViewModel : Notifier
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string id = LoginViewModel.LD.user1.ID.ToString();
        string dayResult;
        ScheuleDals SD = new ScheuleDals();
        public RelayCommand DaySelectButton { get; set; }
        public RelayCommand EditButton { get; set; }
        public RelayCommand InsertButton { get; set; }
        public RelayCommand DeleteButton { get; set; }
        public string title { get; set; }
        public string day { get; set; }

        private string _dayBlock;
        public string dayBlock
        {
            get { return _dayBlock; }
            set { SetProperty(ref _dayBlock, value); }
        }

        private ScheduleBase _schedule;
        public ScheduleBase Schedule
        {
            get { return _schedule; }
            set { SetProperty(ref _schedule, value); }
        }
        public ScheuleViewModel()
        {
            dayBlock = "null";
            DaySelectButton = new RelayCommand(dayselect);
            EditButton = new RelayCommand(editButton);
            InsertButton = new RelayCommand(insertButton);
            DeleteButton = new RelayCommand(deleteButton);
        }

        public void dayselect(object parameter)
        {
            try
            {
                string day1 = day.ToString();
                DateTime myDate = DateTime.Parse(day1);
                dayResult = myDate.ToString("yyyy-MM-dd");

                dayBlock = dayResult;
                Schedule = SD.Select(id, dayResult);
            }
            catch (Exception)
            {
                log.Error("dayselect에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        public void editButton(object parameter)
        {
            MessageBox.Show("정말 수정하시겠습니까?", "알림", MessageBoxButton.OK, MessageBoxImage.Question);

            bool updateResult = SD.Update(Schedule, id);

            if (updateResult == true)
            {
                MessageBox.Show("수정되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (updateResult == false)
            {
                MessageBox.Show("수정할 수 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                log.Error("editButton에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void insertButton(object parameter)
        {
            bool insertResult = SD.Insert(Schedule, id,  dayResult);

            if (insertResult == true)
            {
                MessageBox.Show("추가되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (insertResult == false)
            {
                MessageBox.Show("추가할 수 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                log.Error("insertButton에서 오류 발생");
                MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void deleteButton(object obj)
        {
            if (MessageBox.Show("해당 일정을 삭제하시겠습니까?", "알림", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                bool insertResult = SD.Delete(Schedule, id);

                if (insertResult == true)
                {
                    MessageBox.Show("삭제되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                    Schedule = null;
                }
                else if (insertResult == false)
                {
                    MessageBox.Show("삭제할 수 없습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    log.Error("deleteButton에서 오류 발생");
                    MessageBox.Show("오류가 발생했습니다. 로그를 확인하세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
