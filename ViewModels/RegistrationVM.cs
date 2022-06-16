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

        public RelayCommand SignIn
        {
            get => new(x =>
            {
                    AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                    Application.Current.Windows[0].Close();
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
                        User user = new User()
                        {
                            //Name = RegistrationWindow.NameBox.Text,
                        };
                    }));
            }
        }
    }
}
