using static GradeScaleCalculatorApp.Models.Statics;
using System.IO;

namespace GradeScaleCalculatorApp.Services
{
    internal static class ApplicationPathsService
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
