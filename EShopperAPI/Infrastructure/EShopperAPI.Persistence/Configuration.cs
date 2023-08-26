namespace EShopperAPI.Persistence
{
    static class Configuration
    {

        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") switch
            {
                "Development" => Environment.GetEnvironmentVariable("PostgreSQL_Development").ToString(),
                "Staging" => Environment.GetEnvironmentVariable("PostgreSQL_Staging").ToString(),
                "Production" => Environment.GetEnvironmentVariable("PostgreSQL_Production").ToString()
            };
        }
    }
}
