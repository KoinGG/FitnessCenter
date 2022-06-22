using FitnessCenter.Sourses;
using FitnessCenter.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitnessCenter.ViewModels
{
    public class ScheduleWindowVM : BaseVM
    {
        private RelayCommand _cancel;
        private RelayCommand _scheduleAccept;

        private ObservableCollection<Training> _trainings;
        private Training _training;
        private Training _selectedTraining;

        private Schedule _schedule = new Schedule();

        public Schedule Schedule
        {
            get => _schedule;
            set
            {
                _schedule = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Training> Trainings
        {
            get => _trainings;
            set => _trainings = value;
        }
        public Training Training
        {
            get => _training;
            set 
            {
                _training = value;
                OnPropertyChanged();
            }
        }
        public Training SelectedTraining
        {
            get => _selectedTraining;
            set
            {
                _selectedTraining = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand ScheduleAccept
        {
            get
            {
                return _scheduleAccept ??
                    (_scheduleAccept = new RelayCommand((x) =>
                    {


                        Helper.GetContext().Schedules.Add(Schedule);
                        Helper.GetContext().SaveChanges();

                        AdminWindow adminWindow = new AdminWindow();
                        App.Current.Windows[0].Close();
                        adminWindow.Show();
                    }));
            }
        }

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
