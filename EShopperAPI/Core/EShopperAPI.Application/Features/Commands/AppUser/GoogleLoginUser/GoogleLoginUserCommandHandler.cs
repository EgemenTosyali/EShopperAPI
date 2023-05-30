using EShopperAPI.Application.Abstractions.Token;
using EShopperAPI.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShopperAPI.Application.Features.Commands.AppUser.GoogleLoginUser
{
    public class GoogleLoginUserCommandHandler : IRequestHandler<GoogleLoginUserCommandRequest, GoogleLoginUserCommandResponse>
    {
        readonly UserManager<EShopperAPI.Domain.Entities.Identities.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;

        public GoogleLoginUserCommandHandler(UserManager<Domain.Entities.Identities.AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginUserCommandResponse> Handle(GoogleLoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return null;

            //var settings = new GoogleJsonWebSignature.ValidationSettings()
            //{
            //    Audience = new List<string> { "679370732223-pjg7iiarc39citrcq8gvf3k2kblmteni.apps.googleusercontent.com" }
            //};
            //var payload = await GoogleJsonWebSignature.ValidateAsync(request.idToken);
            //var info = new UserLoginInfo(request.provider, payload.Subject, request.provider);
            //Domain.Entities.Identities.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            //bool result = user != null;
            //if (user == null)
            //{
            //    user = await _userManager.FindByEmailAsync(payload.Email);
            //    if (user == null)
            //    {
            //        user = new()
            //        {
            //            Id = Guid.NewGuid().ToString(),
            //            Email = payload.Email,
            //            UserName = payload.Email,
            //            Name = payload.Name,
            //            SurName = payload.Name
            //        };
            //    }
            //    var identityResult = await _userManager.CreateAsync(user);
            //    result = identityResult.Succeeded;
            //}
            //if (result)
            //    await _userManager.AddLoginAsync(user, info);
            //else
            //    throw new Exception("Google Authentication failed");

            //Token token = _tokenHandler.CreateAccessToken(5);
            //return new()
            //{
            //    token = token
            //};
        }
    }
}
