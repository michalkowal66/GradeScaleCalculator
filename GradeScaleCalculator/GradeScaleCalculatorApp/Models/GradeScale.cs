using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Globalization;

namespace GradeScaleCalculatorApp.Models
{
    public class GradeScale : ObservableObject
    {
        private double _gradeMin;
        private double _gradeMax;

        public string GradeMin
        {
            get => GradeMinValue.ToString();
            set
            {
                if (!double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedInput)) parsedInput = 0.0;
                parsedInput = parsedInput > 100 ? 100 : parsedInput;
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
                parsedInput = parsedInput > 100 ? 100 : parsedInput;
                SetProperty(ref _gradeMax, parsedInput);
            }
        }

        public double GradeMaxValue
        {
            get => Math.Round(_gradeMax);
        }

        public GradeScale(double gradeMin, double gradeMax)
        {
            GradeMin = gradeMin.ToString().Replace(',', '.');
            GradeMax = gradeMax.ToString().Replace(',', '.');
        }

        public GradeScale Clone()
        {
            return new GradeScale(_gradeMin, _gradeMax);
        }
    }
}
