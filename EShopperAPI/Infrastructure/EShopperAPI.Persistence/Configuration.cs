using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Persistence
{
    static class Configuration
    {

        public static string ConnectionString()
        {
            ConfigurationManager configurationManager = new();
            configurationManager.AddUserSecrets("78dacb82-aaef-449b-9453-cc4d8f900294");

            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") switch
            {
                "Development" => configurationManager.GetConnectionString("PostgreSQL-Development"),
                "Staging" => configurationManager.GetConnectionString("PostgreSQL-Staging"),
                "Production" => configurationManager.GetConnectionString("PostgreSQL-Production")
            };
        }
    }
}
