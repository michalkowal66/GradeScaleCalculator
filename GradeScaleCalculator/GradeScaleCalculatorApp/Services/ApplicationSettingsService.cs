using static GradeScaleCalculatorApp.Models.Statics;
using System.IO;
using System.Text;
using System.Collections;
using GradeScaleCalculatorApp.Models;
using System.Collections.Generic;

namespace GradeScaleCalculatorApp.Services
{
    internal static class ApplicationSettingsService
    {
        public static string GetAppSettingsFolder()
        {
            string settingsFolder = Path.Combine(AppSettingsRootFolder, AppName);

            if (!Directory.Exists(settingsFolder)) Directory.CreateDirectory(settingsFolder);

            return settingsFolder;
        }

        public static string GetGradingScalesSettingsFile()
        {
            string appSettingsFolder = GetAppSettingsFolder();

            string gradingScalesSettingsFile = Path.Combine(appSettingsFolder, GradingScalesSettingsFilename);
            if (!File.Exists(gradingScalesSettingsFile)) File.Create(gradingScalesSettingsFile);

            return gradingScalesSettingsFile;
        }
    }
}
