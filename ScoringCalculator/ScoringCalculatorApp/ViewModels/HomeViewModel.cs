using CommunityToolkit.Mvvm.ComponentModel;
using ScoringCalculator.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace ScoringCalculator.ViewModels
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
                    CalculatedScoring = Scoring.FromScale(value, MaxPointsValue);
                }
            }
        }

        public Scoring CalculatedScoring
        {
            get => _calculatedScoring;
            set => SetProperty(ref _calculatedScoring, value);
        }

        public string MaxPoints
        {
            get => MaxPointsValue.ToString();
            set
            {
                if (!int.TryParse(value, out int parsedInput)) parsedInput = 0;
                if (SetProperty(ref _maxPoints, parsedInput))
                {
                    CalculatedScoring = Scoring.FromScale(CurrentGradingScale, parsedInput);
                }
            }
        }

        public int MaxPointsValue
        {
            get => _maxPoints;
        }

        private void RefreshCurrentGradingScale(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems.Contains(CurrentGradingScale)) CurrentGradingScale = GradingScales.First();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (CurrentGradingScale == e.OldItems.Cast<GradingScale>().First())
                    {
                        CurrentGradingScale = e.NewItems.Cast<GradingScale>().First();
                    }
                    break;
                default:
                    break;
            }
        }

        public HomeViewModel(ObservableCollection<GradingScale> gradingScales)
        {
            GradingScales = gradingScales;
            CurrentGradingScale = GradingScales.First();

            GradingScales.CollectionChanged += RefreshCurrentGradingScale;
        }
    }
}
