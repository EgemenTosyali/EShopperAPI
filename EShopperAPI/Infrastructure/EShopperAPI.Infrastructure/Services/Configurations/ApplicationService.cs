using EShopperAPI.Application.Attributes;
using EShopperAPI.Application.Configurations;
using EShopperAPI.Application.DTOs.Configurations;
using EShopperAPI.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Action = EShopperAPI.Application.DTOs.Configurations.Action;

namespace EShopperAPI.Infrastructure.Services.Configurations
{
    public class ApplicationService : IApplicationService
    {
        public List<Menu> GetAuthorizationDefinitionAttributes(Type type)
        {
            List<Menu> menus = new();
            Assembly assembly = Assembly.GetAssembly(type);
            var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
            if (controllers != null)
            {
                foreach (var controller in controllers)
                {
                    var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizationDefinitionAttribute)));
                    if (actions != null)
                    {
                        foreach (var action in actions)
                        {
                            var attributes = action.GetCustomAttributes(true);
                            if (attributes != null)
                            {
                                Menu menu = null;

                                var auhtorizedAttributes = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizationDefinitionAttribute)) as AuthorizationDefinitionAttribute;

                                if (!menus.Any(m => m.Name == auhtorizedAttributes.Menu))
                                {
                                    menu = new Menu { Name = auhtorizedAttributes.Menu };
                                    menus.Add(menu);
                                }
                                else
                                    menu = menus.FirstOrDefault(m => m.Name == auhtorizedAttributes.Menu);

                                Action dtoAction = new()
                                {
                                    ActionType = Enum.GetName(typeof(ActionType), auhtorizedAttributes.ActionType),
                                    Definition = auhtorizedAttributes.Definition
                                };

                                var http = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                                if (http != null)
                                {
                                    dtoAction.HttpType = http.HttpMethods.First();
                                }
                                else
                                    dtoAction.HttpType = HttpMethods.Get;

                                dtoAction.Code = $"{dtoAction.HttpType}.{dtoAction.ActionType}.{dtoAction.Definition.Replace(" ", "")}";

                                menu.Actions.Add(dtoAction);
                            }
                        }
                    }
                }
            }


            return menus;
        }
    }
}
