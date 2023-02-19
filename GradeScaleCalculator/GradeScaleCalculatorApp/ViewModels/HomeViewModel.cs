using CommunityToolkit.Mvvm.ComponentModel;
using GradeScaleCalculatorApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeScaleCalculatorApp.ViewModels
{
    public class HomeViewModel : ObservableObject
    {
        private ObservableCollection<GradingScale> _gradingScales;

        private GradingScale _currentGradingScale;

        private Scoring _calculatedScoring;

        private int _maxPoints = 100;

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
                if (SetProperty(ref _currentGradingScale, value))
                {
                    CalculatedScoring = Scoring.FromScale(value, MaxPoints);
                }
            }
        }

        public Scoring CalculatedScoring
        {
            get => _calculatedScoring;
            set => SetProperty(ref _calculatedScoring, value);
        }

        public int MaxPoints
        {
            get => _maxPoints;
            set
            {
                if (SetProperty(ref _maxPoints, value))
                {
                    CalculatedScoring = Scoring.FromScale(CurrentGradingScale, value);
                }
            }
        }

        public HomeViewModel(ObservableCollection<GradingScale> gradingScales)
        {
            GradingScales = gradingScales;
            CurrentGradingScale = GradingScales.First();
        }
    }
}
