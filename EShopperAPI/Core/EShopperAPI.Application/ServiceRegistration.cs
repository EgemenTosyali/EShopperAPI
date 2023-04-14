using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
