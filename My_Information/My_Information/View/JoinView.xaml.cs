using System;
using System.Windows;
using My_Information.ViewModel;

namespace My_Information.View
{
    /// <summary>
    /// JoinView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class JoinView : Window
    {
        public JoinView()
        {
            InitializeComponent();
            JoinViewModel vm = new JoinViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
