using System.IO;
using System.Reflection;

namespace ScoringCalculator.Services
{
    internal static class ApplicationResourcesService
    {
        public static string GetEmbeddedResourceContent(string resourceFilename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"GradeScaleCalculatorApp.Resources.{resourceFilename}";

            string defaultSettingsContent = string.Empty;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                defaultSettingsContent = reader.ReadToEnd();
            }

            return defaultSettingsContent;
        }
    }
}
