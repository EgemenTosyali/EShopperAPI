using EShopperAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EShopperAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EShopperAPIDbContext>
    {
        public EShopperAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EShopperAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(ConfigurationService.GetConfigurationValue("PostgreSQL_ConnectionString"));
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
