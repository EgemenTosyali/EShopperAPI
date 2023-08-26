using MediatR;

namespace EShopperAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string usernameOrEmail { get; set; }
        public string password { get; set; }
    }
}
