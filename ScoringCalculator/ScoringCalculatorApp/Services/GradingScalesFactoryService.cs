using ScoringCalculator.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ScoringCalculator.Services
{
    internal static class GradingScalesFactoryService
    {
        public static ObservableCollection<GradingScale> GetGradingScales()
        {
            string settingsFileContent = ApplicationSettingsService.GetGradingScalesSettingsFileContent();
            IEnumerable<GradingScale> gradingScales = GradingScalesSerializer.DeserializeScales(settingsFileContent);

            if (gradingScales != null) return new ObservableCollection<GradingScale>(gradingScales);
            return new ObservableCollection<GradingScale>();
        }
    }
}
