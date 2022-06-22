using FitnessCenter.Sourses;
using FitnessCenter.Views;
using FitnessCenter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace FitnessCenter.ViewModels
{
    public class AddSubscriptionWindowVM : BaseVM
    {
        private RelayCommand _cancel;
        private RelayCommand _addSubscriptionAccept;

        private ObservableCollection<SubscriptionType> _subscriptionTypes;
        private SubscriptionType _subscriptionType;
        private SubscriptionType _selectedSubscriptionType;

        private Subscription _subscription = new Subscription();

        public ObservableCollection<SubscriptionType > SubscriptionTypes
        {
            get => _subscriptionTypes;
            set => _subscriptionTypes = value;
        }
        public SubscriptionType SubscriptionType
        {
            get => _subscriptionType;
            set
            {
                _subscriptionType = value;
                OnPropertyChanged();
            }
        }
        public SubscriptionType SelectedSubscriptionType
        {
            get => _selectedSubscriptionType;
            set
            {
                _selectedSubscriptionType = value;
                OnPropertyChanged();
            }
        }

        public Subscription Subscription
        {
            get => _subscription;
            set
            {
                _subscription = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddSubscriptionAccept
        {
            get
            {
                return _addSubscriptionAccept ??
                    (_addSubscriptionAccept = new RelayCommand((x) =>
                    {


                        Helper.GetContext().Subscriptions.Add(Subscription);
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
                MessageBoxResult dialogResult = MessageBox.Show("Вы уверены, что хотите отменить добавление?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    Application.Current.Windows[0].Close();
                    adminWindow.Show();
                }
            });
        }

        public AddSubscriptionWindowVM()
        {
            SubscriptionTypes = new ObservableCollection<SubscriptionType>(Helper.GetContext().SubscriptionTypes);
        }
    }
}
