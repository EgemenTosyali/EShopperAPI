using EShopperAPI.Application.Abstractions.Services;
using EShopperAPI.Application.DTOs.User;
using EShopperAPI.Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;

namespace EShopperAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                UserName = model.UserName,
                Name = model.Name,
                SurName = model.Surname


            }, model.Password);

            CreateUserResponse response = new CreateUserResponse() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Successfuly Registered";
            else
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            return response;
        }
        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(refreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("user not found");
        }
    }
}
