using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace GradeScaleCalculatorApp.Models
{
    public class GradeRange : ObservableObject
    {
        private double _gradeMin;
        private double _gradeMax;

        public double GradeMin
        {
            get => Math.Round(_gradeMin);
            set => SetProperty(ref _gradeMin, value);
        }

        public double GradeMax
        {
            get => Math.Round(_gradeMax);
            set => SetProperty(ref _gradeMax, value);
        }

        public GradeRange(double gradeMin, double gradeMax) 
        {
            GradeMin = gradeMin;
            GradeMax = gradeMax;
        }
    }
}
