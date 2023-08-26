using EShopperAPI.Domain.Entities;
using EShopperAPI.Domain.Entities.Common;
using EShopperAPI.Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = EShopperAPI.Domain.Entities.File;

namespace EShopperAPI.Persistence.Contexts
{
    public class EShopperAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public EShopperAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        // Interceptor: pre create data before saving
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.createDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.updateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
