using EShopperAPI.Application.Abstractions.Services;
using EShopperAPI.Application.Abstractions.Services.Authentication;
using EShopperAPI.Application.Repositories;
using EShopperAPI.Domain.Entities.Identities;
using EShopperAPI.Persistence.Contexts;
using EShopperAPI.Persistence.Repositories;
using EShopperAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace EShopperAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<EShopperAPIDbContext>()
              .AddDefaultTokenProviders();

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

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IInternalAuthentication, AuthService>();
            service.AddScoped<IExternalAuthentication, AuthService>();

            service.AddScoped<IRoleService, RoleService>();
        }
    }
}
