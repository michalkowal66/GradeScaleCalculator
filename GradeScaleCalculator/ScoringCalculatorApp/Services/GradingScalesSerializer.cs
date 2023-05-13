using ScoringCalculator.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ScoringCalculator.Services
{
    internal static class GradingScalesSerializer
    {
        public static string SerializeScales(IEnumerable<GradingScale> gradingScale)
        {
            string serializedGradingScales = JsonConvert.SerializeObject(gradingScale, Formatting.Indented);

            return serializedGradingScales;
        }

        public static IEnumerable<GradingScale>? DeserializeScales(string serializedGradingScales) 
        {
            IEnumerable<GradingScale>? deserializedGradingScales = JsonConvert.DeserializeObject<IEnumerable<GradingScale>>(serializedGradingScales);

            return deserializedGradingScales;
        }
    }
}
