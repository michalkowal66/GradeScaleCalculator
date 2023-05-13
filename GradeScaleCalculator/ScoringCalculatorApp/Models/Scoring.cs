using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoringCalculator.Models
{
    public class Scoring : ObservableObject
    {
        private GradeRange _aGrade;

        private GradeRange _bGrade;

        private GradeRange _cGrade;

        private GradeRange _dGrade;

        private GradeRange _eGrade;

        private GradeRange _fGrade;

        private const double _percent = 0.01;

        public GradeRange AGrade
        {
            get => _aGrade;
            set => SetProperty(ref _aGrade, value);
        }

        public GradeRange BGrade
        {
            get => _bGrade;
            set => SetProperty(ref _bGrade, value);
        }

        public GradeRange CGrade
        {
            get => _cGrade;
            set => SetProperty(ref _cGrade, value);
        }

        public GradeRange DGrade
        {
            get => _dGrade;
            set => SetProperty(ref _dGrade, value);
        }

        public GradeRange EGrade
        {
            get => _eGrade;
            set => SetProperty(ref _eGrade, value);
        }

        public GradeRange FGrade
        {
            get => _fGrade;
            set => SetProperty(ref _fGrade, value);
        }

        public Scoring(GradeRange aGrade, GradeRange bGrade, GradeRange cGrade, GradeRange dGrade, GradeRange eGrade, GradeRange fGrade)
        {
            AGrade = aGrade;
            BGrade = bGrade;
            CGrade = cGrade;
            DGrade = dGrade;
            EGrade = eGrade;
            FGrade = fGrade;
        }

        public static Scoring FromScale(GradingScale gradingScale, int maxPoints)
        {
            GradeRange aGrade = new GradeRange(
                (double)gradingScale.AGrade.GradeMinValue * _percent * maxPoints,
                (double)gradingScale.AGrade.GradeMaxValue * _percent * maxPoints
            );

            GradeRange bGrade = new GradeRange(
                (double)gradingScale.BGrade.GradeMinValue * _percent * maxPoints,
                (double)gradingScale.BGrade.GradeMaxValue * _percent * maxPoints
            );

            GradeRange cGrade = new GradeRange(
                (double)gradingScale.CGrade.GradeMinValue * _percent * maxPoints, 
                (double)gradingScale.CGrade.GradeMaxValue * _percent * maxPoints
            );

            GradeRange dGrade = new GradeRange(
                (double)gradingScale.DGrade.GradeMinValue * _percent * maxPoints,
                (double)gradingScale.DGrade.GradeMaxValue * _percent * maxPoints
            );

            GradeRange eGrade = new GradeRange(
                (double)gradingScale.EGrade.GradeMinValue * _percent * maxPoints,
                (double)gradingScale.EGrade.GradeMaxValue * _percent * maxPoints
            );

            GradeRange fGrade = new GradeRange(
                (double)gradingScale.FGrade.GradeMinValue * _percent * maxPoints,
                (double)gradingScale.FGrade.GradeMaxValue * _percent * maxPoints
            );

            Scoring scoring = new(aGrade, bGrade, cGrade, dGrade, eGrade, fGrade);

            return scoring;
        }
    }
}
