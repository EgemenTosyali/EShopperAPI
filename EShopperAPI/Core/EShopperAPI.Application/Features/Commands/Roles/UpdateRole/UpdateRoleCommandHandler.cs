using EShopperAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleService roleService;

        public UpdateRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await roleService.UpdateRole(request.Id, request.Name);
            return new() { Succeeded = result };
        }
    }
}
