using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}
