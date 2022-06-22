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
    public class AdminWindowVM : BaseVM
    {
        private RelayCommand _logOut;
        private RelayCommand _addSubscription;
        private RelayCommand _addCoach;
        private RelayCommand _addTraining;
        private RelayCommand _schedule;
        private User _user;

        public RelayCommand LogOut
        {
            get => new(x =>
            {
                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                    Application.Current.Windows[0].Close();
                    authorizationWindow.Show();
                }
            });
        }

        public RelayCommand AddSubscription
        {
            get
            {
                return _addSubscription ??
                    (_addSubscription = new RelayCommand((x) =>
                    {
                        AddSubscriptionWindow addSubscriptionWindow = new AddSubscriptionWindow();
                        App.Current.Windows[0].Close();
                        addSubscriptionWindow.Show();
                    }));
            }
        }
        public RelayCommand AddCoach
        {
            get
            {
                return _addCoach ??
                    (_addCoach = new RelayCommand((x) =>
                    {
                        AddCoachWindow addCoachWindow = new AddCoachWindow();
                        App.Current.Windows[0].Close();
                        addCoachWindow.Show();
                    }));
            }
        }
        public RelayCommand AddTraining
        {
            get
            {
                return _addTraining ??
                    (_addTraining = new RelayCommand((x) =>
                    {
                        AddTrainingWindow addTrainingWindow = new AddTrainingWindow();
                        App.Current.Windows[0].Close();
                        addTrainingWindow.Show();
                    }));
            }
        }

        public RelayCommand Schedule
        {
            get
            {
                return _schedule ??
                    (_schedule = new RelayCommand((x) =>
                    {
                        ScheduleWindow scheduleWindow = new ScheduleWindow();
                        App.Current.Windows[0].Close();
                        scheduleWindow.Show();
                    }));
            }
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public AdminWindowVM()
        {
            User = Helper.GetContext().Users.FirstOrDefault(x => x.IdUser == AuthorizationVM.UserID);
        }
    }
}
