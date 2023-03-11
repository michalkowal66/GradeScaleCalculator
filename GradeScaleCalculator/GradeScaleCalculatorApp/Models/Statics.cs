using System;

namespace GradeScaleCalculatorApp.Models
{
    public static class Statics
    {
        public static readonly string AppName;
        public static string AppSettingsRootFolder;
        public static readonly string GradingScalesSettingsFilename;

        static Statics()
        {
            AppName = "KalkulatorPunktacji";
            AppSettingsRootFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            GradingScalesSettingsFilename = "punktacje.json";
        }
    }
}
