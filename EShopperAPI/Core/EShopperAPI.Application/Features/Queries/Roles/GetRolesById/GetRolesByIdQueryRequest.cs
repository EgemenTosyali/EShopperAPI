using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Queries.Roles.GetRolesById
{
    public class GetRolesByIdQueryRequest : IRequest<GetRolesByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
