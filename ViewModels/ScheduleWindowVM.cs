using FitnessCenter.Sourses;
using FitnessCenter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessCenter.ViewModels
{
    public class ScheduleWindowVM : BaseVM
    {
        private RelayCommand _cancel;
        public RelayCommand Cancel
        {
            get => new(x =>
            {
                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите отменить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    Application.Current.Windows[0].Close();
                    adminWindow.Show();
                }
            });
        }
    }
}
