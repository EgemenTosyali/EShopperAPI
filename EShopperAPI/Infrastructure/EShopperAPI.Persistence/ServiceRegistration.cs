using EShopperAPI.Application.Repositories;
using EShopperAPI.Persistence.Contexts;
using EShopperAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<EShopperAPIDbContext>(option => option.UseNpgsql(Configuration.ConnectionString()));
            service.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            service.AddScoped<IFileReadRepository, FileReadRepository>();
            service.AddScoped<IFileWriteRepository, FileWriteRepository>();
            service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            service.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            service.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        }
    }
}
