using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}
