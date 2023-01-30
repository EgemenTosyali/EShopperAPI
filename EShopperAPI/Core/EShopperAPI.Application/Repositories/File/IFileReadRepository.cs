using EShopperAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = EShopperAPI.Domain.Entities.File;

namespace EShopperAPI.Application.Repositories
{
    public interface IFileReadRepository : IReadRepository<File>
    {
    }
}
