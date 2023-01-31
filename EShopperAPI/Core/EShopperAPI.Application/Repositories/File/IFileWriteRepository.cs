using EShopperAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<EShopperAPI.Domain.Entities.File>
    {
    }
}
