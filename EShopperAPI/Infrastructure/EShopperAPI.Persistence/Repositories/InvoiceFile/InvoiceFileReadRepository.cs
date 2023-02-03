﻿using EShopperAPI.Application.Repositories;
using EShopperAPI.Domain.Entities;
using EShopperAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(EShopperAPIDbContext context) : base(context)
        {
        }
    }
}