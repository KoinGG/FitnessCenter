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
    public class AddTrainingWindowVM : BaseVM
    {
        private RelayCommand _cancel;
        private RelayCommand _addTrainingAccept;

        public RelayCommand Cancel
        {
            get => new(x =>
            {
                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите отменить добавление?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    Application.Current.Windows[0].Close();
                    adminWindow.Show();
                }
            });
        }
        public RelayCommand AddTrainingAccept
        {
            get => _addTrainingAccept;
        }
    }
}
