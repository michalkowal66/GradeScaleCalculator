using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GradeScaleCalculatorApp.Models;
using GradeScaleCalculatorApp.Services;
using System.Collections.ObjectModel;

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
            GradingScales = GradingScalesFactoryService.GetGradingScales();

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
