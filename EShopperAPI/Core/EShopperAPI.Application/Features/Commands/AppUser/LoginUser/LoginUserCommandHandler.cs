using EShopperAPI.Application.Abstractions.Token;
using EShopperAPI.Application.DTOs;
using EShopperAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopperAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<EShopperAPI.Domain.Entities.Identities.AppUser> _userManager;
        readonly SignInManager<EShopperAPI.Domain.Entities.Identities.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identities.AppUser> userManager, SignInManager<Domain.Entities.Identities.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            EShopperAPI.Domain.Entities.Identities.AppUser user = await _userManager.FindByNameAsync(request.usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.usernameOrEmail);
            if (user == null)
                throw new UserNotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.password, false);
            if (result.Succeeded)
            {
                Token token = _tokenHandler.CreateAccessToken(10);
                return new LoginUserCommandSuccessResponse()
                {
                    Token = token
                };
            }
            throw new AuthenticationErrorException();
        }
    }
}
