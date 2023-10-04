using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Queries.Roles.GetAllRoles
{
    public class GetAllRolesQueryResponse
    {
        public object Roles {  get; set; }
        public int totalRoleCount { get; set; }
    }
}
