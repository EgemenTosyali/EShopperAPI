using EShopperAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Queries.Roles.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
    {
        private readonly IRoleService roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = roleService.GetAllRoles(request.Page,request.Size);
            return new GetAllRolesQueryResponse()
            {
                Roles = result
            };
        }
    }
}
