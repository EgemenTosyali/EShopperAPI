using EShopperAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EShopperAPIDbContext>
    {
        public EShopperAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EShopperAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString());
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
