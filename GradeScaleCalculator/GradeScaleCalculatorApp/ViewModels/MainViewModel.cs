using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GradeScaleCalculatorApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ObservableObject _currentViewModel;

        public HomeViewModel HomeViewModel { get; } = new();

        public EditViewModel EditViewModel { get; } = new();

        public InfoViewModel InfoViewModel { get; } = new();

        public ObservableObject CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public MainViewModel()
        {
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
