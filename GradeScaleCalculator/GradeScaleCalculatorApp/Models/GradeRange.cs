using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Globalization;

namespace GradeScaleCalculatorApp.Models
{
    public class GradeRange : ObservableObject
    {
        private double _gradeMin;
        private double _gradeMax;

        private bool _isPercentageRange;

        public string GradeMin
        {
            get => GradeMinValue.ToString();
            set
            {
                if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedInput)) parsedInput = 0.0;
                if (IsPercentageRange) parsedInput = parsedInput > 100 ? 100 : parsedInput;
                SetProperty(ref _gradeMin, parsedInput);
            }
        }

        public double GradeMinValue
        {
            get => Math.Round(_gradeMin);
        }

        public string GradeMax
        {
            get => GradeMaxValue.ToString();
            set
            {
                if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedInput)) parsedInput = 0.0;
                if (IsPercentageRange) parsedInput = parsedInput > 100 ? 100 : parsedInput;
                SetProperty(ref _gradeMax, parsedInput);
            }
        }

        public double GradeMaxValue
        {
            get => Math.Round(_gradeMax);
        }

        public bool IsPercentageRange
        {
            get => _isPercentageRange;
            set => SetProperty(ref _isPercentageRange, value);
        }

        public GradeRange(double gradeMin, double gradeMax, bool isPercentageRange = false) 
        {
            GradeMin = gradeMin.ToString().Replace(',', '.');
            GradeMax = gradeMax.ToString().Replace(',', '.');
            IsPercentageRange = isPercentageRange;
        }

        public GradeRange Clone()
        {
            return new GradeRange(_gradeMin, _gradeMax, _isPercentageRange);
        }
    }
}
