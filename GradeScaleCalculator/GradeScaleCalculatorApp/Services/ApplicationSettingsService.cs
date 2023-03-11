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
            if (!File.Exists(gradingScalesSettingsFile)) CreateDefaultGradingScalesSettingsFile(gradingScalesSettingsFile);

            return gradingScalesSettingsFile;
        }

        private static void CreateDefaultGradingScalesSettingsFile(string settingsFilePath)
        {
            string defaultSettingsContent = ApplicationResourcesService.GetEmbeddedResourceContent(GradingScalesSettingsFilename);

            using (FileStream settingsFile = File.Create(settingsFilePath))
            {
                byte[] defaultSettingsContentBytes = new UTF8Encoding(true).GetBytes(defaultSettingsContent);
                settingsFile.Write(defaultSettingsContentBytes, 0, defaultSettingsContentBytes.Length);
            }
        }

        public static string GetGradingScalesSettingsFileContent()
        {
            string gradingScalesSettingsFile = GetGradingScalesSettingsFile();

            string settingsFileContent = File.ReadAllText(gradingScalesSettingsFile);

            return settingsFileContent;
        }

        public static void WriteGradingScalesToSettings(IEnumerable<GradingScale> gradingScales)
        {
            string settingsContent = GradingScalesSerializer.SerializeScales(gradingScales);
            string settingsFile = GetGradingScalesSettingsFile();

            File.WriteAllText(settingsFile, settingsContent);
        }
    }
}
