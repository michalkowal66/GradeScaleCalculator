using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GradeScaleCalculatorApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeScaleCalculatorApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableObject _currentViewModel;

        private ObservableCollection<GradingScale> _gradingScales;

        public HomeViewModel HomeViewModel { get; }

        public EditViewModel EditViewModel { get; }

        public InfoViewModel InfoViewModel { get; }

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ObservableCollection<GradingScale> GradingScales
        {
            get => _gradingScales;
            set => SetProperty(ref _gradingScales, value);
        }

        public MainViewModel()
        {
            GradingScales = new ObservableCollection<GradingScale>() 
            { 
                new GradingScale(), 
                new GradingScale() { Name = "Domyślna skala 2", AGrade = new GradeRange(90, 100), BGrade = new GradeRange(85, 90) } 
            };

            HomeViewModel = new(GradingScales);
            EditViewModel = new(GradingScales);
            InfoViewModel = new();

            CurrentViewModel = HomeViewModel;

            ChangeViewModelCommand = new RelayCommand<ObservableObject>(ChangeViewModel);
        }

        public IRelayCommand<ObservableObject> ChangeViewModelCommand { get; }

        private void ChangeViewModel(ObservableObject viewModel)
        {
            if (CurrentViewModel != viewModel) CurrentViewModel = viewModel;
        }
    }
}
