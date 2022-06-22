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
    public class AddCoachWindowVM : BaseVM
    {
        private RelayCommand _cancel;
        private RelayCommand _addCoachAccept;
        private Coach _coach = new Coach();

        public Coach Coach
        {
            get => _coach;
            set
            {
                _coach = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand Cancel
        {
            get => new(x =>
            {
                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите отменить добавление?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    App.Current.Windows[0].Close();
                    adminWindow.Show();
                }
            });
        }
        public RelayCommand AddCoachAccept
        {
            get
            {
                return _addCoachAccept ??
                    (_addCoachAccept = new RelayCommand((x) =>
                    {
                        Helper.GetContext().Coaches.Add(Coach);
                        Helper.GetContext().SaveChanges();

                        AdminWindow adminWindow = new AdminWindow();
                        App.Current.Windows[0].Close();
                        adminWindow.Show();
                    }));
            }
        }
    }
}
