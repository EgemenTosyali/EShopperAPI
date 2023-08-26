using EShopperAPI.Application.Repositories;
using EShopperAPI.Persistence.Contexts;

namespace EShopperAPI.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<EShopperAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(EShopperAPIDbContext context) : base(context)
        {
        }
    }
}
