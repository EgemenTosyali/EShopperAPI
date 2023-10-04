using EShopperAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {
        private readonly IRoleService roleService;

        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await roleService.DeleteRole(request.Name);
            return new() { Success = response };
        }
    }
}
