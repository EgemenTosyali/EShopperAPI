using EShopperAPI.Application.Abstractions.Services.Authentication;
using EShopperAPI.Application.Abstractions.Token;
using EShopperAPI.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShopperAPI.Application.Features.Commands.AppUser.GoogleLoginUser
{
    public class GoogleLoginUserCommandHandler : IRequestHandler<GoogleLoginUserCommandRequest, GoogleLoginUserCommandResponse>
    {
        readonly IExternalAuthentication _authService;

        public GoogleLoginUserCommandHandler(IExternalAuthentication authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginUserCommandResponse> Handle(GoogleLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.GoogleLoginAsync(request.idToken, 15);
            return new()
            {
                token = token
            };
        }
    }
}
