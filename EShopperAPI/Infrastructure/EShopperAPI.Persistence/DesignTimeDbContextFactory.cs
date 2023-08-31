using EShopperAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EShopperAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EShopperAPIDbContext>
    {
        private readonly IConfiguration _configuration;

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public EShopperAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EShopperAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(_configuration["PostgreSQL_ConnectionString"]);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
