using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GradeScaleCalculatorApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeScaleCalculatorApp.ViewModels
{
    public class EditViewModel : ObservableObject
    {
        private ObservableCollection<GradingScale> _gradingScales;

        private GradingScale _currentGradingScale;

        private GradingScale _editedGradingScale;

        public ObservableCollection<GradingScale> GradingScales
        {
            get => _gradingScales;
            set => SetProperty(ref _gradingScales, value);
        }

        public GradingScale CurrentGradingScale
        {
            get => _currentGradingScale;
            set
            {
                SetProperty(ref _currentGradingScale, value);

                if (value != null) EditedGradingScale = value.Clone();
            }
        }

        public GradingScale EditedGradingScale
        {
            get => _editedGradingScale;
            set => SetProperty(ref _editedGradingScale, value);
        }

        public EditViewModel(ObservableCollection<GradingScale> gradingScales)
        {
            GradingScales = gradingScales;
            CurrentGradingScale = GradingScales.First();
        }
    }
}
