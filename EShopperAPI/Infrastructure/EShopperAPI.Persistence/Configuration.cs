using Microsoft.Extensions.Configuration;

namespace EShopperAPI.Persistence
{
    public static class Configuration
    {

        public static string ConnectionString()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetSection("PostgreSQL_ConnectionString").Value;
        }
    }
}

