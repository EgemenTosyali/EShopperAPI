using EShopperAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EShopperAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
