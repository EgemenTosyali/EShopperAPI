using EShopperAPI.Application.Repositories;
using EShopperAPI.Domain.Entities;
using EShopperAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EShopperAPIDbContext context) : base(context)
        {
        }
    }
}
