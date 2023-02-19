using CommunityToolkit.Mvvm.ComponentModel;

namespace GradeScaleCalculatorApp.Models
{
    public class Scoring : ObservableObject
    {
        private GradeRange _aGrade;

        private GradeRange _bGrade;

        private GradeRange _cGrade;

        private GradeRange _dGrade;

        private GradeRange _eGrade;

        private GradeRange _fGrade;

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
                (double)gradingScale.AGrade.GradeMin / 100 * maxPoints,
                (double)gradingScale.AGrade.GradeMax / 100 * maxPoints
            );

            GradeRange bGrade = new GradeRange(
                (double)gradingScale.BGrade.GradeMin / 100 * maxPoints,
                (double)gradingScale.BGrade.GradeMax / 100 * maxPoints
            );

            GradeRange cGrade = new GradeRange(
                (double)gradingScale.CGrade.GradeMin / 100 * maxPoints, 
                (double)gradingScale.CGrade.GradeMax / 100 * maxPoints
            );

            GradeRange dGrade = new GradeRange(
                (double)gradingScale.DGrade.GradeMin / 100 * maxPoints,
                (double)gradingScale.DGrade.GradeMax / 100 * maxPoints
            );

            GradeRange eGrade = new GradeRange(
                (double)gradingScale.EGrade.GradeMin / 100 * maxPoints,
                (double)gradingScale.EGrade.GradeMax / 100 * maxPoints
            );

            GradeRange fGrade = new GradeRange(
                (double)gradingScale.FGrade.GradeMin / 100 * maxPoints,
                (double)gradingScale.FGrade.GradeMax / 100 * maxPoints
            );

            Scoring scoring = new(aGrade, bGrade, cGrade, dGrade, eGrade, fGrade);

            return scoring;
        }
    }
}
