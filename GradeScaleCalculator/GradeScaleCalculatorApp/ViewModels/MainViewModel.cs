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
   
    }
}
