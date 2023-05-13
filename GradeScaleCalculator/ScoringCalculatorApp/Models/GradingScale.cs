using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoringCalculator.Models
{
    public class GradingScale : ObservableObject
    {
        private string _name;

        private GradeScale _aGrade;

        private GradeScale _bGrade;

        private GradeScale _cGrade;

        private GradeScale _dGrade;

        private GradeScale _eGrade;

        private GradeScale _fGrade;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public GradeScale AGrade
        {
            get => _aGrade;
            set => SetProperty(ref _aGrade, value);
        }

        public GradeScale BGrade
        {
            get => _bGrade;
            set => SetProperty(ref _bGrade, value);
        }

        public GradeScale CGrade
        {
            get => _cGrade;
            set => SetProperty(ref _cGrade, value);
        }

        public GradeScale DGrade
        {
            get => _dGrade;
            set => SetProperty(ref _dGrade, value);
        }

        public GradeScale EGrade
        {
            get => _eGrade;
            set => SetProperty(ref _eGrade, value);
        }

        public GradeScale FGrade
        {
            get => _fGrade;
            set => SetProperty(ref _fGrade, value);
        }

        public GradingScale(string name, GradeScale aGrade, GradeScale bGrade, GradeScale cGrade, GradeScale dGrade, GradeScale eGrade, GradeScale fGrade)
        {
            Name = name;
            AGrade = aGrade;
            BGrade = bGrade;
            CGrade = cGrade;
            DGrade = dGrade;
            EGrade = eGrade;
            FGrade = fGrade;
        }

        public GradingScale()
        {
            Name = Statics.DefaultGradingScaleName;
            AGrade = new GradeScale(95, 100);
            BGrade = new GradeScale(85, 95);
            CGrade = new GradeScale(70, 85);
            DGrade = new GradeScale(55, 70);
            EGrade = new GradeScale(40, 55);
            FGrade = new GradeScale(0, 40);
        }

        public GradingScale Clone()
        {
            return new GradingScale(
                Name.ToString(),
                AGrade.Clone(),
                BGrade.Clone(),
                CGrade.Clone(),
                DGrade.Clone(),
                EGrade.Clone(),
                FGrade.Clone()
            );
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
