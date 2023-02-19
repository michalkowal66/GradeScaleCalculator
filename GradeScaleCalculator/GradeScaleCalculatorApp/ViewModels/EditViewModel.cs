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

            ModifyGradingScaleCommand = new RelayCommand<GradingScale>(ModifyGradingScale);
            AddGradingScaleCommand = new RelayCommand<GradingScale>(AddGradingScale);
        }

        public RelayCommand<GradingScale> ModifyGradingScaleCommand { get; }

        private void ModifyGradingScale(GradingScale gradingScale)
        {
            GradingScales[GradingScales.IndexOf(CurrentGradingScale)] = gradingScale;

            CurrentGradingScale = gradingScale;
        }


        public RelayCommand<GradingScale> AddGradingScaleCommand { get; }

        private void AddGradingScale(GradingScale gradingScale)
        {
            if (GradingScales.FirstOrDefault(s => s.Name == gradingScale.Name) != null)
            {
                ModifyGradingScaleCommand.Execute(gradingScale);
                return;
            }

            GradingScales.Add(gradingScale);
            CurrentGradingScale = gradingScale;
        }
    }
}
