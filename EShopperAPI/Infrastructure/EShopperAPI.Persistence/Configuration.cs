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
            configurationManager.AddJsonFile("appsettings.json");


            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") switch
            {
                "Development" => configurationManager.GetConnectionString("PostgreSQL-Development"),
                "Staging" => configurationManager.GetConnectionString("PostgreSQL-Staging"),
                "Production" => configurationManager.GetConnectionString("PostgreSQL-Production")
            };
        }
    }
}
