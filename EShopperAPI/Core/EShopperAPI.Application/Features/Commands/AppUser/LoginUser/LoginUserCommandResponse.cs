using EShopperAPI.Application.DTOs;

namespace EShopperAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
    }
    public class LoginUserCommandSuccessResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserCommandErrorResponse: LoginUserCommandResponse
    {
        public string errorMessage { get; set; }
    }
}
