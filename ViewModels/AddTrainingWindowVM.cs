using FitnessCenter.Sourses;
using FitnessCenter.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Coach> _coaches;
        private Coach _coach;

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

        public ObservableCollection<Coach> Coaches
        {
            get => _coaches;
            set => _coaches = value;
        }
        public Coach Coach
        {
            get => _coach;
            set
            {
                _coach = value;
                OnPropertyChanged();
            }
        }

        public AddTrainingWindowVM()
        {
            Coaches = new ObservableCollection<Coach>(Helper.GetContext().Coaches.Include(x => x.Name));
        }
    }
}
