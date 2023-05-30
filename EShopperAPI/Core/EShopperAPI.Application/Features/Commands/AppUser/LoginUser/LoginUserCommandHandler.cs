using EShopperAPI.Application.Abstractions.Services;
using EShopperAPI.Application.Abstractions.Services.Authentication;
using MediatR;

namespace EShopperAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private IInternalAuthentication _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.usernameOrEmail, request.password, 15);
            return new LoginUserCommandSuccessResponse()
            {
                Token = token
            };
        }
    }
}
