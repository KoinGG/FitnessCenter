using FitnessCenter.Sourses;
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
        private RelayCommand _schedule;
        private User user;

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

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public AdminWindowVM()
        {
            User = Helper.GetContext().Users.FirstOrDefault(x => x.IdUser == AuthorizationVM.UserID);
        }
    }
}
