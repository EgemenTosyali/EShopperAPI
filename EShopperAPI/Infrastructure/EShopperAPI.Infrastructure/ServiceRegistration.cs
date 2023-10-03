using EShopperAPI.Application.Abstractions.Storage;
using EShopperAPI.Application.Abstractions.Token;
using EShopperAPI.Application.Configurations;
using EShopperAPI.Infrastructure.Services.Configurations;
using EShopperAPI.Infrastructure.Services.Storage;
using EShopperAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace EShopperAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
