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
    public class AuthorizationVM : BaseVM
    {
        private RelayCommand _loginCommand;
        private RelayCommand _signUpCommand;
        private string _login;
        public static int UserID;
        public string Login 
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SignUpCommand
        {
            get => new(x =>
            {
                RegistrationWindow RrgistrationWindow = new RegistrationWindow();
                Application.Current.Windows[0].Close();
                RrgistrationWindow.Show();
            });
        }
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ??
                    (_loginCommand = new RelayCommand((x) =>
                    {
                        var password = (x as PasswordBox).Password;
                        var user = Helper.GetContext().Users.SingleOrDefault(x => x.Login == Login && x.Password == password);                        
                        if (user != null)
                        {
                            UserID = user.IdUser;
                            if (user.IdRoleType == 1) // user
                            {
                                UserWindow userWindow = new UserWindow();
                                Application.Current.MainWindow.Close();
                                userWindow.Show();
                            }
                            else if (user.IdRoleType == 2) // admin
                            {
                                AdminWindow adminWindow = new AdminWindow();
                                Application.Current.MainWindow.Close();
                                adminWindow.Show();
                            }
                            else if (user.IdRoleType == 3) // coach
                            {
                                CoachWindow coachWindow = new CoachWindow();
                                Application.Current.MainWindow.Close();
                                coachWindow.Show();
                            }
                        }
                    }/*,*/ 
                    //(x) =>
                    //{
                    //    var passwordBox = x as PasswordBox;
                    //    if (passwordBox == null)
                    //    {
                    //        return false;
                    //    }

                        //string password = passwordBox.Password;
                        //return (string.IsNullOrEmpty(_login) == false && string.IsNullOrEmpty(password) == false);
                    /*}*/));
            }
        }
    }
}
