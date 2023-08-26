using EShopperAPI.Application.Repositories;
using EShopperAPI.Persistence.Contexts;
using File = EShopperAPI.Domain.Entities.File;

namespace EShopperAPI.Persistence.Repositories
{
    public class FileReadRepository : ReadRepository<File>, IFileReadRepository
    {
        public FileReadRepository(EShopperAPIDbContext context) : base(context)
        {
        }
    }
}
