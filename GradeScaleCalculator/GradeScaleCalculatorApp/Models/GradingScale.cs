﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace GradeScaleCalculatorApp.Models
{
    public class GradingScale : ObservableObject
    {
        private string _name;

        private GradeRange _aGrade;

        private GradeRange _bGrade;

        private GradeRange _cGrade;

        private GradeRange _dGrade;

        private GradeRange _eGrade;

        private GradeRange _fGrade;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

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

        public GradingScale(string name, GradeRange aGrade, GradeRange bGrade, GradeRange cGrade, GradeRange dGrade, GradeRange eGrade, GradeRange fGrade)
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
            Name = "Domyślna skala";
            AGrade = new GradeRange(95, 100);
            BGrade = new GradeRange(85, 95);
            CGrade = new GradeRange(70, 85);
            DGrade = new GradeRange(55, 70);
            EGrade = new GradeRange(40, 55);
            FGrade = new GradeRange(0, 40);
        }

        public GradingScale Clone()
        {
            return new GradingScale(
                Name.ToString(),
                new GradeRange(AGrade.GradeMin, AGrade.GradeMax),
                new GradeRange(BGrade.GradeMin, BGrade.GradeMax),
                new GradeRange(CGrade.GradeMin, CGrade.GradeMax),
                new GradeRange(DGrade.GradeMin, DGrade.GradeMax),
                new GradeRange(EGrade.GradeMin, EGrade.GradeMax),
                new GradeRange(FGrade.GradeMin, FGrade.GradeMax)
            );
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
