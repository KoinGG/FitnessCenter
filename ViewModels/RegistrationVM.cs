using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FitnessCenter;
using FitnessCenter.Sourses;
using FitnessCenter.ViewModels;
using FitnessCenter.Views;

namespace FitnessCenter.ViewModels
{
    public class RegistrationVM : BaseVM
    {
        private RelayCommand _registrationAccept;
        private RelayCommand _signIn;

        private User _user = new User();

        public User User
        {
            get { return _user; }
            set 
            { 
                _user = value; 
                OnPropertyChanged();
            }
        }


        public RelayCommand SignIn
        {
            get => new(x =>
            {
                    AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                    App.Current.Windows[0].Close();
                    authorizationWindow.Show();              
            });
        }

        public RelayCommand RegistrationAccept
        {
            get
            {
                return _registrationAccept ??
                    (_registrationAccept = new RelayCommand((x) =>
                    {
                        if(User.Name != null && User.Surname != null && User.Patronymic != null && User.Login != null 
                        && User.Password != null && User.PhoneNumber != null && User.Email != null)
                        {
                            User.IdRoleType = 1;

                            Helper.GetContext().Users.Add(User);
                            Helper.GetContext().SaveChanges();

                            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                            App.Current.Windows[0].Close();
                            authorizationWindow.Show();
                        }
                    }));
            }
        }
    }
}
