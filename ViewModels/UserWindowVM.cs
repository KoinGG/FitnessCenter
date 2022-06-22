using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FitnessCenter;
using FitnessCenter.Sourses;
using FitnessCenter.ViewModels;
using FitnessCenter.Views;

namespace FitnessCenter.ViewModels
{
    public class UserWindowVM : BaseVM
    {
        private RelayCommand _logOut;
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
            //get { return _user; }
            get => _user;
            set 
            { 
                _user = value; 
                OnPropertyChanged();
            }
        }

        public UserWindowVM()
        {
            User = Helper.GetContext().Users.FirstOrDefault(x => x.IdUser == AuthorizationVM.UserID);
        }
    }
}
