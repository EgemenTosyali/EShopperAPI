using EShopperAPI.Application.Abstractions.Storage;
using EShopperAPI.Infrastructure.Enums;
using EShopperAPI.Infrastructure.Services.Storage;
using EShopperAPI.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageTypes storageType)
        {
            switch (storageType)
            {
                case StorageTypes.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;

                case StorageTypes.Azure:
                    break;

                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
