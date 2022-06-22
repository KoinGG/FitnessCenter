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
        private ObservableCollection<TrainingType> _trainingTypes;
        private TrainingType _trainingType;
        private TrainingType selectedTrainingType;
        private Training _training = new Training();

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
            get
            {
                return _addTrainingAccept ??
                    (_addTrainingAccept = new RelayCommand((x) =>
                    {


                        Helper.GetContext().Trainings.Add(Training);
                        Helper.GetContext().SaveChanges();

                        AdminWindow adminWindow = new AdminWindow();
                        App.Current.Windows[0].Close();
                        adminWindow.Show();
                    }));
            }
        }

        public ObservableCollection<TrainingType> TrainingTypes
        {
            get => _trainingTypes;
            set => _trainingTypes = value;
        }
        public TrainingType Coach
        {
            get => _trainingType;
            set
            {
                _trainingType = value;
                OnPropertyChanged();
            }
        }

        public TrainingType SelectedCoach
        {
            get { return selectedTrainingType; }
            set 
            { 
                selectedTrainingType = value;
                OnPropertyChanged();
            }
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

        public AddTrainingWindowVM()
        {
            TrainingTypes = new ObservableCollection<TrainingType>(Helper.GetContext().TrainingTypes);
        }
    }
}
