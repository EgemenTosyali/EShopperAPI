using EShopperAPI.Application.DTOs.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Configurations
{
    public interface IApplicationService
    {
        List<Menu> GetAuthorizationDefinitionAttributes(Type type);
    }
}
