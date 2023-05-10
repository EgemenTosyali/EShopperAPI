using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.AppUser.GoogleLoginUser
{
    public class GoogleLoginUserCommandRequest : IRequest<GoogleLoginUserCommandResponse>
    {
    }
}
