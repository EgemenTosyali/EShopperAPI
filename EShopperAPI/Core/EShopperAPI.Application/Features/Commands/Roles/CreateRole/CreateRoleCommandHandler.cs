using EShopperAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleService roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await roleService.CreateRole(request.Name);
            return new()
            {
                Succeeded = result
            };
        }
    }
}
