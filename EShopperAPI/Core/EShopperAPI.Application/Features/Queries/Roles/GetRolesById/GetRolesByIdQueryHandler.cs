using EShopperAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Queries.Roles.GetRolesById
{
    public class GetRolesByIdQueryHandler : IRequestHandler<GetRolesByIdQueryRequest, GetRolesByIdQueryResponse>
    {
        private readonly IRoleService roleService;

        public GetRolesByIdQueryHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<GetRolesByIdQueryResponse> Handle(GetRolesByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await roleService.GetRoleById(request.Id);
            return new() { Id = result.id, Name = result.name };
        }
    }
}
