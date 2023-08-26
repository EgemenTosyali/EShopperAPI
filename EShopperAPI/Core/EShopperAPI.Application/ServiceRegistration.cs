using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShopperAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationServices(this IServiceCollection service)
        {
            service.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
