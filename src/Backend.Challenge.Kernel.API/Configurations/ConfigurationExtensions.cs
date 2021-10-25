using Microsoft.Extensions.Configuration;

namespace Backend.Challenge.Kernel.API
{
    public static class ConfigurationExtensions
    {
        public static string GetConfigurationValueByName(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("ConfigurationsData")[name];
        }

    }
}
