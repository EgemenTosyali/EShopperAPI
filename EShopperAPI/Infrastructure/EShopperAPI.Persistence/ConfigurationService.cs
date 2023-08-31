using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EShopperAPI.Persistence
{
    public static class ConfigurationService
    {
        public static string GetConfigurationValue(string key)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.AddJsonFile("appsettings.json").AddEnvironmentVariables().AddUserSecrets(Assembly.GetExecutingAssembly());

            return configurationManager.GetSection(key).Value;
        }
    }
}

